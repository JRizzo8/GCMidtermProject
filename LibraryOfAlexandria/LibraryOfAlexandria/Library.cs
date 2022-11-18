using System.Runtime.CompilerServices;

namespace LibraryOfAlexandria
{
    public class Library
    {
    
        public List<Book> Books { get; set; } = new List<Book>();

        public Library() 
        {
        
        }

        public void CheckOutBook(string title, List<Book> listToCheckBookOutOf) 
        {
            Books = listToCheckBookOutOf;
            foreach(Book book in Books) 
            {   

                if (book.ShelfStatus.Equals(ShelfStatus.OnShelf) && book.Title == title)
                {
                    book.ShelfStatus = ShelfStatus.OffShelf;
                    var currentDate = DateTime.Now;
                    book.DueDate = currentDate.AddDays(14);
                }
            }
            //rizzo
        }

        public void AddABook(string title, string author, List<Book> listToAddBookTo )
        {
            Books = listToAddBookTo;
            Books.Add(new Book(title, author, ShelfStatus.OnShelf));

            //rizzo
        }
        public void ReturnBooks(string title, List<Book> listToReturnBookTo)
        {
            Books = listToReturnBookTo;
            foreach(var item in Books) 
            {
                if (item.Title == title && item.ShelfStatus == ShelfStatus.OffShelf) 
                {
                    item.ShelfStatus=ShelfStatus.OnShelf;
                }
                
            }
            //rizzo
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

        public List<Book> DisplayAvailableBooks(string available)
        {

            IEnumerable<Book> availableBooks = from book in Books
                                                where book.ShelfStatus == ShelfStatus.OnShelf
                                                select book;

            foreach (var book in availableBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author}");
            }


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
        public List<Book> TitleSearch(List<Book> bookList)
        {
            List<Book> titleSearchResultsList = new List<Book>();
            string titleSearchString = Console.ReadLine().ToLower();


        public List<Book> SearchByAuthor(string authorName)

            foreach (var result in bookList.Where(x => x.Title.ToLower().IndexOf(titleSearchString) == 0))
            {
                titleSearchResultsList.Add(result);
            }
            return titleSearchResultsList;
        }
        public List<Book> AuthorSearch(List<Book> bookList)

        {
            List<Book> authorSearchResultsList = new List<Book>();
            string authorSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Author.ToLower().IndexOf(authorSearchString) == 0))
            {
                authorSearchResultsList.Add(result);
            }
            return authorSearchResultsList;
        }

        // Amelia
        public List<Book> DisplayAllBooks(string allBooks) //fyi i do not think i did this right at all, it feels redundant as fuck but i seriously just dont understand
        {
            List<Book> allBookList = new List<Book>();
            foreach (var item in Books)
            {
                allBookList.Add(item);
            }
            return allBookList;

        public List<Book> DisplayAllBooks()

        public void SearchByAuthor(string authorName)
        {

        }
        public void SearchByTitle(string bookTitle)
        {
        }



    }
}

