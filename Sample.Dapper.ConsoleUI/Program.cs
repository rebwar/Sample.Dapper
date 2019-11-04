using Sample.Dapper.DAL;
using System;
using System.Data.SqlClient;

namespace Sample.Dapper.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=DapperSampleDb;integrated security=true");
            var repo = new PersonRepository(conn);
            var people = repo.GetPeople();
            foreach (var item in people)
            {
                Console.WriteLine($"Id={item.PersonId} \t Name={item.Name} \t Family={item.Family}");
            }
            Console.ReadLine();
        }
    }
}
