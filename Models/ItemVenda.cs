using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Sieve.Attributes;

namespace LojaDiscosAPI.Models
{
    public class ItemVenda
    {
        [Key]
        public int Id_ItemVenda { get; set; }

        public int Id_Disco { get; set; }

        public decimal Preco { get; set; }

        public decimal Cashback { get; set; }
    }
}
