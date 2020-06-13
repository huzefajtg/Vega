using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Features;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega2.Controllers.Resources;
using Vega2.Models;
using Vega2.Persistence;

namespace Vega2.Controllers
{
    public class FeatureController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;
        public FeatureController(VegaDbContext _context, IMapper _mapper)
        {
            this.context = _context;
            this.mapper = _mapper;
        }

        [HttpGet("/api/features")]
        public async Task<IEnumerable<KeyValuePairResource>> getFeatures()
        {
            var featureList = await context.Feature.ToListAsync();

            return mapper.Map<List<Features>, List<KeyValuePairResource>>(featureList);
        }

    }
}