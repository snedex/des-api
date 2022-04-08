using DesApi.Data;
using DesApi.Domain;
using DesApi.Interfaces;
using DesApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        public async Task<StatusCodeResult> Left(int id, DiffRequestModel data)
        {
            //Do we have anything in the store?
            var entry = await dbContext.DiffEntries.FindAsync(id);

            if (entry == null)
            {
                entry = new DiffEntry();
                entry.Id = id; //Not ideal
            }

            entry.Left = data.Data;

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        [Route("diff/{id}/right")]
        public async Task<StatusCodeResult> Right(int id, DiffRequestModel data)
        {
            //Do we have anything in the store?
            var entry = await dbContext.DiffEntries.FindAsync(id);

            if (entry == null)
            {
                entry = new DiffEntry();
                entry.Id = id; //Not ideal
            }

            entry.Right = data.Data;

            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpGet]
        [Route("diff/{id}")]
        public DiffResultModel DiffResult(int id)
        {
            return null;
        }
    }
}
