using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using WebPublisher.Dtos;

namespace WebPublisher.Controllers
{
    [Route("api/[controller]")]
    public class PublishController : Controller
    {

        private readonly ICapPublisher _publisher;
        private MYDbContext _dbContext;
        public PublishController(ICapPublisher publisher, MYDbContext dbContext)
        {
            _dbContext = dbContext;
            _publisher = publisher;
        }
        // GET api/values
        [HttpGet]
        public  IActionResult Get()
        {
            using (var trans = _dbContext.Database.BeginTransaction())
            {
                // your business code

                //If you are using EF, CAP will automatic discovery current environment transaction, so you do not need to explicit pass parameters.
                //Achieving atomicity between original database operation and the publish event log thanks to a local transaction.
                _publisher.Publish("xxx.services.account.check", new Person { Name = "Foo", Age = 11 });
                trans.Commit();
            }
            //string connectionString = "Server=192.168.11.83;Database=finbook_metadata;Uid=root;Pwd=root";// Encrypt=true";
            //using (var sqlConnection = new MySqlConnection(connectionString))
            //{
            //    sqlConnection.Open();
            //    using (var transaction = sqlConnection.BeginTransaction())
            //    {
            //        await _publisher.PublishAsync("xxx.services.account.check", new Person { Name = "cc", Age = 12 });
            //        transaction.Commit();
            //    }
            //}


            return Ok();
        }


    }

}
