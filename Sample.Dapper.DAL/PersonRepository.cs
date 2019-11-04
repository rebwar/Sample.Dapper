using Dapper;
using Sample.Dapper.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Sample.Dapper.DAL
{
    public class PersonRepository
    {
        private readonly IDbConnection dbConnection;

        public PersonRepository(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }
        public List<Person> GetPeople()
        {
           var people= dbConnection.Query<Person>("select * from person").ToList();
            return people;
        }
    }
}
