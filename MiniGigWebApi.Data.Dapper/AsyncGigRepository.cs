namespace MiniGigWebApi.Data.Dapper
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Threading.Tasks;
    using global::Dapper;
    using MiniGigWebApi.Domain;

    public class AsyncGigRepository : IAsyncGigRepository
    {
        private readonly IDbConnection connection;

        public AsyncGigRepository(IDbConnection context)
        {
            this.connection = context;
        }

        public async Task<Gig> FindGigDetails(int id)
        {
            var sql = @"
            SELECT G.Id, Name, GigDate, MusicGenreId, M.Id, Category 
            FROM Gigs AS G INNER JOIN MusicGenres AS M ON G.MusicGenreId =  M.Id 
            WHERE G.Id = @Id 
            ORDER BY G.GigDate Desc";

            Task<IEnumerable<Gig>> queryTask = this.connection.QueryAsync<Gig, MusicGenre, Gig>(
                sql,
                (gig, musicGenre) => 
                {
                    gig.MusicGenre = musicGenre;
                    return gig;
                },
                new { Id = id }
               );

            IEnumerable<Gig> gigDetails = await queryTask;

            return gigDetails.FirstOrDefault();
        }

        public async Task<IEnumerable<Gig>> GetAllGigsWithGenre(int page, int pageSize)
        {
            var sql = @"
                SELECT G.Id, Name, GigDate, MusicGenreId, M.Id, Category
                FROM Gigs AS G 
                INNER JOIN MusicGenres AS M ON M.Id = G.MusicGenreId 
                ORDER BY G.GigDate Desc";

            Task<IEnumerable<Gig>> queryTask = this.connection.QueryAsync<Gig, MusicGenre, Gig>(
                sql,
                (gig, musicGenre) => 
                {
                    gig.MusicGenre = musicGenre;
                    return gig;
                }
                );

            IEnumerable<Gig> gigs = await queryTask;

            if (page > 0 && pageSize > 0)
            {
                return gigs.Skip(pageSize * (page - 1)).Take(pageSize);
            }

            return gigs;
        }

        /// <summary>
        /// Insert a Gig into the database, provided the Name, GigDate and MusicGenreId.
        /// There are two options to get the MusicGenreId
        /// 1. Getting it from the MusicGenre object within Gig entity. 
        /// 2. Having the MusicGenreId field within Gig entity public int MusicGenreId { get; set; } 
        /// The later option is kind of redundant but easier to implement. To get that working:
        /// 2.1 Task<IEnumerable<int>> queryTask = this.connection.QueryAsync<int>(sql, entity);
        /// 2.2 In gig mapping profile's
        ///     CreateMap<Gig, GigModel>()
        ///         .ForMember(c => c.MusicGenreId, opt => opt.MapFrom(m => m.MusicGenre.Id))
        /// The first option is the one implemented
        /// 1.1 We get the MusicGenreId from entity.MusicGenre.Id without any ForMember in gig mapping profile's  
        ///     Task<IEnumerable<int>> queryTask = this.connection.QueryAsync<int>(sql, new { Name = entity.Id, entity.GigDate, MusicGenreId = entity.MusicGenre.Id });
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<bool> Insert(Gig entity)
        {
            bool added = false;

            var sql =
                "INSERT INTO Gigs (Name, GigDate, MusicGenreId) VALUES (@Name, @GigDate, @MusicGenreId); " +
                "SELECT CAST(SCOPE_IDENTITY() as int)";
            Task<IEnumerable<int>> queryTask = this.connection.QueryAsync<int>(sql, new { entity.Name, entity.GigDate, MusicGenreId = entity.MusicGenre.Id });

            IEnumerable<int> result = await queryTask;
            var newId = result.Single();
            added = newId > 0;

            if (added)
            {
                entity.Id = newId;
            }

            return added;
        }

        public async Task<bool> Update(Gig entity)
        {
            var sql = @"
                UPDATE Gigs
                SET Name = @Name, GigDate = @GigDate, MusicGenreId = @MusicGenreId
                WHERE Id = @Id";
            var updated = await this.connection.ExecuteAsync(sql, new { entity.Id, entity.Name, entity.GigDate, MusicGenreId = entity.MusicGenre.Id });

            return updated > 0; // Only return success if at least one row was changed
        }

        public async Task<bool> Delete(int id)
        {
            var sql = $"DELETE FROM Gigs WHERE Id = @Id";
            var deleted = await this.connection.ExecuteAsync(sql, new { Id = id });
            return deleted > 0; // Only return success if at least one row was changed
        }
    }
}
