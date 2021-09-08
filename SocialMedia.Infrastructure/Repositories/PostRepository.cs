using System.Collections.Generic;
using SocialMedia.Core.Entities;
using SocialMedia.Core.Interfaces;
using System.Threading.Tasks;
using SocialMedia.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace SocialMedia.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly SocialMediaContext _socialMediaContext;
        public PostRepository(SocialMediaContext socialMediaContext)
        {
            _socialMediaContext = socialMediaContext;
        }
        public async Task<IEnumerable<Post>> GetPosts()
        {
            var posts = await _socialMediaContext.Posts.ToListAsync();
            return posts;
        }

        public async Task<Post> GetPost(int id)
        {
            var post = await _socialMediaContext.Posts
                .FirstOrDefaultAsync(x => x.PostId == id);
            return post;
        }

    }
}