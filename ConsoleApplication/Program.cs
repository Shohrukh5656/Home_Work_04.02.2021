using System;
using System.Data;
using System.Data.SqlClient;


namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            const string Stringconnection = @"Data source=DESKTOP-4HBI2PP\SQLEXPRESS; initial catalog=MSSq; Integrated Security=True";
            SqlConnection connections = new SqlConnection(Stringconnection);



            connections.Open();
            string SqlInformation = $"insert into Person([LastName],[FirstName],[MiddleName], [BirthDate]) values ('Bobojon', 'Qurbonov', 'Kamolovich', '1985-12-31')";
            if (connections.State == ConnectionState.Open)
            {
                Console.WriteLine("Connected Successfuly ");
            }
            int numeric;
            Console.WriteLine("1.Insert (Добавление)");
            Console.WriteLine("2.Select All(Выбрать всё)");
            Console.WriteLine("3.Select by Id (Выбрать один по Id)");
            Console.WriteLine("4.Update (Обновить каждый столбец кроме Id)");
            Console.WriteLine("5.Delete (Удалить один по Id)");
            Console.Write("Введите число: ");
            numeric = Convert.ToInt32(Console.ReadLine());
            SqlCommand commands = connections.CreateCommand();

            if (numeric == 2)
            {
                commands.CommandText = "Select * from Person";
                var reander = commands.ExecuteReader();
                while (reander.Read())
                {

                    Console.WriteLine($"Id: {reander["ID"]}");
                    Console.WriteLine($"Name: {reander["FirstName"]}");
                    Console.WriteLine($"Lastname: {reander["LastName"]}");
                    Console.WriteLine($"MiddleName: {reander["MiddleName"]}");
                    Console.WriteLine($"Date of Birth: {reander["BirthDate"]}");
                }

            }
            if (numeric == 3)
            {
                int id;
                Console.Write("Введите ID = ");
                id = Convert.ToInt32(Console.ReadLine());
                commands.CommandText = $"Select *from Person where Id = {id}";

                var reander = commands.ExecuteReader();
                while (reander.Read())
                {

                    Console.WriteLine($"Id: {reander["ID"]}");
                    Console.WriteLine($"Name: {reander["FirstName"]}");
                    Console.WriteLine($"Lastname: {reander["LastName"]}");
                    Console.WriteLine($"MiddleName: {reander["MiddleName"]}");
                    Console.WriteLine($"Date of Birth: {reander["BirthDate"]}");
                }

            }
            if (numeric == 4)
            {
                int idselect = 0;
                Console.Write("Введите ID = ");
                idselect = Convert.ToInt32(Console.ReadLine());
                string UpdateName;
                Console.Write("Изменить имя = ");
                UpdateName = Console.ReadLine();
                string UpdateSurname;
                Console.Write("Изменить фамилию = ");
                UpdateSurname = Console.ReadLine();
                string UpdateMiddlename;
                Console.Write("Изменить отчество = ");
                UpdateMiddlename = Console.ReadLine();
                string UpdateBirthDate;
                Console.Write("Изменить дату рождения = ");
                UpdateBirthDate = Console.ReadLine();
                commands.CommandText = "update person set " + "FirstName = " + $"'{UpdateName}'," + "LastName = " + $"'{UpdateSurname}'," + "MiddleName = " + $"'{UpdateMiddlename}'," + "BirthDate = " + $"'{UpdateBirthDate} '" + "where Id = " + $"'{idselect}'";

                var reander = commands.ExecuteReader();
                while (reander.Read())
                {

                    Console.WriteLine($"Id: {reander["ID"]}");
                    Console.WriteLine($"Name: {reander["FirstName"]}");
                    Console.WriteLine($"Lastname: {reander["LastName"]}");
                    Console.WriteLine($"MiddleName: {reander["MiddleName"]}");
                    Console.WriteLine($"Date of Birth: {reander["BirthDate"]}");
                }
                Console.WriteLine("Seccessfully uploaded information!");
            }
            if (numeric == 5)
            {
                Console.Write("Введите ID человека которого вы хотите удалить: ");
                int id = int.Parse(Console.ReadLine());

                commands.CommandText = $"Delete Person where ID = {id}";
                int result = commands.ExecuteNonQuery();
                if (result > 0)
                {
                    Console.WriteLine("Seccessfully deleted the person under ID = " + id);
                }
            }
            if (numeric == 1)
            {
                Console.Write("Name = ");
                string FirstName = Console.ReadLine();
                Console.Write("Surname = ");
                string LastName = Console.ReadLine();
                Console.Write("MiddleName = ");
                string MiddleName = Console.ReadLine();
                Console.Write("Date of Birth = ");
                string BirthDate = Console.ReadLine();
                string SqlInsert = $"Insert into Person ([LastName],[FirstName],[MiddleName], [BirthDate]) values ('{LastName}', '{FirstName}', '{MiddleName}', '{BirthDate}')";
                using (SqlConnection connections1 = new SqlConnection(Stringconnection))
                {
                    SqlCommand commands1 = new SqlCommand(SqlInsert, connections);
                    int numerices = commands1.ExecuteNonQuery();
                    Console.WriteLine($"Добывлены новые данные: {numerices}");

                }

            }
        }
    }
}