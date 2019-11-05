using MagicMatter.Models;
using MagicMatter.Repositories;
using MagicMatter.Utilities;
using Microsoft.Extensions.Configuration;
using NHibernate;
using NHibernate.Criterion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagicMatter.QueryModels
{
    public class QueryBuilder
    {
        Dictionary<string, SimpleExpression> expressions = new Dictionary<string, SimpleExpression>();
        Dictionary<string, string[]> queries = new Dictionary<string, string[]>();

        public string[] getQuery(string query)
        {
            return this.queries.FirstOrDefault(x => x.Key == query).Value; 
        }

        public SimpleExpression getExpression(string expName)
        {
            return this.expressions.FirstOrDefault(x => x.Key == expName).Value;
        }

        public QueryBuilder(IConfiguration configuration) 
        {
            Dictionary<string, string[]> expressions = configuration
                .GetSection("QueryGen")
                .GetSection("Expression")
                .Get<Dictionary<string, string[]>>();

            Dictionary<string, string[]> queries = configuration
                .GetSection("QueryGen")
                .GetSection("Query")
                .Get<Dictionary<string, string[]>>();

            buildExpressions(expressions);
            //buildQueries(queries);
        }        

        //private void buildQueries(Dictionary<string, string[]> queries)
        //{
        //    using (var session = OpenSession())
        //    {
        //        foreach (var q in queries)
        //        {
        //            SimpleExpression se = this.expressions.FirstOrDefault(x => x.Key == q.Value[1]).Value;
        //            ICriteria c = session.CreateCriteria<Post>().Add(se);
        //            //this.queryList.Add(q.Key, c);

        //            IList<Post> l1 = c.List<Post>();
        //        }
        //    }
        //}

        public void buildExpressions(Dictionary<string, string[]> expressions)
        {
            foreach (var e in expressions)
            {
                if (e.Value != null || e.Value.Length < 1)
                {
                    buildEquals(e.Key, e.Value);
                }
            }

        }

        private void buildEquals(string key, string[] val)
        {
            if (val[0] == "eq")
            {
                if (val.Length == 3)
                {
                    SimpleExpression se = Restrictions.Eq(val[1], Int32.Parse(val[2]));
                    this.expressions.Add(key, se);
                }

            }
        }

        public void getExp()
        {
            
        }
    }
}
