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
        public async Task Left(int id, DiffRequestModel data)
        {
            //Do we have anything in the store?
            var entry = await dbContext.DiffEntries.FindAsync(id);

            if (entry == null)
            {
                entry = new DiffEntry();
                entry.Id = id; //Not ideal
                dbContext.DiffEntries.Add(entry);
            }

            entry.Left = data.Data;

            await dbContext.SaveChangesAsync();

            this.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        }

        [HttpPut]
        [Route("diff/{id}/right")]
        public async Task Right(int id, DiffRequestModel data)
        {
            //Do we have anything in the store?
            var entry = await dbContext.DiffEntries.FindAsync(id);

            if (entry == null)
            {
                entry = new DiffEntry();
                entry.Id = id; //Not ideal
                dbContext.DiffEntries.Add(entry);
            }

            entry.Right = data.Data;

            await dbContext.SaveChangesAsync();

            this.HttpContext.Response.StatusCode = (int)HttpStatusCode.Created;
        }

        [HttpGet]
        [Route("diff/{id}")]
        public async Task<DiffResultModel> DiffResult(int id)
        {
            var entry = await dbContext.DiffEntries.FindAsync(id);

            if (entry == null)
            {
                this.HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }

            var diffResult = differ.Compare(entry.Left, entry.Right);

            //TODO automapper to make this cleaner
            var returnValue = new DiffResultModel()
            {
                DiffResultType = diffResult.DiffResultType
            };

            if (diffResult.Discrepancies != null)
            {
                returnValue.Discrepancies = diffResult.Discrepancies
                    .Select(d => new DiffDataModel() { Length = d.Length, Offset = d.Offset })
                    .ToArray();
            }

            return returnValue;
        }
    }
}
