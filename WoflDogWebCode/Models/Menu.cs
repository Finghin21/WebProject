using System.ComponentModel.DataAnnotations;

namespace WoflDogWebCode.Models
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Href { get; set; }

        public string Icon { get; set; }

        public int? ParentId { get; set; }
    }
}
