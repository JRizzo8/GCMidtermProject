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
        {
            return Books;
        }

        public void ReturnBooks()
        {

        }

    }
}

