using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaDiscosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sieve.Models;
using Sieve.Services;
using AutoMapper;
using LojaDiscosAPI.DTO;
using System.Diagnostics;

namespace LojaDiscosAPI.Controllers
{
    [Route("api/[controller]")]
    public class VendaController : Controller
    {

        private readonly ISieveProcessor _sieveProcessor;
        private readonly LojaDiscosDbContext _context;
        private readonly IMapper _mapper;

        public VendaController(ISieveProcessor sieveProcessor, LojaDiscosDbContext context, IMapper mapper)
        {
            _context = context;
            _sieveProcessor = sieveProcessor;
            _mapper = mapper;

/*
            Venda v = new Venda()
            {
                Id_Cliente = 1,
                Vl_Total = 100,
                Vl_TotalCashback = 23,
                Produtos = { new ItemVenda() { Id_Disco = 14, Preco = 177, Cashback = 7 }, new ItemVenda() { Id_Disco = 7, Preco = 143, Cashback = 2 } }
            };
            _context.Vendas.Add(v);
            _context.SaveChanges();

            if (_context.Vendas.Count() == 0)
            {
                for (int i = 0; i < 200; i++)
                {
                    _context.Vendas.Add(new Venda());
                }

                _context.SaveChanges();
            }
*/
        }


        // GET: api/Venda
        // Exemplo: https://localhost:44304/api/Venda?Sorts=-data&Filters=data>2019-07-06T15:10:51.3216194Z,data<2019-07-08T15:10:51.3216194Z&pagesize=20
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetVendas(SieveModel sieveModel)
        {
            var result = _context.Vendas.AsNoTracking();

            if (sieveModel.Sorts == null)
                sieveModel.Sorts = "-data";

            result = _sieveProcessor.Apply(sieveModel, result);

            return await (result.ToListAsync());

        }


        // GET api/Venda/id
        [HttpGet("{id}")]
        public async Task<ActionResult<Venda>> GetVenda(int id)
        {
            var Venda = await  _context.Vendas.Include(prod => prod.Produtos).SingleAsync(v => v.Id_Venda == id);

            if (Venda == null)
            {
                return NotFound();
            }
            return Venda;
        }


        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] NewVendaDTO newVenda)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var venda = _mapper.Map<NewVendaDTO, Venda>(newVenda);

            Cashback cashback = new Cashback();
            decimal totalCashback = 0;
            decimal totalVenda = 0;
            for (int i=0; i < venda.Produtos.Count; i++)
            {
                var produtoExistente = await _context.Discos.FindAsync(venda.Produtos[i].Id_Disco);
                if (produtoExistente == null)
                    return BadRequest();
                venda.Produtos[i].Preco = produtoExistente.Preco;
                venda.Produtos[i].Cashback = cashback.valorCashback(produtoExistente.Preco, produtoExistente.Genero, venda.Data);
                totalVenda += venda.Produtos[i].Preco;
                totalCashback += venda.Produtos[i].Cashback;
            }
            venda.Vl_Total = totalVenda;
            venda.Vl_TotalCashback = totalCashback;

            _context.Vendas.Add(venda);

            var result = _context.SaveChanges();

            //var newVendaDTO = _mapper.Map<Venda, NewVendaDTO>(venda);
            //return Ok(newVendaDTO);
            return Ok(venda);
        }

/*
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venda>>> GetAllDVendas()
        {
            return await _context.Vendas.Include(prod => prod.Produtos).ToListAsync();

            //return await _context.Vendas.ToListAsync();
            //return Ok(result);
        }
*/

    }
}
