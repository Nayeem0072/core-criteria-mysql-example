using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MagicMatter.Models;
using MagicMatter.QueryModels;
using MagicMatter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace MagicMatter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class TestController : ControllerBase
    {
        PostRepository postRepository;
        QueryBuilder queryBuilder;
        QueryRepository queryRepository;

        //[HttpGet("test")]
        //public List<TestTable> Get()
        //{
        //    DBContext context = HttpContext.RequestServices.GetService(typeof(DBContext)) as DBContext;

        //    return context.GetAll();
        //}      
        public TestController (PostRepository postRepository, QueryBuilder queryBuilder, QueryRepository queryRepository)
        {
            this.postRepository = postRepository;
            this.queryBuilder = queryBuilder;
            this.queryRepository = queryRepository;
        }

        [HttpGet("test")]
        public IList<Post> Get()
        {
            return postRepository.GetAll();
        }

        [HttpGet("test2")]
        public object Get1()
        {
            return queryRepository.ExecuteQuery("query1");
        }
    }
}