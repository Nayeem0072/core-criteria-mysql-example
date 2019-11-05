using MagicMatter.Models;
using MagicMatter.Utilities;
using NHibernate.Criterion;
using System.Collections.Generic;

namespace MagicMatter.Repositories
{
    public class PostRepository: BaseRepository
    {
        public PostRepository(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {

        }

        public IList<Post> GetAll()
        {
            using (var session = OpenSession())
            {
                //return session.Query<Post>().ToList();
                var post = session.CreateCriteria<Post>()
                    .Add(Restrictions.Like("PostAuthor", "n%"))
                    .Add(
                    Restrictions.Or(
                        Restrictions.Eq("Id", 1),
                        Restrictions.Eq("Id", 4)
                    )).List<Post>(); 
                return post;
            }
        }
    }
}
