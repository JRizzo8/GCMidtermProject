using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryOfAlexandria
{
    public static class HelperClass
    {
        public static Library InitLibrary()
        {
            Library library = new Library();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string bookFilePath = projectDirectory + @"\Inventory.txt";

            StreamReader reader = new StreamReader(bookFilePath);
            while (true)
            {
                string line = reader.ReadLine();
                if (line == null)
                {
                    break;
                }
                string[] sections = line.Split(',');
                Book book = new Book(sections[0], sections[1], ShelfStatus.OnShelf);
                library.Books.Add(book);
            }
            return library;
        }
    }
}
