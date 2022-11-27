using static System.Reflection.Metadata.BlobBuilder;

using System.IO;
using LibraryOfAlexandria;
using System.Runtime.CompilerServices;

Library library = HelperClass.InitializeLibrary();
Console.WriteLine("Welcome to the Library of Alexandria!\n");
MenuClass.MainMenu(library);

