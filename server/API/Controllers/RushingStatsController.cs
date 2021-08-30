using System.Collections.Generic;
using System.Threading.Tasks;
using API.Core.Interfaces;
using API.Data.Specifications;
using API.Data.ViewModels;
using API.Helpers;
using API.Models;
using Data.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class RushingStatsController : BaseController
    {
        private readonly IStatsRepository _statsRepository;

        public RushingStatsController(IStatsRepository statsRepository)
        {
            _statsRepository = statsRepository;
        }

        [Cached(600)]
        [HttpGet("GetAll")]
        public async Task<ActionResult<Pagination<List<RushingStat>>>> GetStats([FromQuery] StatsParams statsParams)
        {
            var spec = new RushingStatsSpecification(statsParams);
            var countSpec = new FilteredStatsCountSpecificication(statsParams);
            var totalItems = await _statsRepository.CountAsync(countSpec);
            var stats = await _statsRepository.GetStatsWithSpecificationAsync(spec);
            var results = Ok(new Pagination<RushingStat>(
                statsParams.PageIndex,
                statsParams.PageSize,
                totalItems,
                stats
            ));

            return results;
        }
    }
}