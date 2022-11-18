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
