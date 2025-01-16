using JsonSample.DataAccess;
using JsonSample.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR.Protocol;
using Microsoft.EntityFrameworkCore;

namespace JsonSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GeneralController(DataContext context) : ControllerBase
    {
        private readonly DataContext _context = context;

        [HttpPost("createuser")]
        public async Task<IActionResult> CreateUser(string name)
        {

            User user = new() { Name = name, Articles = [] };

            await _context.Users.AddAsync(user);

            await _context.SaveChangesAsync();

            return Ok(user.Id);
        }

        [HttpPost("createarticle")]
        public async Task<IActionResult> CreateArticle(string title, string content, string userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id.Equals(int.Parse(userId)));

            Article article = new() { Id = Guid.NewGuid(), Title = title, Content = content, Comments = [] };

            user.Articles.Add(article);

            await _context.SaveChangesAsync();

            return Ok(article.Id.ToString());
        }

        [HttpPost("createcomment")]
        public async Task<IActionResult> CreateComment(string content, string articleId, string userId)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Id.Equals(int.Parse(userId)));

            var article = user.Articles.FirstOrDefault(a => a.Id.ToString().Equals(articleId));

            article.Comments.Add(new Comment { Content = content });

            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("GetUser")]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id.Equals(int.Parse(userId)));

            return Ok(user);
        }
    }
}
