using System.ComponentModel.DataAnnotations;


namespace PostApi.DTOs
{
    public class UpdatePostDto
    {
        [Required]
        public string Text { get; set; }
    }
}