using System.ComponentModel.DataAnnotations.Schema;


namespace PostApi.Models
{
    [Table("Attachments")]

    public class Attachment
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid PostId { get; set; }
        public Post Post { get; set; }
    }
}