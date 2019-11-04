using Sample.Dapper.DAL;
using System;
using System.Data.SqlClient;

namespace Sample.Dapper.ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            InsertPerson();
            ShowAllPeople();

            //Updatepeople();
        }

        private static void InsertPerson()
        {
            var conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=DapperSampleDb;integrated security=true");
            var repo = new PersonRepository(conn);
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Family=");
            string family = Console.ReadLine();
            int result = repo.Insert(name, family);
        }

        private static void Updatepeople()
        {
            var conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=DapperSampleDb;integrated security=true");
            var repo = new PersonRepository(conn);
            Console.Write("Enter Person Id:");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Name:");
            string name = Console.ReadLine();
            Console.Write("Family=");
            string family = Console.ReadLine();
            int result=repo.Update(id,name,family);
            if(result!=-1)
            {
                Console.WriteLine("********************************");
                ShowAllPeople();
            }
            else
            {
                Console.WriteLine("Oops Problem occurs!");
            }
        }

        private static void ShowAllPeople()
        {
            var conn = new SqlConnection(@"server=(localdb)\MSSQLLocalDB;initial catalog=DapperSampleDb;integrated security=true");
            var repo = new PersonRepository(conn);
            var people = repo.GetPeople();
            foreach (var item in people)
            {
                Console.WriteLine($"Id={item.Id} \t Name={item.Name} \t Family={item.Family}");
            }
            Console.ReadLine();
        }
    }
}
