using MagicMatter.Utilities;
using NHibernate;

namespace MagicMatter.Repositories
{
    public class BaseRepository
    {
        protected NHibernateHelper NhibernateHelper;

        public BaseRepository(
            NHibernateHelper nHibernateHelper
        )
        {
            NhibernateHelper = nHibernateHelper;
        }

        public virtual ISession OpenSession()
        {
            return NhibernateHelper.OpenSession();
        }
    }
}
