using static System.Reflection.Metadata.BlobBuilder;

using System.IO;
using LibraryOfAlexandria;
using System.Runtime.CompilerServices;

Library library = FileHelper.InitializeLibrary();
Console.WriteLine("Welcome to");
Console.WriteLine(@"   __ _ _                                   __     _   _                          _      _
  / /(_) |__  _ __ __ _ _ __ _   _    ___  / _|   /_\ | | _____  ____ _ _ __   __| |_ __(_) __ _
 / / | | '_ \| '__/ _` | '__| | | |  / _ \| |_   //_\\| |/ _ \ \/ / _` | '_ \ / _` | '__| |/ _` |
/ /__| | |_) | | | (_| | |  | |_| | | (_) |  _| /  _  \ |  __/>  < (_| | | | | (_| | |  | | (_| |
\____/_|_.__/|_|  \__,_|_|   \__, |  \___/|_|   \_/ \_/_|\___/_/\_\__,_|_| |_|\__,_|_|  |_|\__,_|
                             |___/
");
MenuClass.MainMenu(library);

