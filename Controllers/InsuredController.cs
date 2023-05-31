using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SampleApi.Data;

namespace SampleApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class InsuredController : ControllerBase
    {
        private readonly InsuredInfoContext _dbContext;

        public InsuredController(InsuredInfoContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        [Route("GetInsuredList")]
        public ActionResult<IEnumerable<Insured>> GetInsuredList()
        {
            var insureds = _dbContext.Insureds.AsNoTracking().ToList();
            return Ok(insureds);
        }

        [HttpGet]
        [Route("SearchInsured")]
        public async Task<ActionResult<IEnumerable<Insured>>> SearchInsuredAsync(string lastNameQuery)
        {
            var filteredInsured = await _dbContext.Insureds.Where(f => f.LastName.Contains(lastNameQuery)).AsNoTracking().ToListAsync().ConfigureAwait(false);
            return Ok(filteredInsured);
        }
    }
}