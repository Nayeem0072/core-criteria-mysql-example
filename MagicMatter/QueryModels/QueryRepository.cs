using MagicMatter.Models;
using MagicMatter.Repositories;
using MagicMatter.Utilities;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicMatter.QueryModels
{
    public class QueryRepository: BaseRepository
    {
        QueryBuilder queryBuilder;
        private object expressions;

        public QueryRepository(NHibernateHelper nHibernateHelper, QueryBuilder queryBuilder) 
            : base(nHibernateHelper)
        {
            this.queryBuilder = queryBuilder;
        }

        public Object ExecuteQuery(string queryName)
        {
            string[] s = queryBuilder.getQuery(queryName);

            if(s != null && s.Length > 0)
            {
                using (var session = OpenSession())
                {
                    ICriteria c = session.CreateCriteria<Post>();
                    for (int i = 1; i < s.Length; i++)
                    {
                        SimpleExpression se = queryBuilder.getExpression(s[i]);
                        c = c.Add(se);
                    }

                    return c.List<Post>();
                }
            }

            return null;
        }
    }
}
