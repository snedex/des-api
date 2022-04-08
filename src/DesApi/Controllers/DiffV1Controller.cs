using DesApi.Data;
using DesApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DesApi.Controllers
{
    [ApiController]
    [Route("v1")]
    public class DiffV1Controller : ControllerBase
    {
        private readonly AppDbContext dbContext;

        private readonly IDiffLogic differ;

        public DiffV1Controller(AppDbContext dbContext, IDiffLogic differ)
        {
            this.dbContext = dbContext;
            this.differ = differ;
        }

        // GET: DiffController
        [HttpPut]
        [Route("diff/{id}/left")]
        public string Left(int id)
        {
            return String.Empty;
        }

        [HttpPut]
        [Route("diff/{id}/right")]
        public string Right(int id)
        {
            return String.Empty;
        }

        [HttpGet]
        [Route("diff/{id}")]
        public string DiffResult(int id)
        {
            return null;
        }
    }
}
