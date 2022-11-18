using LibraryOfAlexandria;

Library library = HelperClass.InitLibrary();

List<Book> books = library.Books;


foreach(Book book in books)
{
    Console.WriteLine($"{book.Title} {book.Author} {book.ShelfStatus}");
}