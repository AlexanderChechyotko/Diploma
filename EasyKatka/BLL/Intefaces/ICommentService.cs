using BLL.DTO;
using BLL.Infrastructure;
using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Intefaces
{
    public interface ICommentService
    {
        IEnumerable<Comment> GetComments();
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        Task<OperationDetails> AddComment(CommentDTO commentDTO);
    }
}
