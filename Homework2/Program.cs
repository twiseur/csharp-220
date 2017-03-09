using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Course: CSHP 220
// Author: Thaddée Wiseur

namespace Homework2
{
    class Program
    {
        static void Main(string[] args)
        {

            // Initialization
            var users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "hello" });
            users.Add(new Models.User { Name = "Steve", Password = "steve" });
            users.Add(new Models.User { Name = "Lisa", Password = "hello" });

            // Homework2.1
            // Display to the console, all the passwords that are "hello".
            // Hint: Where
            Console.WriteLine("H2.1 Displaying all passwords that are \"hello\":");
            var passwords = from user in users
                            where user.Password == "hello"
                            select user.Password;
            Console.WriteLine(string.Join(Environment.NewLine, passwords.ToArray()));
            Console.WriteLine();

            // Homework2.2
            // Delete any passwords that are the lower-cased version of their Name.
            // Do not just look for "steve".It has to be data - driven.Hint: Remove or RemoveAll

            // Note: I assumed you meant Delete any user whose password is the lower-cased version
            // of their Name. Otherwise, the use of Remove or Remove do not seem to make sense.
            users.RemoveAll(user => user.Password == user.Name.ToLower());
            Console.WriteLine("H2.2 Removing any user whose password is a lower-cased version of his name");
            Console.WriteLine();

            // Homework2.3
            // Delete the first User that has the password "hello".
            // Hint: First or FirstOrDefault
            users.Remove(users.FirstOrDefault(user => user.Password == "hello"));
            Console.WriteLine("H2.3 Removing the first user that has \"hello\" as a password");
            Console.WriteLine();

            // Homework2.4
            // Display to the console the remaining users with their Name and Password.
            // Here is the only place you can use a for/foreach loop
            Console.WriteLine("H2.4 Displaying the remaining users and their passwords:");
            foreach (Models.User user in users)
            {
                Console.WriteLine($"User: {user.Name} / Password: {user.Password}");
            }
            Console.ReadLine();








        }
    }
}
