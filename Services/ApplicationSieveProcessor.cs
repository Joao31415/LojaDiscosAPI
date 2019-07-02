using Microsoft.Extensions.Options;
using Sieve.Models;
using Sieve.Services;
using LojaDiscosAPI.Models;


namespace LojaDiscosAPI.Services
{
    public class ApplicationSieveProcessor : SieveProcessor
    {
        public ApplicationSieveProcessor(IOptions<SieveOptions> options, ISieveCustomSortMethods customSortMethods, ISieveCustomFilterMethods customFilterMethods) : base(options, customSortMethods, customFilterMethods)
        {
        }

        protected override SievePropertyMapper MapProperties(SievePropertyMapper mapper)
        {
            mapper.Property<Disco>(p => p.Nome)
                .CanSort()
                .CanFilter()
                .HasName("CustomTitleName");
            return mapper;
        }
    }
}
