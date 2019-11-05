using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicMatter.Models.Mappings
{
    public class PostMap : ClassMap<Post>
    {
        public PostMap()
        {
            Table("wp_posts");
            LazyLoad();
            Id(x => x.Id).GeneratedBy.Identity().Column("ID");
            Map(x => x.PostAuthor).Column("post_author");
        }
    }
}
