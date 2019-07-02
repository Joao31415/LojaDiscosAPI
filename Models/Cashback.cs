using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace LojaDiscosAPI.Models
{
    public class Cashback
    {
        Dictionary<string, int> dicGenero = new Dictionary<string, int>()
        {
            {"pop", 0 },
            {"mpb", 1 },
            {"classic", 2 },
            {"rock", 3 }
        };

        private readonly decimal[,] porcentagens = new decimal[,]
            {
                {25, 7, 6, 2, 10, 15, 20},
                {30, 5, 10, 15, 20, 25, 30},
                {35, 3, 5, 8, 13, 18, 25},
                {40, 10, 15, 15, 15, 20, 40}
            };


        public decimal porcentagem (string genero, DateTime data)
        {
            if (dicGenero.ContainsKey(genero))
            {
                return porcentagens[dicGenero[genero], (int)data.DayOfWeek];
            }
            return 0;
        }

        public decimal valorCashback(decimal valor, string genero, DateTime data)
        {
            decimal desconto = porcentagem(genero, data);
            decimal final = (valor * (desconto / 100));
            return final;
        }
    }
}
