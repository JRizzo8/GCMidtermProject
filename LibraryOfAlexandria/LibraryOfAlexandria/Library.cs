namespace LibraryOfAlexandria
{
    public class Library
    {
    
        public List<Book> Books { get; set; } = new List<Book>();

        public Library() 
        {
        
        }

        public void CheckOutBooks() 
        {

        }

        public void AddABook()
        {

        }

        public void DisplayCheckedOutList()
        {
            IEnumerable<Book> checkedOutBooks = from book in Books
                                                where book.ShelfStatus == ShelfStatus.OffShelf
                                                select book;

            foreach (var book in checkedOutBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }

        }

        public void DisplayRemovedBooks()
        {

        }

        public void DisplayAvailableBooks()
        {
            IEnumerable<Book> availableBooks = from book in Books
                                                where book.ShelfStatus == ShelfStatus.OnShelf
                                                select book;

            foreach (var book in availableBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }

        }

        public void CheckDueDate()
        {
            IEnumerable<Book> bookDueDate = from book in Books                                    
                                             orderby book ascending
                                             select book;

            foreach (var book in bookDueDate)
            {
                Console.WriteLine($"{book.Title} by {book.Author} is due {book.DueDate}");
            }
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

        public List<Book> DisplayAllBooks()
        {
            return Books;
        }

        public void ReturnBooks()
        {

        }

    }
}
