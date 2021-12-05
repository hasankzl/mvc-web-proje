using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Models
{
    public class Post
    {

        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Body { get; set; }

        public String Image { get; set; }
        public  ICollection<Comment> Comments { get; set; }
    }
}
