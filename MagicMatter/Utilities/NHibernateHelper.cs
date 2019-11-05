using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using MagicMatter.Models.Mappings;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace MagicMatter.Utilities
{
    public class NHibernateHelper
    {
        private readonly string _connectionString;
        private readonly object _lockObject = new object();
        private ISessionFactory _sessionFactory;

        public NHibernateHelper(IConfiguration configuration)
        {
            _connectionString = configuration["ConnectionString"];
        }

        private ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    CreateSessionFactory();
                }

                return _sessionFactory;
            }
        }

        public ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }

        private void CreateSessionFactory()
        {
            lock (_lockObject)
            {
                var fluentConfiguration = Fluently.Configure()
                    .Database(
                        MySQLConfiguration.Standard.ConnectionString(_connectionString)
                    //.ShowSql()
                    )
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<PostMap>());

                _sessionFactory = fluentConfiguration.BuildSessionFactory();
            }
        }
    }
}
