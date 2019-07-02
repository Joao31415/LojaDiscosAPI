using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Sieve.Attributes;

namespace LojaDiscosAPI.Models
{
    public class Disco
    {
        [Key]
        public int Id_Disco { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Nome { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Artista { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public string Genero { get; set; }

        [Sieve(CanFilter = true, CanSort = true)]
        public decimal Preco { get; set; }
    }
}
