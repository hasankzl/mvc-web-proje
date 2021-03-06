using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("BlogUser")]
        public string BlogUserId { get; set; }
        public BlogUser BlogUser { get; set; }
        public string Message { get; set; }
        [ForeignKey("Post")]
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
