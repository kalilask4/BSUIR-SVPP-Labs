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
            var reader = getAllCommand.ExecuteReader();    //запрос возвращает данные
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

        public static Person Find(string name)
        {
            foreach(var person in getAllPersons())
            {
                if (person.Name == name)
                    return person;
            }
            return null;
        }

        public static void Delete(int id)
        {
            newConnection();
            var commandString = "DELETE FROM Person WHERE (PersonId=@id)";
            SqlCommand deleteCommand = new SqlCommand(commandString, connection);
            deleteCommand.Parameters.AddWithValue("id", id);
            deleteCommand.ExecuteNonQuery(); //запрос выполняется не возвращая данные
            connection.Close();
        }

        public void Insert()
        {
            newConnection();
            var commandString = "INSERT INTO Person(Name, Age, Company, Salary) values(@name, @age, @Company, @Salary )";
            SqlCommand insertCommand = new SqlCommand(commandString, connection);
            insertCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("Name", Name),
                    new SqlParameter("Age", Age),
                    new SqlParameter("Company", Company),
                    new SqlParameter("Salary", Salary),
                });
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void Update()
        {
            newConnection();
            var commandString = "UPDATE Person SET Name=@name, Age=@age, Company=@company, Salary=@salary " +
                "WHERE (PersonId=@id)";
            SqlCommand updateCommand = new SqlCommand(commandString, connection);
            updateCommand.Parameters.AddRange(new SqlParameter[]
                {
                    new SqlParameter("id", PersonId),
                    new SqlParameter("Name", Name),
                    new SqlParameter("Age", Age),
                    new SqlParameter("Company", Company),
                    new SqlParameter("Salary", Salary),
                });
            updateCommand.ExecuteNonQuery();
            connection.Close();
        }

        public void updatePerson(Person personNew)
        {
            if (personNew.Name?.Length > 0) Name = personNew.Name;
            if (personNew.Age > 0) Age = personNew.Age;
            if (personNew.Company?.Length > 0) Company = personNew.Company;
            if (personNew.Salary > 0) Salary  = personNew.Salary;
        }

        public override string ToString()
        {
            return $"{PersonId} {Name}, {Age} years old. Company is {Company} (${Salary})";
        }
    }


    
}
