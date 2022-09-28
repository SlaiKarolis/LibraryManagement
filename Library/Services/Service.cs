using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Model;

namespace Library.Services
{
    internal class Service
    {
        public static void SearchByTitle()
        {
            Console.WriteLine("Please enter the title of book:");
            var search = ReadString();
            BookList(GetBooksList().Where(b => b.Title.Contains(search)).ToList());
        }

        public static void SearchByAuthor()
        {
            Console.WriteLine("Please enter the author of book:");
            var search = ReadString();
            BookList(GetBooksList().Where(b => b.Author.Contains(search)).ToList());
        }

        public static void SearchByPublisher()
        {
            Console.WriteLine("Please enter the publisher of book:");
            var search = ReadString();
            BookList(GetBooksList().Where(b => b.Publisher.Contains(search)).ToList());
        }

        public static void SearchByPublishingDate()
        {
            Console.WriteLine("Please enter the year of publishing:");
            var search = ReadDate();
            BookList(GetBooksList().Where(b =>( b.PublishingDate == search)).ToList());
        }

        public static void SearchByGenre()
        {
            Console.WriteLine("Please enter the genre of book:");
            var search = ReadString();
            BookList(GetBooksList().Where(b => b.Genre.Contains(search)).ToList());
        }
        public static void SearchByISBNCode()
        {
            Console.WriteLine("Please enter the ISBN code of book:");
            var search = ReadString();
            BookList(GetBooksList().Where(b => b.ISBNCode.Contains(search)).ToList());
        }

        public static void SearchByStatus()
        {
            Console.WriteLine("The list of available books:");
            BookList(GetBooksList().Where(b => b.Quantity > 0).ToList());
        }
        
        public static void ReserveBook()
        {
            Console.WriteLine("Please enter the ISBN code of book you want to reserve:");
            var input = ReadString();
            var bookList = new FileReader().GetFileData();
            var book = GetBooksList().FirstOrDefault(b => b.ISBNCode == input);

            if (book.Quantity >= 1)
            {
                book.Quantity--;
                bookList.Remove(bookList.FirstOrDefault(b => b.ISBNCode == input));
                bookList.Add(book);
                var writeStream = new FileWriter();
                writeStream.WriteToFile(bookList);
                Console.WriteLine($"Thank you for reservation of {book.Title}. Press any key.");
            }
            else
            {
                Console.WriteLine("All of this books are reserved, please try later! Press any key.");
            }
            Console.ReadLine();
        }

        public static void ReturnBook()
        {
            Console.WriteLine("Please enter the ISBN code of book you want to return:");
            var input = ReadString();
            var bookList = new FileReader().GetFileData();
            var book = GetBooksList().FirstOrDefault(b => b.ISBNCode == input);

            if (book != null)
            {
                book.Quantity++;
                bookList.Remove(bookList.FirstOrDefault(b => b.ISBNCode == input));
                bookList.Add(book);
                var writeStream = new FileWriter();
                writeStream.WriteToFile(bookList);
                Console.WriteLine($"Thank you for returning book {book.Title}. Press any key.");
            }
            else
            {
                Console.WriteLine("Please make sure that you entered correct ISBN number!.");
            }

            Console.ReadLine();
        }

        
        public static void CreateBook()
        {
            var book = Book.CreateNewbook();
            var bookList = GetBooksList();
            if (bookList is null)
            {
                bookList = new List<Book>();
            }
            bookList.Add(book);
            var streamWrite = new FileWriter();
            streamWrite.WriteToFile(bookList);
            Console.WriteLine("The book was added! Press any key.");
            Console.ReadLine();
        }

        public static void BookList(List<Book> booksList)
        {
            if (booksList is not null && booksList.Count > 0)
            {
                foreach (Book book in booksList)
                {
                    Console.WriteLine(book);
                }
                Console.WriteLine("Press any key.");
            }
            else
            {
                Console.WriteLine("Book list is empty! Press any key.");
            }
            Console.ReadLine();
        }
        public static List<Book> GetBooksList()
        {
            return new FileReader().GetFileData();
        }
        public static string ReadString()
        {
            do
            {
                try
                {
                    var inputString = Console.ReadLine();
                    if (inputString.Length > 0)
                    {
                        return inputString;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Write("Wrong input! try again: ");
            }
            while (true);
        }
        public static int ReadInteger()
        {
            do
            {
                try
                {
                    return int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.Write("Wrong input! try again: ");
            }
            while (true);
        }
        public static string ReadTitle()
        {
            Console.WriteLine("Please enter book title:");
            return ReadString();
        }

        public static string ReadAuthor()
        {
            Console.WriteLine("Please enter book Author:");
            return ReadString();
        }
        public static string ReadPublisher()
        {
            Console.WriteLine("Please enter book publisher:");
            return ReadString();
        }

        public static DateTime ReadPublishDate()
        {
            Console.WriteLine("Please enter book publish date:");
            return ReadDate();
        }
        public static string ReadGenre()
        {
            Console.WriteLine("Please enter book genre:");
            return ReadString();
        }

        public static string ReadISBNcode()
        {
            Console.WriteLine("Please enter book ISBN code:");
            return ReadString();
        }
        public static int ReadQuantity()
        {
            Console.WriteLine("Please enter quantity of books:");
            return ReadInteger();
        }
        
        public static DateTime ReadDate()
        {
            DateTime dateOnly;
            do
            {
                try
                {
                    dateOnly = DateTime.Parse(Console.ReadLine());
                    break;
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message) ;
                }
            } while (true);
            return dateOnly;
        }

    }
}
