using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Post
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("Category")]
        [Required]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [MinLength(100)]
        public string Body { get; set; }

        [Required]
        public String Image { get; set; }
        public  ICollection<Comment> Comments { get; set; }
    }
}
