using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Core.Domain.Heroes;

namespace Demo.Core.Repositories
{
    public interface IHeroRepository
    {
        Task<IEnumerable<Hero>> FindAllAsync();
    }
}
