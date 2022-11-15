using LibraryOfAlexandria;

Console.WriteLine("tew");




Book book = new Book();

List<Book> testList = book.DisplayBooks();

foreach (var item in testList)
{
    Console.WriteLine(item.Author);
}
