using System.ComponentModel.DataAnnotations;

namespace WoflDogWebCode.Models
{
    public class Recommendation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Href { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
