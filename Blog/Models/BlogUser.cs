using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class BlogUser:IdentityUser
    {

   public string Name { get; set; }
   public ICollection<Comment> Commnets{ get; set; }
    }
}
