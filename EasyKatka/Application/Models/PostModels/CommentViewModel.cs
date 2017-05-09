namespace Application.Models.PostModels
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public int PostId { get; set; }
    }
}