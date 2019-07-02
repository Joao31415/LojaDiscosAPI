using LojaDiscosAPI.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LojaDiscosAPI.DTO
{
    public class NewVendaDTO
    {
        [Required]
        public int Id_Cliente { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime Data { get; set; }

        [Required]
        public List<ItemVenda> Produtos { get; set; }

    }
}
