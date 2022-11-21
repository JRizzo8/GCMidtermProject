using System.Runtime.CompilerServices;

namespace LibraryOfAlexandria
{
    public class Library
    {

        public List<Book> Books { get; set; } = new List<Book>();

        //public Library() { } no point in having this bc it has one already by default and seeing it is just confusing

        //RIZZO METHODS
        public void CheckOutBook(string title, List<Book> listToCheckBookOutOf)
        {
            Books = listToCheckBookOutOf;
            foreach (Book book in Books)
            {
                if (book.ShelfStatus.Equals(ShelfStatus.OnShelf) && book.Title == title)
                {
                    book.ShelfStatus = ShelfStatus.OffShelf;
                    var currentDate = DateTime.Now;
                    book.DueDate = currentDate.AddDays(14);
                }
            }
        }

        public void AddABook(string title, string author, List<Book> listToAddBookTo)
        {
            Books = listToAddBookTo;
            Books.Add(new Book(title, author, ShelfStatus.OnShelf));
        }
        public void ReturnBooks(string title, List<Book> listToReturnBookTo)
        {
            Books = listToReturnBookTo;
            foreach (var item in Books)
            {
                if (item.Title == title && item.ShelfStatus == ShelfStatus.OffShelf)
                {
                    item.ShelfStatus = ShelfStatus.OnShelf;
                }

            }
        }

        //COLIN METHODS
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

        //NICOLE METHODS
        /*
        public void DisplayCheckedOutList()
        {

        }

        public void DisplayRemovedBooks()
        {

        }

        public void ListPastDueBooks()
        {

        }
        */

        //AMELIA METHODS
        public void DisplayAllBooks()
        {
            Console.WriteLine($"All books: \n");
            foreach (var item in Books)
            {
                Console.WriteLine($"\"{item.Title}\" by {item.Author}");
                if (item.ShelfStatus == 0)
                {
                    Console.ForegroundColor= ConsoleColor.Green;
                    Console.WriteLine($"{item.ShelfStatus}");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else //I dont fully know how many different shelf statuses we have so for now im just keeping it to On or Off
                {
                    Console.ForegroundColor= ConsoleColor.Red;
                    Console.WriteLine($"{item.ShelfStatus}");
                    Console.ForegroundColor= ConsoleColor.White;
                }
            }
        }

        public void DisplayAvailableBooks()
        {
            Console.WriteLine($"Books available to check out: \n");
            foreach (var item in Books)
            {
                if (item.ShelfStatus == 0)
                {
                    Console.WriteLine($"\"{item.Title}\" by {item.Author}");
                }
            }
        }
    }
}

/* QUESTION SECTION

L18: //can you just type book.ShelfStatus == 0 since the enum class has OnShelf's value is 0?
CHECK HELPER CLASS FOR POSSIBLE ERROR
Also Rachel Ray txt file author/title info is reversed

*/