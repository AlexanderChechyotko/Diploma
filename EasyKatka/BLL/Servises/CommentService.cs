using BLL.Intefaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using BLL.DTO;
using BLL.Infrastructure;

namespace BLL.Servises
{
    public class CommentService : ICommentService
    {
        private IUnitOfWork _uow;

        public CommentService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<OperationDetails> AddComment(CommentDTO commentDTO)
        {
            Comment comment = new Comment
            {
                Text = commentDTO.Text,
                PostId = commentDTO.PostId,
                UserId = commentDTO.UserId
            };
            try
            {
                _uow.Comments.Create(comment);
            }
            catch
            {
                return new OperationDetails(false, "Произошла ошибка", "comment");
            }
            await _uow.SaveAsync();

            return new OperationDetails(true, "Комментарий успешно добавлен", "comment");
        }

        public IEnumerable<Comment> GetComments()
        {
            return _uow.Comments.GetAll().ToArray();
        }

        public IEnumerable<Comment> GetCommentsByPostId(int postId)
        {
            return _uow.Comments.GetAll()
                .Where(p => p.PostId == postId).ToArray();
        }
    }
}
