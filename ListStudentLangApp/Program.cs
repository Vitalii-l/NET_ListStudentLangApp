using System;
using System.Collections.Generic;
using System.Linq;

namespace ListStudentLangApp
{
    class Program
    {

        class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public List<string> Languages { get; set; }
            public User()
            {
                Languages = new List<string>();
            }
        }

        static void Main(string[] args)
        {
            List<User> users = new List<User>
            {
                new User { Name = "Ivan", Age = 23, Languages = new List<string> { "english", "german" } },
                new User { Name = "Alex", Age = 27, Languages = new List<string> { "english", "french" } },
                new User { Name = "Maria", Age = 29, Languages = new List<string> { "english", "spanish" } },
                new User { Name = "Jelena", Age = 34, Languages = new List<string> { "spanish", "english" } },
            };

            // Список всех студентов
            var selectedPerson = from user in users select user;
            Console.WriteLine("Students list\n");
            Console.WriteLine("Name \t \tAge \tLanguage1 \tLanguage2");
            foreach (User user in selectedPerson)
            {
                Console.WriteLine($"{user.Name} \t- \t{user.Age} \t{user.Languages[0]} - \t{user.Languages[1]}");
            }

            // ----------------- Список студентов, изучающих english и старше 25 лет
            var selectedUsers = from user in users
                                from lang in user.Languages
                                where user.Age > 25
                                where lang == "english"
                                select user;
            Console.WriteLine("\n\nStudents list (English)");
            Console.WriteLine("\nName \t \tAge \tLanguage1 \tLanguage2");
            foreach (User user in selectedUsers)
            {
                Console.Write($"{user.Name} \t- \t{user.Age} ");
                foreach (var lang in user.Languages)
                {
                    Console.Write($"\t{lang}\t");
                }
                Console.WriteLine("");
            }
            Console.Write("\n\nPress any key...");
            Console.ReadKey();

        }
    }
}
