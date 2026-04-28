namespace MiniGigWebApi.Controllers
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Web.Http;
    using MiniGigWebApi.Data.Dapper;
    using MiniGigWebApi.Domain;

    [RoutePrefix("api/gigs")]
    public class GigsController : ApiController
    {
        private readonly IAsyncGigRepository<AsyncGigRepository> gigRepository;

        public GigsController(IAsyncGigRepository<AsyncGigRepository> gigRepository)
        {
            this.gigRepository = gigRepository;
        }

        [Route]
        public async Task<IHttpActionResult> Get(int page = 0, int pageSize = 5)
        {
            try
            {
                var result = await this.gigRepository.GetAllGigsWithGenre(page, pageSize);
                var mappedResult = result?.Select(GigMapper.ToModel);

                return this.Ok(mappedResult);
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("{id}", Name = "GetGig")]
        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var result = await this.gigRepository.FindGigDetails(id);

                if (result == null)
                {
                    return this.NotFound();
                }

                return this.Ok(GigMapper.ToModel(result));
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [HttpPost]
        [Route]
        public async Task<IHttpActionResult> Post(GigModel model)
        {
            try
            {
                if (await this.gigRepository.FindGigDetails(model.Id) != null)                
                {
                    ModelState.AddModelError("GigId", "Gig in use");
                }

                if (ModelState.IsValid)
                {
                    var gig = GigMapper.ToEntity(model);

                    if (await this.gigRepository.Insert(gig))
                    {
                        var newModel = GigMapper.ToModel(gig);
                        return this.CreatedAtRoute("GetGig", new { id = newModel.Id }, newModel);
                    }
                }
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }

            return this.BadRequest(this.ModelState);
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Put(int id, GigModel model)
        {
            try
            {
                var gig = await this.gigRepository.FindGigDetails(id);
                if (gig == null)
                {
                    return this.NotFound();
                }

                if (id != model.Id)
                {
                    return this.BadRequest();
                }

                GigMapper.UpdateEntity(model, gig);

                if (await this.gigRepository.Update(gig))
                {
                    return this.Ok(GigMapper.ToModel(gig));
                }
                else
                {
                    return this.InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }

        [Route("{id}")]
        public async Task<IHttpActionResult> Delete(int id)
        {
            try
            {
                var gig = await this.gigRepository.FindGigDetails(id);
                if (gig == null)
                {
                    return this.NotFound();
                }

                if (await this.gigRepository.Delete(id))
                {
                    return this.Ok();
                }
                else
                {
                    return this.InternalServerError();
                }
            }
            catch (Exception ex)
            {
                return this.InternalServerError(ex);
            }
        }
    }
}