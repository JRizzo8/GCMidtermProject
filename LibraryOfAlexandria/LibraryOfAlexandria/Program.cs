using LibraryOfAlexandria;
using static System.Reflection.Metadata.BlobBuilder;


using System.IO;

//Library library = HelperClass.InitLibrary();

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

//Console.ReadKey();


//////////////////////////////////////////////

Library firstLibrary = HelperClass.InitializeLibrary();

//foreach (Book inventory in firstLibrary.Books)
//{
//    Console.WriteLine($"{inventory.Title} {inventory.Author} {inventory.ShelfStatus}");
//}

firstLibrary.DisplayAllBooks();