using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfAlexandria
{
    public static  class FileHelper
    {
        public static string workingDirectory = Environment.CurrentDirectory;
        public static string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
        public static string demoInventoryPath = projectDirectory + @"\DemoInventory.txt";
        public static string savedInventoryFilePath = projectDirectory + @"\SavedInventory.txt";

        public static void SaveFile(List<Book> bookList)
        {

            using (TextWriter tw = new StreamWriter(savedInventoryFilePath))
            {
                foreach (Book book in bookList)
                    tw.WriteLine($"{book.Title},{book.Author},{book.ShelfStatus.ToString()}");
            }
        }

        public static Library InitializeLibrary()
        {
            Library library = new Library();
            if (!(File.Exists(savedInventoryFilePath)))
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("No database found. Generating demo list of books\n");
                Console.ResetColor();
                StreamReader demoListReader = new StreamReader(demoInventoryPath);
                while (!demoListReader.EndOfStream) //replaced "true"
                {
                    string line = demoListReader.ReadLine();
                    string[] sections = line.Split(',');
                    Book book = new Book(sections[0], sections[1], ShelfStatus.OnShelf); 
                                                                                         
                    library.Books.Add(book);
                }
                demoListReader.Close();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Existing book database found\n");
                Console.ResetColor();
                StreamReader savedListReader = new StreamReader(savedInventoryFilePath);
                while (!savedListReader.EndOfStream) //replaced "true"
                {
                    ShelfStatus status = ShelfStatus.OffShelf;
                    string line = savedListReader.ReadLine();

                    string[] sections = line.Split(',');
                    if (sections[2].ToString() == "OnShelf")
                    {
                        status = ShelfStatus.OnShelf;
                    }
                    else if (sections[2].ToString() == "OffShelf")
                    {
                        status = ShelfStatus.OffShelf;
                    }
                    else if (sections[2].ToString() == "Removed")
                    {
                        status = ShelfStatus.Removed;
                    }
                    else if (sections[2].ToString() == "Banned")
                    {
                        status = ShelfStatus.Banned;
                    }

                    Book book = new Book(sections[0], sections[1], status); 
                                                                            
                    library.Books.Add(book);
                }
                savedListReader.Close();
            }
            return library;
        }
    }
}
