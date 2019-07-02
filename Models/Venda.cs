using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Sieve.Attributes;

namespace LojaDiscosAPI.Models
{
    public class Venda
    {
        [Key]
        public int Id_Venda { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public int Id_Cliente { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public DateTime Data { get; set; } // = DateTime.UtcNow.AddDays(new Random().Next(0, 9));

        public IList<ItemVenda> Produtos { get; set; } = new List<ItemVenda>();

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Vl_TotalCashback { get; set; } = 0;

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Vl_Total { get; set; } = 0;
    }
}
