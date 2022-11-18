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
            //rizzo
        }

        public void AddABook(string title, string author, List<Book> listToAddBookTo )
        {
            Books = listToAddBookTo;
            Books.Add(new Book(title, author, ShelfStatus.OnShelf));

            //rizzo
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
            //rizzo
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
        public List<Book> TitleSearch(List<Book> bookList)
        {
            List<Book> titleSearchResultsList = new List<Book>();
            string titleSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Title.ToLower().IndexOf(titleSearchString) == 0))
            {
                titleSearchResultsList.Add(result);
            }
            return titleSearchResultsList;
        }
        public List<Book> AuthorSearch(List<Book> bookList)
        {
            List<Book> authorSearchResultsList = new List<Book>();
            string authorSearchString = Console.ReadLine().ToLower();

            foreach (var result in bookList.Where(x => x.Author.ToLower().IndexOf(authorSearchString) == 0))
            {
                authorSearchResultsList.Add(result);
            }
            return authorSearchResultsList;
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

