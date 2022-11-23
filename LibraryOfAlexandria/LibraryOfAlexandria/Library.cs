

namespace LibraryOfAlexandria
{
    public class Library
    {

        public List<Book> Books { get; set; } = new List<Book>();



        public Library() 
        {
        
        }


        //RIZZO METHODS
        public bool CheckOutBook(Book bookToReturn)
        {
            List<Book> checkedOutBookList = Books.Where(x => x.ShelfStatus == ShelfStatus.OffShelf).ToList();
            if (checkedOutBookList.Contains(bookToReturn))
            {
                Console.WriteLine($"Sorry, {bookToReturn.Title} has already been checked out");
                return false;
            }

            bookToReturn.ShelfStatus = ShelfStatus.OffShelf;
            var currentDate = DateTime.Now;
            bookToReturn.DueDate = currentDate.AddDays(14);

            return true;
        }

        public void AddABook(string title, string author)
        {
            Books.Add(new Book(title, author, ShelfStatus.OnShelf));
        }
        public void ReturnBooks(Book bookToReturn)
        {
            bookToReturn.ShelfStatus = ShelfStatus.OnShelf;
        }
            //rizzo
        

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

        //public List<Book> DisplayAvailableBooks(string available)
        //{

        //    IEnumerable<Book> availableBooks = from book in Books
        //                                        where book.ShelfStatus == ShelfStatus.OnShelf
        //                                        select book;

        //    foreach (var book in availableBooks)
        //    {
        //        Console.WriteLine($"{book.Title} by {book.Author}");
        //    }


        //    List<Book> availibleList = new List<Book>();

        //    foreach (var item in Books)
        //    {
        //        if (item.Title == title && item.ShelfStatus == ShelfStatus.OffShelf)
        //        {
        //            item.ShelfStatus = ShelfStatus.OnShelf;
        //        }

        //    }


        //    return availibleList;

        //}

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

        public Book SearchByTitle(Library library, List<Book> bookList)
        {
            List<Book> titleSearchResultsList = new List<Book>();

            Console.Write("Please enter a title to search by: ");
            string titleSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Title.ToLower().IndexOf(titleSearchString) == 0))
            {
                titleSearchResultsList.Add(result);
            }

            if (titleSearchResultsList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"Found {titleSearchResultsList.Count} book(s)");

                for (int i = 0; i < titleSearchResultsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.) {titleSearchResultsList[i].Title} by {titleSearchResultsList[i].Author}");
                }

                Console.Write("\nPlease enter the number of the book you'd like to check out: ");

                int userInt = int.Parse(Console.ReadLine());
                Book userBook = titleSearchResultsList[userInt - 1];
                return userBook;
            }
            else if (!titleSearchResultsList.Any())
            {
                Console.Clear();
                Console.WriteLine($"A book with the title '{titleSearchString}' was not found, returning to main menu\n");
                MenuClass.MainMenu(library);
                //return to main menu
            }

            //not sure what I should put for the return here, still working on this
            throw new Exception("SearchByTitle Method Exception");
        }


        public Book SearchByAuthor(Library library, List<Book> bookList)
        {
            List<Book> authorSearchResultsList = new List<Book>();

            Console.Write("Please enter an author to search by: ");
            string authorSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Author.ToLower().IndexOf(authorSearchString) == 0))
            {
                authorSearchResultsList.Add(result);
            }

            if (authorSearchResultsList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine($"Found {authorSearchResultsList.Count} book(s)");

                for (int i = 0; i < authorSearchResultsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.) {authorSearchResultsList[i].Title} by {authorSearchResultsList[i].Author}");
                }

                Console.Write("\nPlease enter the number of the book you'd like to check out: ");

                int userInt = int.Parse(Console.ReadLine());
                Book userBook = authorSearchResultsList[userInt - 1];
                return userBook;
            }
            else if (!authorSearchResultsList.Any())
            {
                Console.Clear();
                Console.WriteLine($"Author '{authorSearchString}' not found, returning to main menu\n");
                MenuClass.MainMenu(library);
            }

            //not sure what I should put for the return here, still working on this
            throw new Exception("SearchByAuthor Method Exception");
        }


        //public void DisplayCheckedOutList()
        //{

        //}

        //public void DisplayRemovedBooks()
        //{

        //}

        public void ListPastDueBooks()
        {

        }
        //*/

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