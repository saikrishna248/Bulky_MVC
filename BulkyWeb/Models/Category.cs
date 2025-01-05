using System.ComponentModel.DataAnnotations;

namespace BulkyWeb.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }     //primary key

        [Required]
        public string Name1 { get; set; }
            
        public int DisplayOrder { get; set; } 

    }
}
