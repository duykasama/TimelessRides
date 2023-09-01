using Microsoft.EntityFrameworkCore;
using OldCarShowroom.Service.Models;
using OldCarShowroom.Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCarShowroom.Service.Services
{
    public class PostService : IPostService
    {
        private readonly OldCarShowroomContext _context;

        public PostService(OldCarShowroomContext context)
        {
            _context = context;
        }

        public async Task<Post?> GetPostByIdAsync(string id) => await _context.Posts.FindAsync(id);

        public async Task<IEnumerable<Post>> GetPostsAsync() => await _context.Posts.ToListAsync();

        public async Task<IEnumerable<Post>> GetPostsByClientAsync(Client client) => await _context.Posts.Where(p => p.ClientId == client.Id).ToListAsync();

        public async Task<IEnumerable<Post>> GetPrioritizedPostsAsync(int count) => await _context.Posts
            .OrderByDescending(p => p.Priority)
            .Take(count)
            .ToListAsync();
    }
}
