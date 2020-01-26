namespace MiniGigWebApi.Data.Dapper
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using MiniGigWebApi.Domain;
 
    public interface IAsyncGigRepository
    {
        Task<Gig> FindGigDetails(int id);

        Task<IEnumerable<Gig>> GetAllGigsWithGenre(int page, int pageSize);

        Task<bool> Insert(Gig entity);

        Task<bool> Update(Gig gig);

        Task<bool> Delete(int id);     
    }
}
