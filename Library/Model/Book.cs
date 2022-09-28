using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Services;

namespace Library.Model
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishingDate { get; set; }
        public string Genre { get; set; }
        public string ISBNCode { get; set; }
        public int Quantity  {get; set;}


        public Book(string title, string author, string publisher, DateTime publishingDate, string genre, string ISBNcode, int quantity)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            PublishingDate = publishingDate;
            Genre = genre;
            ISBNCode = ISBNcode;
            Quantity = quantity;

        }

        public static Book CreateNewbook()
        {
            var title = Service.ReadTitle();
            var author = Service.ReadAuthor();
            var publisher = Service.ReadPublisher();
            var publishingDate = Service.ReadPublishDate();
            var genre = Service.ReadGenre();
            var ISBNcode = Service.ReadISBNcode();
            var quantity = Service.ReadQuantity();


            var book = new Book(title, author, publisher, publishingDate, genre, ISBNcode, quantity);
            return book;
        }

        public override string ToString()
        {
            return $"Book: {Title}. Author: {Author}. Publisher: {Publisher}. Genre: {Genre}. ISBN code: {ISBNCode}. Quantity {Quantity}";
        }
    }
}
