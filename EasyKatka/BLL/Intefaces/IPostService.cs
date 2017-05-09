using BLL.Infrastructure;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface IPostService
    {
        IEnumerable<Post> GetPosts();
        Task CreatePost(Post post);
        Task UpdatePost(Post post);
        Task<OperationDetails> DeletePost(int id, string userId);
        Task PutLike(int id);
        Post GetPostById(int postId);
        IEnumerable<Post> GetPostsFromCategory(int categoryId);
        IEnumerable<Post> GetUserPosts(string userId);
    }
}
