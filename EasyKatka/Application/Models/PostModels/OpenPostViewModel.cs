using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Models.PostModels
{
    public class OpenPostViewModel
    {
        public int PostId { get; set; }
        public PostViewModel PostViewModel { get; set; }
        public IList<CommentViewModel> CommentsViewModel { get; set; } 
        [StringLength(200, ErrorMessage = "Сообщение должно быть больше 3 и боьше символов", MinimumLength = 3)]
        public string CommentText { get; set; }
    }
}