using Sieve.Services;
using LojaDiscosAPI.Models;
using System.Linq;

namespace LojaDiscosAPI.Services
{
    public class SieveCustomFilterMethods : ISieveCustomFilterMethods
    {
        public IQueryable<Disco> IsNew(IQueryable<Disco> source, string op, string[] values)
            => source.Where(p => p.Preco < 100 && p.Id_Disco < 50);

    }
}
