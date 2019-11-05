using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicMatter.Models
{
    public class Post
    {
        public virtual int Id { get; set; }
        public virtual string PostAuthor { get; set; }
    }
}
