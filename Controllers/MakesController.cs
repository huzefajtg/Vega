using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Vega2.Controllers.Resources;
using Vega2.Models;
using Vega2.Persistence;

namespace Vega2.Controllers
{
    public class MakesController : Controller
    {
        private readonly VegaDbContext context;
        private readonly IMapper mapper;

        public MakesController(VegaDbContext context, IMapper mapper) {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpGet("/api/makes")]
        public async Task<IEnumerable<MakesResources>> GetMakes()
        {
            var makes = await context.Make.Include(m => m.Models).ToListAsync();

            return mapper.Map<List<Make>, List<MakesResources>>(makes);
        }



    }
}