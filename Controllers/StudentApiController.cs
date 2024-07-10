using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Authorization;
using PagedList.Mvc;
using PagedList;
using System.Data.Entity.Infrastructure;
using System.Data;
//using System.Web.Mvc;

namespace ContosoUniversity.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class StudentApiController : Controller
    {
        private readonly ContosoUniversityContext _context;

        public StudentApiController(ContosoUniversityContext context)
        {
            _context = context;
        }

        // GET: Student
        public async Task<IActionResult> Index()
        {
            return Ok();
        }
    }
}
