using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class Category
    {

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Display Order")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Hata MaxSize")]
        public int DisplayOrder { get; set; }
        [ForeignKey("CategoryId")]
        public ICollection<Post> Posts { get; set; }
    }
}
