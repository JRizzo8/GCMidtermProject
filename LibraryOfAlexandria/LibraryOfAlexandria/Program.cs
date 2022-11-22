
using static System.Reflection.Metadata.BlobBuilder;


using System.IO;
using LibraryOfAlexandria;
using System.Runtime.CompilerServices;

Library library = HelperClass.InitializeLibrary();
bool loop = true;

    Console.WriteLine("Welcome to the library");

while (loop == true)
{
    Console.WriteLine("What would like to do");
    Console.WriteLine("1.) Browse Inventory");
    Console.WriteLine("2.) Checkout Book");
    Console.WriteLine("3.) Return Book");
    Console.WriteLine("4.) Donate Book");

    int userChoice = int.Parse(Console.ReadLine());

    switch (userChoice)
    {
        case 1:
            InventoryMethod(library);
            break;
        case 2:
            List<Book> availableBookList = library.Books.Where(x => x.ShelfStatus == ShelfStatus.OnShelf).ToList();
            Console.WriteLine("What would you like to search by?");
            Console.WriteLine("1.) Title");
            Console.WriteLine("2.) Author)");
            userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 1)
            {
                Book bookTitleSearch = library.TitleSearch(availableBookList);
                library.CheckOutBook(bookTitleSearch);
            }
            else if (userChoice == 2)
            {
                Book authorSearch = library.AuthorSearch(availableBookList);
                library.CheckOutBook(authorSearch);
            }
            break;
        case 3:
            List<Book> checkedOutBookList = library.Books.Where(x => x.ShelfStatus == ShelfStatus.OffShelf).ToList();
            Console.WriteLine("Select an option to return a book");
            Console.WriteLine("1.) By Title");
            Console.WriteLine("2.) By Author");
            userChoice = int.Parse(Console.ReadLine());
            if (userChoice == 1)
            {
                Book bookTitleSearch = library.TitleSearch(checkedOutBookList);
                Console.WriteLine(bookTitleSearch.ShelfStatus);
                Console.WriteLine(bookTitleSearch.Title);
                library.ReturnBooks(bookTitleSearch);
                Console.WriteLine(bookTitleSearch.ShelfStatus);

            }
            else if (userChoice == 2)
            {
                Book authorSearch = library.AuthorSearch(checkedOutBookList);
                Console.WriteLine(authorSearch.Author);
                library.ReturnBooks(authorSearch);
                Console.WriteLine(authorSearch.ShelfStatus);
            }
            break;
        case 4:
            Console.WriteLine("Add a book");
            Console.WriteLine("Please enter the title of the book");
            string title = Console.ReadLine();
            Console.WriteLine("Please enter the author of the book");
            string author = Console.ReadLine();
            library.AddABook(title, author);
            break;
    }


    Console.WriteLine("Anything else we can help you with today? (y/n)");
    string userLoopInput = Console.ReadLine().ToLower();
    //switch (userLoopInput)
    //{
    //    case "y":
    //        continue;
    //    case "n":
    //        Console.WriteLine("Thank you! Have a nice day!");
    //        break;
    //    default:
    //        break;
    //}
    if (userLoopInput == "y")
    {
        continue;
    }
    else
    {
        Console.WriteLine("Thank you! Have a nice day!");
        break;
    }




}






static void InventoryMethod(Library library)
    {
        Console.WriteLine("What would you like to see");
        Console.WriteLine("1.) Total Inventory");
        Console.WriteLine("2.) Available Books");
        Console.WriteLine("3.) Checkedout Books");

        int userChoice = int.Parse(Console.ReadLine());

        switch (userChoice)
        {
            case 1:
                library.DisplayAllBooks();
                break;
            case 2:
                library.DisplayAvailableBooks();
                break;
            case 3:
                library.DisplayCheckedOutList();
                break;
        }







    }








//List<Book> books = library.Books;


//foreach(Book book in books)
//{
//    Console.WriteLine($"{book.Title} {book.Author} {book.ShelfStatus}");
//}

//using System.Xml;

//Library test = new Library(); 

//List<Book> testList = new List<Book>();
//testList.Add(new Book("title1", "author1", ShelfStatus.OnShelf));
//testList.Add(new Book("title2", "author2", ShelfStatus.OnShelf));
//testList.Add(new Book("title3", "author3", ShelfStatus.OnShelf));
//testList.Add(new Book("title4", "author4", ShelfStatus.OnShelf));


//// initial list test
//foreach (var item in testList)
//{
//    Console.WriteLine($"{item.Title} by {item.Author} is currently {item.ShelfStatus}");
//}

//// testing the CheckOutBook method
//Console.WriteLine("Please enter the title of the book you would like to check out");

//test.CheckOutBook(Console.ReadLine().ToLower(), testList);
//foreach (var item in testList)
//{
//    Console.WriteLine($"{item.Title} by {item.Author} is currently {item.ShelfStatus}, its due date is {item.DueDate}");
//}

////testing the AddABook method
//Console.WriteLine("Please enter the title of the book to add");
//string userTitle = Console.ReadLine().ToLower();

//Console.WriteLine("Now please enter the author");
//string userAuthor = Console.ReadLine().ToLower();

//test.AddABook(userTitle, userAuthor, testList);

//foreach (var item in testList)
//{
//    Console.WriteLine($"{item.Title} by {item.Author} is currently {item.ShelfStatus}");
//}

//// testing ReturnBook method
//Console.WriteLine("Please enter the title of the book to return");
//string userReturn = Console.ReadLine().ToLower();

//test.ReturnBooks(userReturn, testList);

//foreach (var item in testList)
//{
//    Console.WriteLine($"{item.Title} by {item.Author} is currently {item.ShelfStatus}");
//}



Console.ReadKey();

}