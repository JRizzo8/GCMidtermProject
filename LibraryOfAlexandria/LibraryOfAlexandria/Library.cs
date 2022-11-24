

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

        public void ChangeBanStatus(Book bookToChange)
        {
            if (bookToChange.ShelfStatus == ShelfStatus.Banned)
            {
                bookToChange.ShelfStatus = ShelfStatus.OnShelf;
                Console.WriteLine($"{bookToChange} has been un-banned and put back on the shelf");
            }
            else
            {
                bookToChange.ShelfStatus = ShelfStatus.Banned;
                Console.WriteLine($"{bookToChange} has been banned");
            }
        }

        public void DisplayBannedList()
        {
            IEnumerable<Book> bannedBooks = from book in Books
                                            where book.ShelfStatus == ShelfStatus.Banned
                                            select book;


            Console.WriteLine("The following books are banned \n");

            foreach (var book in bannedBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author} is currently {book.ShelfStatus}");
            }

        }

        public void ListPastDueBooks() //someone else maybe already did? found empty method and filled it out of interest
        {
            var currentDate = DateTime.Now;
            IEnumerable<Book> overDueBooks = from book in Books
                                             where (book.DueDate - currentDate).TotalDays >= 14
                                             select book;

            Console.WriteLine("The Books currently past due are \n");

            foreach (var book in overDueBooks)
            {
                Console.WriteLine($"{book.Title} by {book.Author} is {book.ShelfStatus} and was due on {book.DueDate}");
            }



        }
        // end rizzo


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

                Console.Write("\nPlease enter the number of the book you'd like to choose: ");

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

                Console.Write("\nPlease enter the number of the book you'd like to like to choose: ");

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
