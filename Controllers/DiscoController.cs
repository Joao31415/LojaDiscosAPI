using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LojaDiscosAPI.DadosExternos;
using LojaDiscosAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Sieve.Models;
using Sieve.Services;


namespace LojaDiscosAPI.Controllers
{
	[Route("api/[controller]")]
    public class DiscoController : Controller
	{
        private readonly ISieveProcessor _sieveProcessor;
		private readonly LojaDiscosDbContext _context;
		private readonly IDadosExternosClient _dadosExternosClient;

		public DiscoController(ISieveProcessor sieveProcessor, LojaDiscosDbContext context, IDadosExternosClient dadosExternosClient)
		{
			_context = context;
            _sieveProcessor = sieveProcessor;
			_dadosExternosClient = dadosExternosClient;

			if (_context.Discos.Count() == 0)
			{
                try
                {
                    GetDadosExternos("pop").Wait();
                    GetDadosExternos("mpb").Wait();
                    GetDadosExternos("classic").Wait();
                    GetDadosExternos("rock").Wait();

                }
                catch (Exception)
                {

                    Debug.WriteLine("Erro ao popular dados do Last-FM. Verifique se a API Key está correta.");
                }
            }
		}


        public async Task<ActionResult> GetDadosExternos(string genero)
        {
            string dados = await _dadosExternosClient.GetDataAsync(genero);
            var dadosExternos = JsonConvert.DeserializeObject<DadosExternosModel>(dados);

            Random random = new Random();


            foreach (var da in dadosExternos.albums.album)
            {
                var entrada = new Disco
                {
                    Nome = da.name,
                    Artista = da.artist.name,
                    Preco = random.Next(90, 301),
                    Genero = genero
                };
                _context.Discos.Add(entrada);
                //
            }
            _context.SaveChanges();
            return Ok();
        }


        // GET: api/Disco
        // Exemplo: https://localhost:44304/api/disco?Filters=genero==rock&Sorts=nome&page=1&pageSize=15
        [HttpGet]
		public async Task<ActionResult<IEnumerable<Disco>>> GetDiscos(SieveModel sieveModel)
		{
            var result = _context.Discos.AsNoTracking();

            if (sieveModel.Sorts == null)
                sieveModel.Sorts = "nome";

            result = _sieveProcessor.Apply(sieveModel, result);

            return await (result.ToListAsync());

		}


        // GET api/Disco/id
        [HttpGet("{id}")]
		public async Task<ActionResult<Disco>> GetDisco(int id)
		{
			var Disco = await _context.Discos.FindAsync(id);

			if (Disco == null)
			{
				return NotFound();
			}
			return Disco;
		}


 
    }
}
