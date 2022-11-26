using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfAlexandria
{
    public static class MenuClass
    {
        public static void MainMenu(Library library)
        {
            bool condition = false;

            Console.WriteLine("What would like to do");
            Console.WriteLine("1.) Browse Inventory");
            Console.WriteLine("2.) Checkout Book");
            Console.WriteLine("3.) Return Book");
            Console.WriteLine("4.) Donate Book");
            Console.WriteLine("5.) Check Due Date");
            Console.WriteLine("6.) Quit");
            Console.WriteLine("5.) Ban a Book"); //rizzo
            Console.WriteLine("6.) Quit");

            while (!condition)
            {
                int userChoice = Validator.ValidateUserNumber();

                switch (userChoice)
                {
                    case 1:
                        ListMenu(library);
                        break;
                    case 2:
                        SearchMenu(library, "checkout");
                        break;
                    case 3:
                        SearchMenu(library, "return");
                        break;
                    case 4:
                        DonateMenu(library);
                        break;
                    case 5:
                        DueDateMenu(library);
                        break;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option. Please try again.");
                        break;
                }
            }
            switch (userChoice)
            {
                case 1:
                    ListMenu(library);
                    break;
                case 2:
                    SearchMenu(library, "checkout");
                    break;
                case 3:
                    SearchMenu(library, "return");
                    break;
                case 4:
                    DonateMenu(library);
                    break;
                case 5:
                    SearchMenu(library, "ban"); //rizzo
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }

        }

        static void ListMenu(Library library)
        {
            bool condition = false;

            Console.WriteLine("What would you like to see");
            Console.WriteLine("1.) Total Inventory");
            Console.WriteLine("2.) Available Books");
            Console.WriteLine("3.) Checked Out Books");
            Console.WriteLine("4.) Banned Books"); //rizzo

            while (!condition)
            {
                int userChoice = Validator.ValidateUserNumber();

            switch (userChoice)
            {
                case 1:
                    library.DisplayAllBooks();
                    MainMenu(library);
                    break;
                case 2:
                    library.DisplayAvailableBooks();
                    MainMenu(library);
                    break;
                case 3:
                    library.DisplayCheckedOutList();
                    MainMenu(library);
                    break;
                case 4:
                    library.DisplayBannedList(); //added to display banned list - rizzo
                    MainMenu(library);
                    break;
            }
        }
                switch (userChoice)
                {
                    case 1:
                        library.DisplayAllBooks();
                        MainMenu(library);
                        break;
                    case 2:
                        library.DisplayAvailableBooks();
                        MainMenu(library);
                        break;
                    case 3:
                        library.DisplayCheckedOutList();
                        MainMenu(library);
                        break;
                    default:
                        Console.WriteLine("Sorry, that is not an option. Please try again.");
                        break;
                }
            }
        }

        static void SearchMenu(Library library, string action)
        {
            int userChoice = 0;
            bool checkoutSuccess = false;
            if (action == "checkout")
            {
                Console.Clear();
                Console.WriteLine("Book Checkout Search\n");
                Console.WriteLine("What would you like to search by?");
                Console.WriteLine("1.) Title");
                Console.WriteLine("2.) Author");

                while (true)
                {                   
                    userChoice = Validator.GetNumberInRange(1, 2);

                    if (userChoice == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Book Checkout Search\n");
                        Book bookToSearchFor = library.SearchByTitle(library, library.Books);
                        checkoutSuccess = library.CheckOutBook(bookToSearchFor);
                        if (checkoutSuccess)
                        {
                            Console.Clear();
                            Console.WriteLine($"{bookToSearchFor.Title} by {bookToSearchFor.Author} has been checked out and is due back by {bookToSearchFor.DueDate}\n");
                            Console.WriteLine("Returning to main menu\n");
                            MainMenu(library);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Sorry, {bookToSearchFor.Title} by {bookToSearchFor.Author} has already been checked out. Try again on {bookToSearchFor.DueDate} when it's due back.\n");
                            Console.WriteLine("Returning to main menu\n");
                            MainMenu(library);
                        }

                    }
                    else if (userChoice == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Book Checkout Search\n");
                        Book bookToSearchFor = library.SearchByAuthor(library, library.Books);
                        checkoutSuccess = library.CheckOutBook(bookToSearchFor);
                        if (checkoutSuccess)
                        {
                            Console.Clear();
                            Console.WriteLine($"{bookToSearchFor.Title} by {bookToSearchFor.Author} has been checked out and is due back by {bookToSearchFor.DueDate}\n");
                            Console.WriteLine("Returning to main menu\n");
                            MainMenu(library);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"Sorry, {bookToSearchFor.Title} by {bookToSearchFor.Author} has already been checked out. Try again on {bookToSearchFor.DueDate} when it's due back.\n");
                            Console.WriteLine("Returning to main menu\n");
                            MainMenu(library);
                        }
                    }
                }

            }
            else if (action == "return")
            {
                List<Book> checkedOutBookList = library.Books.Where(x => x.ShelfStatus == ShelfStatus.OffShelf).ToList();
                Console.WriteLine("Select an option to find the book you'd like to return");
                Console.WriteLine("1.) By Title");
                Console.WriteLine("2.) By Author");

                while (true)
                {
                    userChoice = Validator.GetNumberInRange(1, 2);
                    if (userChoice == 1)
                    {
                        Book bookTitleSearch = library.SearchByTitle(library, checkedOutBookList);
                        library.ReturnBooks(bookTitleSearch);
                    }
                    else if (userChoice == 2)
                    {
                        Book authorSearch = library.SearchByAuthor(library, checkedOutBookList);
                        library.ReturnBooks(authorSearch);
                    }
                }
                
            }
            else if (action == "ban") //rizzo
            {
             
                Console.WriteLine("Select an option to find the book you'd like to ban");
                Console.WriteLine("1.) By Title");
                Console.WriteLine("2.) By Author");
                userChoice = int.Parse(Console.ReadLine());
                if (userChoice == 1)
                {
                    Book bookTitleSearch = library.SearchByTitle(library, library.Books); //not sure if im searching the library right here since initially there wont be banned books
                    library.ChangeBanStatus(bookTitleSearch);
                }
                else if (userChoice == 2)
                {
                    Book authorSearch = library.SearchByAuthor(library, library.Books);
                    library.ChangeBanStatus(authorSearch);
                }
            }
        }
        public static void DonateMenu(Library library)
        {
            Console.WriteLine("Add a book");
            Console.WriteLine("Please enter the title of the book you'd like to donate");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the author of the book you'd like to donate");
            string author = Console.ReadLine();
            library.AddABook(title, author);
            Console.WriteLine("Thank you for your donation!");
        }

        public static void DueDateMenu(Library library)
        {
            library.CheckDueDate(library);
        }
    }
}
