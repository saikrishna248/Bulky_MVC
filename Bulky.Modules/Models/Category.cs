using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models.Models
{
    public class Category
    {
        [Key]
        public int ID { get; set; }     //primary key

        [Required]
        [DisplayName("Category Name")] //display name for Name1
        [MaxLength(30)]
        public string Name1 { get; set; }

        [DisplayName("Display Order")] //display name for DisplayOrder
        [Range (1,100,ErrorMessage = "Display Order should be between 1 and 100.")]  //Giving range and custom message added                          
        public int DisplayOrder { get; set; } 

    }
}
