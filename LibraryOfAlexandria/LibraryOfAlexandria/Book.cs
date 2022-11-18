namespace LibraryOfAlexandria
{
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public ShelfStatus ShelfStatus { get; set; }
        public DateTime DueDate { get; set; }


        //public Book()
        //{


        public Book()
        {


        //}

        public Book(string title, string author, ShelfStatus status)
        {
            Title = title;
            Author = author;
            ShelfStatus = status;
        }
    }
}
