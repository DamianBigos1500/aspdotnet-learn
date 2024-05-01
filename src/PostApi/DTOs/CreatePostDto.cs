using System.ComponentModel.DataAnnotations;


namespace PostApi.DTOs
{
    public class CreatePostDto
    {
        [Required]
        public string Text { get; set; }
    }
}