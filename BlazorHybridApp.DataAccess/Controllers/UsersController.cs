using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorHybridApp.DataAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorHybridApp.DataAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {


        private readonly cugemderdatabaseupdateContext _context;

        public UsersController(cugemderdatabaseupdateContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AspNetUsers>>> GetAspNetUsers()
        {
            return await _context.AspNetUsers
                .Include(c => c.GroupNavigation)
                .Include(c => c.PointsNavigation)
                .Include(c => c.GenderNavigation)
                .OrderByDescending(c => c.PointsNavigation.TotalPoints)
                .ToListAsync();
        }
    }
}
