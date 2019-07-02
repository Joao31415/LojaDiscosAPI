using Sieve.Services;
using LojaDiscosAPI.Models;
using System.Linq;

namespace LojaDiscosAPI.Services
{
    public class SieveCustomSortMethods : ISieveCustomSortMethods
    {

        public IQueryable<Disco> Popularity(IQueryable<Disco> source, bool useThenBy) => useThenBy
            ? ((IOrderedQueryable<Disco>)source).ThenBy(p => p.Nome)
            : source.OrderBy(p => p.Nome);
    }
}
