using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Services
{
    internal class Controll
    {
        public static int ChooseUser()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please select what do you want to do:" +
                    "\n1 - Login as administrator" +
                    "\n2 - Login as library user" +
                    "\n0 - Exit");

                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            ManagerMenu();
                            break;
                        case 2:
                            ReaderMenu();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); ;
                }
            } while (choice != 0 && choice != -1);

            return choice;
        }

        public static int ManagerMenu()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please choose what do you want to do: " +
                    "\n1 - Register the new book" +
                    "\n0 - Exit");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Service.CreateBook();
                        break;
                }
            } while (choice != 0 && choice != -1);
            return choice;
        }

        public static int ReaderMenu()
        {
            int choice = -1;
            do
            {
                Console.Clear();
                Title();
                Console.WriteLine("Please choose what do you want to do:" +
                    "\n1 - Find book by title" +
                    "\n2 - Find book by author" +
                    "\n3 - Find book by publisher" +
                    "\n4 - Find book by publishing date" +
                    "\n5 - Find book by genre" +
                    "\n6 - Find book by ISBN code" +
                    "\n7 - Find available books" +
                    "\n8 - Reserve the book" +
                    "\n9 - Return the book" +
                    "\n0 - Exit");
                try
                {
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {

                        case 1:
                            Service.SearchByTitle();
                            break;
                        case 2:
                            Service.SearchByAuthor();
                            break;
                        case 3:
                            Service.SearchByPublisher();
                            break;
                        case 4:
                            Service.SearchByPublishingDate();
                            break;
                        case 5:
                            Service.SearchByGenre();
                            break;
                        case 6:
                            Service.SearchByISBNCode();
                            break;
                        case 7:
                            Service.SearchByStatus();
                            break;
                        case 8:
                            Service.ReserveBook();
                            break;
                        case 9:
                            Service.ReturnBook();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message); 
                }

            } while (choice != 0 && choice != -1);
            return choice;
        }

        public static void Title()
        {
            Console.WriteLine("Library management system");
            Console.WriteLine($"{DateTime.Today}");
        }
    }
}
