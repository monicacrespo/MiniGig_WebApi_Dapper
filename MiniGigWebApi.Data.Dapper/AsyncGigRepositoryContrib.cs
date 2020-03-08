namespace MiniGigWebApi.Data.Dapper
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Threading.Tasks;
    using global::Dapper.Contrib.Extensions;
    using MiniGigWebApi.Domain;

    /// <summary>
    /// Changes to be done to use Dapper.Contrib 
    /// On Gig.cs class: 
    /// 1. Having the MusicGenreId field => public int MusicGenreId { get; set; } 
    /// 2. MusicGenre property needs to be commented out => public MusicGenre MusicGenre { get; set; }
    /// On GigsController.cs class
    /// 1. Define the gigRepositoryContrib field => private readonly IAsyncGigRepository<AsyncGigRepositoryContrib> gigRepositoryContrib;
    /// 2. Add it as a constructor parameter to be injected
    ///     public GigsController(IAsyncGigRepository<AsyncGigRepository> gigRepository, 
    ///                             IAsyncGigRepository<AsyncGigRepositoryContrib> gigRepositoryContrib, 
    ///                             IMapper mapper)
    ///     {
    ///        this.gigRepository = gigRepository;
    ///        this.gigRepositoryContrib = gigRepositoryContrib;
    ///        this.mapper = mapper;           
    ///     }
    /// 3. Use it, e.g.  var result = await this.gigRepositoryContrib.FindGigDetails(id);
    /// </summary>
    public class AsyncGigRepositoryContrib : IAsyncGigRepository<AsyncGigRepositoryContrib>
    {
        private readonly IDbConnection connection;

        public AsyncGigRepositoryContrib(IDbConnection context)
        {
            this.connection = context;
        }        

        public async Task<Gig> FindGigDetails(int id)
        {
            return await this.connection.GetAsync<Gig>(id);
        }

        public Task<IEnumerable<Gig>> GetAllGigsWithGenre(int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Insert(Gig entity)
        {
            bool added = false;

            Task<int> result  = this.connection.InsertAsync<Gig>(entity);

            int newId = await result;

            added = newId > 0;

            if (added)
            {
                entity.Id = newId;
            }

            return added;         
        }

        public async Task<bool> Update(Gig gig)
        {
            return await this.connection.UpdateAsync<Gig>(gig);
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }      
    }
}