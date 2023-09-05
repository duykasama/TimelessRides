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
        public async Task<IActionResult> GetPosts(int pageSize, int offset)
        {
            var result = await _postService.GetPostsAsync(pageSize, offset);
            return Ok(result);
        }

        [HttpGet]
        [Route("prioritized")]
        public async Task<IActionResult> GetPrioritizedPosts()
        {
            var result = await _postService.GetPrioritizedPostsAsync(9);
            return Ok(result);
        }

        [HttpGet]
        [Route("last-page")]
        public async Task<IActionResult> GetLastPage(int pageSize)
        {
            return Ok(Math.Ceiling(await _postService.GetLastPage() / (decimal)pageSize));
        }
    }
}
