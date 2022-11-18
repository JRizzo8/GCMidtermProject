using System.Runtime.CompilerServices;

namespace LibraryOfAlexandria
{
    public class Library
    {
    
        public List<Book> Books { get; set; } = new List<Book>();

        public Library() { }

        public void CheckOutBooks() 
        {

        }

        public void AddABook()
        {

        }

        public void DisplayCheckedOutList()
        {

        }

        public void DisplayRemovedBooks()
        {

        }

        public List<Book> DisplayAvailableBooks(string available)
        {
            List<Book> availibleList = new List<Book>();
            foreach (var item in Books)
            {
                if (item.ShelfStatus == 0)
                {
                    availibleList.Add(item);
                }
            }
            return availibleList;
        }

        public void ListPastDueBooks()
        {

        }




        public List<Book> SearchByAuthor(string authorName)
        {
            List<Book> authorList = new List<Book>();
            foreach (var item in Books)
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
            foreach (var item in Books)
            {
                if (item.Title == bookTitle)
                {
                    bookTitleList.Add(item);
                }
            }
            return bookTitleList;
        }

        public List<Book> DisplayAllBooks(string allBooks) //fyi i do not think i did this right at all, it feels redundant as fuck but i seriously just dont understand
        {
            List<Book> allBookList = new List<Book>();
            foreach (var item in Books)
            {
                allBookList.Add(item);
            }
            return allBookList;
        }

        public void ReturnBooks()
        {

        }

    }
}
