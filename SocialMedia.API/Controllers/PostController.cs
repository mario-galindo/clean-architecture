using Microsoft.AspNetCore.Mvc;
using SocialMedia.Infrastructure.Repositories;

namespace SocialMedia.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostController : ControllerBase
    {
        public IActionResult GetPosts()
        {

            var posts = new PostRepository().GetPosts();

            return Ok(posts);
        }
    }
}
