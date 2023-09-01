using Microsoft.AspNetCore.Mvc;
using OldCarShowroom.Service.Services.Interfaces;

namespace OldCarShowroom.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PostsController : Controller
    {
        private readonly IPostService _postService;

        public PostsController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetPosts()
        {
            var result = await _postService.GetPostsAsync();
            return Ok(result);
        }

        [HttpGet]
        [Route("prioritized")]
        public async Task<IActionResult> GetPrioritizedPosts()
        {
            var result = await _postService.GetPrioritizedPostsAsync(10);
            return Ok(result);
        }
    }
}
