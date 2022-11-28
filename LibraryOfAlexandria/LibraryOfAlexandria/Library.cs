

namespace LibraryOfAlexandria
{
    public class Library
    {

        public List<Book> Books { get; set; } = new List<Book>();



        public Library() 
        {
        
        }

        // RIZZO Methods
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
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nYour book has been successfully returned");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("\n ------------------------");
            Console.WriteLine("| Returning to main menu |");
            Console.WriteLine(" ------------------------\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void ChangeBanStatus(Book bookToChange)
        {
            if (bookToChange.ShelfStatus == ShelfStatus.Banned)
            {
                bookToChange.ShelfStatus = ShelfStatus.OnShelf;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\n{bookToChange.Title} has been un-banned and put back on the shelf");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n ------------------------");
                Console.WriteLine("| Returning to main menu |");
                Console.WriteLine(" ------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                bookToChange.ShelfStatus = ShelfStatus.Banned;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n{bookToChange.Title} has been banned");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n ------------------------");
                Console.WriteLine("| Returning to main menu |");
                Console.WriteLine(" ------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void DisplayBannedList()
        {
            IEnumerable<Book> bannedBooks = from book in Books
                                            where book.ShelfStatus == ShelfStatus.Banned
                                            select book;


            Console.WriteLine("The following books are banned \n");

            MenuClass.ListBooksWithoutStatus(bannedBooks.ToList());

        }

        public void DisplayCheckedOutList()
        {
            IEnumerable<Book> checkedOutBooks = from book in Books
                                                where book.ShelfStatus == ShelfStatus.OffShelf
                                                select book;

            MenuClass.ListBooksWithoutStatus(checkedOutBooks.ToList());

            if(checkedOutBooks.Count() == 0)
            {
                Console.WriteLine($"There are no books checked out at this time. Returning to main menu now.");
            }

        }

        public void CheckDueDate(Library library)
        {
            Console.WriteLine(" -----------------");
            Console.WriteLine("| Due Date Search |");
            Console.WriteLine(" -----------------\n");
            Console.WriteLine("What is the title of the book you would like to check the due date of?");
            string choice = "";
            choice = Console.ReadLine();
            IEnumerable<Book> checkedOutBooks = from book in Books
                                                where book.ShelfStatus == ShelfStatus.OffShelf
                                                select book;

            if (checkedOutBooks.Count() == 0)
            {
                Console.WriteLine("There are no books checked out at this time.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n ------------------------");
                Console.WriteLine("| Returning to main menu |");
                Console.WriteLine(" ------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                MenuClass.MainMenu(library);
            }


            if (checkedOutBooks.Count() > 0)
            {
                for (int i = 0; i < Books.Count(); i++)
                {
                    if ((Books[i].Title.ToLower().Contains(choice)) && Books[i].ShelfStatus == ShelfStatus.OffShelf)
                    {
                        Console.Clear();
                        Console.WriteLine(" -----------------");
                        Console.WriteLine("| Due Date Search |");
                        Console.WriteLine(" -----------------\n");
                        Console.WriteLine($"The due date of {Books[i].Title} is {Books[i].DueDate} \n\n");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(" ------------------------");
                        Console.WriteLine("| Returning to main menu |");
                        Console.WriteLine(" ------------------------\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else if ((Books[i].Title.Contains(choice)) && Books[i].ShelfStatus == ShelfStatus.OffShelf)
                    {
                        Console.Clear();
                        Console.WriteLine(" -----------------");
                        Console.WriteLine("| Due Date Search |");
                        Console.WriteLine(" -----------------\n");
                        Console.WriteLine($"The due date of {Books[i].Title} is {Books[i].DueDate} \n\n");
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                        Console.WriteLine(" ------------------------");
                        Console.WriteLine("| Returning to main menu |");
                        Console.WriteLine(" ------------------------\n");
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                }
                MenuClass.MainMenu(library);
            }
            else
            {
                Console.Clear();
                Console.WriteLine(" -----------------");
                Console.WriteLine("| Due Date Search |");
                Console.WriteLine(" -----------------\n");
                Console.WriteLine("That book is not checked out at this time or is unavailable at this library.\n\n");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(" ------------------------");
                Console.WriteLine("| Returning to main menu |");
                Console.WriteLine(" ------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                MenuClass.MainMenu(library);
            }


        }

        // COLIN Methods
        public Book SearchByTitle(Library library, List<Book> bookList)
        {
            Console.Clear();
            List<Book> titleSearchResultsList = new List<Book>();
            Console.WriteLine(" ---------------------------");
            Console.WriteLine("| Check Out / Returns / Ban |");
            Console.WriteLine(" ---------------------------\n");
            Console.Write("Please enter a title to search by: ");
            string titleSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Title.ToLower().IndexOf(titleSearchString) == 0))
            {
                titleSearchResultsList.Add(result);
            }

            if (titleSearchResultsList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine(" ---------------------------");
                Console.WriteLine("| Check Out / Returns / Ban |");
                Console.WriteLine(" ---------------------------\n");
                Console.WriteLine($"Found {titleSearchResultsList.Count} book(s)");

                for (int i = 0; i < titleSearchResultsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.) {titleSearchResultsList[i].Title} by {titleSearchResultsList[i].Author}");
                }

                Console.Write("\nPlease enter the number of the book you'd like to choose: ");

                int userInt = Validator.GetNumberInRange(1, titleSearchResultsList.Count);
                Book userBook = titleSearchResultsList[userInt - 1];
                return userBook;



            }
            else if (!titleSearchResultsList.Any())
            {
                Console.Clear();
                Console.WriteLine(" ---------------------------");
                Console.WriteLine("| Check Out / Returns / Ban |");
                Console.WriteLine(" ---------------------------\n");
                Console.WriteLine($"A book with the title '{titleSearchString}' was not found.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n ------------------------");
                Console.WriteLine("| Returning to main menu |");
                Console.WriteLine(" ------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                MenuClass.MainMenu(library);
                //return to main menu
            }

            //not sure what I should put for the return here, still working on this
            throw new Exception("SearchByTitle Method Exception");
        }


        public Book SearchByAuthor(Library library, List<Book> bookList)
        {
            List<Book> authorSearchResultsList = new List<Book>();

            Console.Clear();
            Console.Write("Please enter an author to search by: ");
            string authorSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Author.ToLower().IndexOf(authorSearchString) == 0))
            {
                authorSearchResultsList.Add(result);
            }

            if (authorSearchResultsList.Count > 0)
            {
                Console.Clear();
                Console.WriteLine(" ---------------------------");
                Console.WriteLine("| Check Out / Returns / Ban |");
                Console.WriteLine(" ---------------------------\n");
                Console.WriteLine($"Found {authorSearchResultsList.Count} book(s)");

                for (int i = 0; i < authorSearchResultsList.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.) {authorSearchResultsList[i].Title} by {authorSearchResultsList[i].Author}");
                }

                Console.Write("\nPlease enter the number of the book you'd like to like to choose: ");

                int userInt = Validator.GetNumberInRange(1, authorSearchResultsList.Count);
                Book userBook = authorSearchResultsList[userInt - 1];
                return userBook;
            }
            else if (!authorSearchResultsList.Any())
            {
                Console.Clear();
                Console.WriteLine(" ---------------------------");
                Console.WriteLine("| Check Out / Returns / Ban |");
                Console.WriteLine(" ---------------------------\n");
                Console.WriteLine($"Author '{authorSearchString}' not found.");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n ------------------------");
                Console.WriteLine("| Returning to main menu |");
                Console.WriteLine(" ------------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                MenuClass.MainMenu(library);
            }

            //not sure what I should put for the return here, still working on this
            throw new Exception("SearchByAuthor Method Exception");
        }

        // Amelia
        public void DisplayAllBooks()
        {
            Console.WriteLine();
            MenuClass.ListBooksWithStatus(Books);
            Console.WriteLine($"\n\n");
        }

        public void DisplayAvailableBooks()
        {
            List<Book> availableBooks = Books.Where(x => x.ShelfStatus.ToString() == ShelfStatus.OnShelf.ToString()).ToList();
            Console.WriteLine();
            MenuClass.ListBooksWithoutStatus(availableBooks);
        }
    }
}
