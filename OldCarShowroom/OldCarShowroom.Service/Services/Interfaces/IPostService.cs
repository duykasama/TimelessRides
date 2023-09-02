using OldCarShowroom.Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldCarShowroom.Service.Services.Interfaces
{
    public interface IPostService
    {
        Task<IEnumerable<Post>> GetPostsAsync(int pageSize, int offset);
        Task<Post?> GetPostByIdAsync(string id);
        Task<IEnumerable<Post>> GetPostsByClientAsync(Client client);
        Task<IEnumerable<Post>> GetPrioritizedPostsAsync(int count);
    }
}
