namespace LibraryOfAlexandria
{
    public class Library
    {
    
        public List<Book> Books { get; set; } = new List<Book>();

        public Library() { }

        public void CheckOutBook(string title, List<Book> listToCheckBookOutOf) 
        {
            Books = listToCheckBookOutOf;
            foreach(Book book in Books) 
            {   

                if (book.ShelfStatus.Equals(ShelfStatus.OnShelf) && book.Title == title)
                {
                    book.ShelfStatus = ShelfStatus.OffShelf;
                    var currentDate = DateTime.Now;
                    book.DueDate = currentDate.AddDays(14);
                }
            }
            //me
        }

        public void AddABook(string title, string author, List<Book> listToAddBookTo )
        {
            Books = listToAddBookTo;
            Books.Add(new Book(title, author, ShelfStatus.OnShelf));

            //me
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
            //me
        }

        public void DisplayCheckedOutList()
        {

        }

        public void DisplayRemovedBooks()
        {

        }

        public void DisplayAvailableBooks()
        {

        }

        public void ListPastDueBooks()
        {

        }
        // Need to add input validation for search methods
        public Book TitleSearch(List<Book> bookList)
        {
            List<Book> titleSearchResultsList = new List<Book>();
            string titleSearchString = Console.ReadLine().ToLower();

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
        // Need to add input validation for search methods
        public Book AuthorSearch(List<Book> bookList)
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
        public List<Book> DisplayAllBooks()

        public void SearchByAuthor(string authorName)
        {
        }
        public void SearchByTitle(string bookTitle)
        {
        }

        public void DisplayAllBooks()
        {
        }



    }
}

