using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using NuGet.Protocol.Plugins;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.Text.Encodings;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Net;
using System.Text.Json;
using ContosoUniversity.Models;
using ContosoUniversity.Services;
using ContosoUniversity.Authorization;


namespace ContosoUniversity.Controllers
{
    //[ApiController]
    //[Route("[controller]")]
    public class LoginController : Controller
    {

        /*private IAccountService _accountService;

        public LoginController(IAccountService userService)
        {
            _accountService = userService;
        }*/

        private IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        //[HttpGet("Authenticate")]
        [HttpGet]
        public IActionResult Authenticate()
        {
            return View();
        }

        // POST: Login
        //[HttpPost("Authenticate")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate(AuthenticateRequest account)
        {
            /*if (account.Username != null && account.Password != null)
            {
                //var loginAccount = from s in _context.Accounts.Where(s => s.Username == account.Username) select s;
                var conn = new SqlConnection("Server=HOANG-ANH-VU;Database=TutorialDb;Trusted_Connection=True;MultipleActiveResultSets=true;TrustServerCertificate=true");
                conn.Open();

                SqlCommand cmd2 = new SqlCommand("SELECT Password FROM dbo.Accounts WHERE Username='" + account.Username + "';", conn);
                string stringPass = (String)cmd2.ExecuteScalar();


                byte[] salt= Encoding.UTF8.GetBytes(account.Username);
                Console.WriteLine($"Salt: {Convert.ToBase64String(salt)}");

                var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                    password: account.Password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8));


                if (hashed==stringPass)
                {
                    //var response= _accountService.Authenticate(account);
                    return Redirect("Home");
                }
                ModelState.AddModelError(nameof(account.Password), "Login Failed: Invalid Username or Password");

            }
            return View(account);*/
            String myHostUrl = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}";
            //Console.Write(account);
            string apiUrl = $"{myHostUrl}/api/Users";
            Console.Write(apiUrl);
            string jsonString = JsonSerializer.Serialize(account);
            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString($"{apiUrl}/Authenticate", jsonString);
            if (json == null)
            {
                return NotFound();
            }
            //return Ok(new { message = "Registration successful" });
            return RedirectToAction("Index","Home");
        }

        private string ipAddress()
        {
            // get source ip address for the current request
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
        /*private bool LoginExists(int id)
        {
            return (_context.Accounts?.Any(e => e.AccountID == id)).GetValueOrDefault();
        }*/
    }
}
