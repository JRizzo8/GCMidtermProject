namespace LibraryOfAlexandria
{
    public class Library
    {
    
        public List<Book> Books { get; set; } = new List<Book>();

        public Library() { }

        public void CheckOutBooks() 
        {

        }

        public void AddABook()
        {

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




        public List<Book> SearchByAuthor(string authorName)
        {
            List<Book> authorList = new List<Book>();
            foreach (var item in Books)
            {
                if (item.Author == authorName)
                {
                    authorList.Add(item);
                }
            }
            return authorList;
        }
        public List<Book> SearchByTitle(string bookTitle)
        {
            List<Book> bookTitleList = new List<Book>();
            foreach (var item in Books)
            {
                if (item.Title == bookTitle)
                {
                    bookTitleList.Add(item);
                }
            }
            return bookTitleList;
        }

        public List<Book> DisplayAllBooks()
        {
            return Books;
        }

        public void ReturnBooks()
        {

        }

    }
}
