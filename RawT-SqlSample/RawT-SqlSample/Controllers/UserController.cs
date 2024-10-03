using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using RawT_SqlSample.DataAccess;
using System.ComponentModel.DataAnnotations;

namespace RawT_SqlSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context =context;

        [HttpPost]
        public async Task<IActionResult> SignUp([Required]string name, [Required]string phone)
        {
            object[] paramItems =
            [
                new SqlParameter("@name", name),
                new SqlParameter("@phone", phone),
                 new SqlParameter("@IsAuthor", false)
            ];

            await _context.Database.ExecuteSqlRawAsync("INSERT INTO Users(Name,PhoneNumber,IsAuthor) VALUES (@name,@phone,@IsAuthor)", paramItems);

            return (Ok("huum?"));
        }

        [HttpPost("AddToAuthors")]
        public async Task<IActionResult> AddToAuthors([Required]string userId)
        {
            object[] paramItems =
            [
                new SqlParameter("@IsAuthor", true),
                new SqlParameter("@userId", userId)
            ];
            await _context.Database.ExecuteSqlRawAsync("UPDATE Users SET IsAuthor = @IsAuthor WHERE Id = @userId", paramItems);

            return (Ok("huum?"));
        }
    }
}
