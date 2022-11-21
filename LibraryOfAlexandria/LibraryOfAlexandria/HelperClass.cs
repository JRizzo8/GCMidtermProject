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
        public static Library InitializeLibrary()
        {
            Library library = new Library();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            string inventoryFilePath = projectDirectory + @"\Inventory.txt";

            StreamReader reader = new StreamReader(inventoryFilePath);
            while (!reader.EndOfStream) //replaced "true"
            {
                string line = reader.ReadLine();
                //if (line == null)
                //{
                //    break;
                //}
                string[] sections = line.Split(',');
                Book book = new Book(sections[0], sections[1], ShelfStatus.OnShelf); //if we do the optional thing, defaulting to on shelf will be wrong,,
                                                                                     //itll keep reseting all shelf status to on shelf everytime program is ran
                library.Books.Add(book);
            }
            return library;
        }
    }
}
