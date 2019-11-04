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
        public int Update(int id, string name, string family)
        {
            int result = dbConnection.Execute("update_person", commandType: CommandType.StoredProcedure, param: new { personId = id, name = name, family = family });

            return result;
        }
        
    }
}
