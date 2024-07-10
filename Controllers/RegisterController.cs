using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNet.Identity;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;
using ContosoUniversity.Models;
using ContosoUniversity.Authorization;
using ContosoUniversity.Services;
using Microsoft.AspNetCore.Http.Extensions;
using System.Text.Json;
using System.Net.Http;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace ContosoUniversity.Controllers
{

    //[Authorize]
    public class RegisterController : Controller
    {
        /*private readonly ContosoUniversityContext _context;

        public RegisterController(ContosoUniversityContext context)
        {
            _context = context;
        }*/

        private IUserService _userService;

        public RegisterController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Index()
        {
            /*return new ContentResult
            {
                //ContentType = "text/cshtml",
                //Content=""
            };*/
            
            return View();
        }

        // POST: Login
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Index(RegisterRequest account)
        {
            /*if( account.Username != null && account.Password != null)
            {
                byte[] salt = Encoding.UTF8.GetBytes(account.Username); ;
                var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: account.Password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));


                account.Password = hashed;
                account.Salt = salt;
                //var loginAccount = from s in _context.Accounts.Where(s => s.Username == account.Username && s.Password == account.Password) select s;
                _context.Add(account);
                await _context.SaveChangesAsync();
                return Redirect("Home");
            }
            ModelState.AddModelError(nameof(account.Password), "Register Failed: Invalid Username or Password");
            return View(account);*/
            String myHostUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            //Console.Write(account);
            string apiUrl = $"{myHostUrl}/api/Users";
            Console.Write(apiUrl);
            string jsonString = JsonSerializer.Serialize(account);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString($"{apiUrl}/Register", jsonString);
            if (json == null)
            {
                return NotFound();
            }
            return Redirect("Home");
            //_userService.Register(account);
            //Ok(new { message = "Registration successful" });
            //return Ok(new { message = "Registration successful" });
            
        }

        /*private bool AccountExists(int id)
        {
          return (_context.Accounts?.Any(e => e.AccountID == id)).GetValueOrDefault();
        }*/
    }


}
