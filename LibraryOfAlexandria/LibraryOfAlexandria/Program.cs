using LibraryOfAlexandria;

//Console.WriteLine("tew");




//Book book = new Book();

//List<Book> testList = book.DisplayBooks();

//foreach (var item in testList)
//{
//    Console.WriteLine(item.Author);
//}






Library library = new Library();

Book book = new Book("title1", "author1", ShelfStatus.OnShelf);
Book book2 = new Book("title2", "AUTHOR1", ShelfStatus.OnShelf);
Book book3 = new Book("title3", "author3", ShelfStatus.OnShelf);


List<Book> testBookList = library.Books;
testBookList.Add(book);
testBookList.Add(book2);
testBookList.Add(book3);

foreach(Book item in testBookList)
{
    Console.WriteLine(item.Title);
    Console.WriteLine(item.Author);
}


List<Book> testAuthorSearchList = library.AuthorSearch(testBookList);


foreach (Book item in testAuthorSearchList)
{
    Console.WriteLine(item.Author);
    //Console.WriteLine(item.Author);
}