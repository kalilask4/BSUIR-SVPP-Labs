using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace WPF_Laba7_test2
{
    class Person
    {

        static SqlConnection connection;

        public int PersonId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Company { get; set; }
        public decimal Salary { get; set; }

        public static void newConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            connection = new SqlConnection(connString);
            connection.Open();
        }

        public static IEnumerable<Person> getAllPersons()
        {
            newConnection();
            var commandString = "SELECT * FROM Person";
            SqlCommand getAllCommand = new SqlCommand(commandString, connection);
            var reader = getAllCommand.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    var id = reader.GetInt32(0);
                    var name = reader.GetString(1);
                    var age = reader.GetInt32(2);
                    var comapany = reader.GetString(3);
                    var salary = reader.GetDecimal(4);
                    var person = new Person
                    {
                        PersonId = id,
                        Name = name,
                        Age = age,
                        Company = comapany,
                        Salary = salary
                    };
                    yield return person;
                }          
            }
            connection.Close();
        }

        public override string ToString()
        {
            return $"{PersonId} {Name}, {Age} years old. Company is {Company}, {Salary}" ;
        }
    }


    
}
