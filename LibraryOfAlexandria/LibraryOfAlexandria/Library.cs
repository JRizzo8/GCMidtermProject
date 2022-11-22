

namespace LibraryOfAlexandria
{
    public class Library
    {

        public List<Book> Books { get; set; } = new List<Book>();



        public Library() 
        {
        
        }


        //RIZZO METHODS
        public void CheckOutBook(string title, List<Book> listToCheckBookOutOf)
        {
            Books = listToCheckBookOutOf;
            foreach (Book book in Books)
            {
                if (book.ShelfStatus.Equals(ShelfStatus.OnShelf) && book.Title == title)
                {
                    book.ShelfStatus = ShelfStatus.OffShelf;
                    var currentDate = DateTime.Now;
                    book.DueDate = currentDate.AddDays(14);
                }
            }
        }

        public void AddABook(string title, string author, List<Book> listToAddBookTo)
        {
            Books = listToAddBookTo;
            Books.Add(new Book(title, author, ShelfStatus.OnShelf));
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
                if (item.Title == title && item.ShelfStatus == ShelfStatus.OffShelf)
                {
                    item.ShelfStatus = ShelfStatus.OnShelf;
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
<<<<<<< HEAD
        // Need to add input validation for search methods
        public Book TitleSearch(List<Book> bookList)
=======

        public List<Book> TitleSearch(List<Book> bookList)
>>>>>>> 1cd006639522e1a133ecbe32f25c7adfd1eafc0e
        {
            List<Book> titleSearchResultsList = new List<Book>();
            string titleSearchString = Console.ReadLine().ToLower();


        public List<Book> SearchByAuthor(string authorName)

            foreach (var result in bookList.Where(x => x.Title.ToLower().IndexOf(titleSearchString) == 0))
            {
                titleSearchResultsList.Add(result);
            }
            //return titleSearchResultsList;

            for (int i = 0; i < titleSearchResultsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}).{titleSearchResultsList[i].Title}");
            }

            Console.WriteLine(" Which book would you like to checkout?");

            int userInt = int.Parse(Console.ReadLine());

            Console.WriteLine(titleSearchResultsList[userInt - 1].Title);

            Book userBook = titleSearchResultsList[userInt - 1];

            Console.WriteLine(userBook.Title);

            return userBook;
        }
<<<<<<< HEAD
        // Need to add input validation for search methods
        public Book AuthorSearch(List<Book> bookList)
=======

        public List<Book> AuthorSearch(List<Book> bookList)

>>>>>>> 1cd006639522e1a133ecbe32f25c7adfd1eafc0e
        {
            List<Book> authorSearchResultsList = new List<Book>();
            string authorSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Author.ToLower().IndexOf(authorSearchString) == 0))
            {
                authorSearchResultsList.Add(result);
            }
            //return authorSearchResultsList;
            for (int i = 0; i < authorSearchResultsList.Count; i++)
            {
                Console.WriteLine($"{i + 1}).{authorSearchResultsList[i].Author}");
            }

            Console.WriteLine("Which book would you like to checkout?");

            int userInt = int.Parse(Console.ReadLine());

            Console.WriteLine(authorSearchResultsList[userInt - 1].Author);

            Book userBook = authorSearchResultsList[userInt - 1];

            Console.WriteLine(userBook.Author);

            return userBook;
        }

        //NICOLE METHODS
        /*
        public void DisplayCheckedOutList()
        {

        }

        public void DisplayRemovedBooks()
        {

        }

        public void ListPastDueBooks()
        {

        }
        */

        //AMELIA METHODS
        public void DisplayAllBooks()
        {
            Console.WriteLine($"All books: \n");
            foreach (var item in Books)
            {
                Console.WriteLine($"\"{item.Title}\" by {item.Author}");
                if (item.ShelfStatus == 0)
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine($"{item.ShelfStatus}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else //I dont fully know how many different shelf statuses we have so for now im just keeping it to On or Off
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"{item.ShelfStatus}");
                    Console.ForegroundColor= ConsoleColor.White;
                }
            }
        }

        public void DisplayAvailableBooks()
        {
            Console.WriteLine($"Books available to check out: \n");
            foreach (var item in Books)
            {
                if (item.ShelfStatus == 0)
                {
                    Console.WriteLine($"\"{item.Title}\" by {item.Author}");
                }
            }
        }
    }
}

/* QUESTION SECTION

L18: //can you just type book.ShelfStatus == 0 since the enum class has OnShelf's value is 0?
CHECK HELPER CLASS FOR POSSIBLE ERROR
Also Rachel Ray txt file author/title info is reversed

*/