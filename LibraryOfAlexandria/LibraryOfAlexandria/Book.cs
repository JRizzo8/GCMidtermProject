using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfAlexandria
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ShelfStatus ShelfStatus { get; set; }
        public List<Book> Inventory { get; set; }
        public DateTime DueDate { get; set; }

        public Book()
        {

        }
        public Book(string Title, string Author, ShelfStatus shelfStatus)
        {
            List<Book> Inventory = new List<Book>();
            Inventory.Add(new Book("Maximum Ride", "James Patterson", ShelfStatus.OnShelf ));
            Inventory.Add(new Book("Clockwork", "Philip Pullman", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Coraline", "Neil Gaiman", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Dream Catcher", "Stephen King", ShelfStatus.OnShelf));
            Inventory.Add(new Book("The Shining", "Stephen King", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Nineteen Eighty-Four", "George Orwell", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Animal Farm", "George Orwell", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Rachael Ray", "30-Minute Meals 2", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Astronomy For the Soul", "Jan Spiller", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Naruto", "Masashi Kishimoto", ShelfStatus.OnShelf));
            Inventory.Add(new Book("Long Walk To Freedom", "Nelson Mandela", ShelfStatus.OnShelf));
            Inventory.Add(new Book("The Lovely Bones", "Alice Sebold", ShelfStatus.OnShelf));
        }
        public List<Book> SearchByAuthor(string authorName)
        {
                List<Book> authorList = new List<Book>();
                foreach (var item in Inventory)
                {
                    if (item.Author == authorName)
                    {
                        authorList.Add(item);
                    }
                }
                return authorList;
        }
        public List<Book> SearchByTitle(string bookTitle)
        {
            List<Book> bookTitleList = new List<Book>();
            foreach (var item in Inventory)
            {
                if (item.Title == bookTitle)
                {
                    bookTitleList.Add(item);
                }
            }
            return bookTitleList;
        }

        public List<Book> DisplayBooks()
        {
            return Inventory;
        }

    }
}
