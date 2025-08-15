using LibraryKata.Library;

class Program
{
    static void Main(string[] args)
    {
        var lib = new LibraryApp();

        var book1 = new Book("Harry Potter", "J. K. Rowling");
        var book2 = new Book("The Hobbit", "J. R. R. Tolkien");
        var book3 = new Book("The Lord of the Rings", "J. R. R. Tolkien");
        var book4 = new Book("Pirates of the Carribean: The Price of Freedom", "Ann C. Crispin");
        var book5 = new Book("The Belgariad", "David Eddings");
        var book6 = new Book("Alex Rider", "Anthony Horowitz");

        var patron1 = new Patron("NPC 1");
        var patron2 = new Patron("NPC 2");
        var patron3 = new Patron("NPC 3");
        var patron4 = new Patron("NPC 4");

        lib.AddBook(book1);
        lib.AddBook(book2);
        lib.AddBook(book3);
        lib.AddBook(book4);
        lib.AddBook(book5);
        lib.AddBook(book6);

        lib.AddPatron(patron1);
        lib.AddPatron(patron2);
        lib.AddPatron(patron3);
        lib.AddPatron(patron4);

        System.Console.WriteLine(lib.GetAllBooks());
        System.Console.WriteLine();

        lib.RemoveBook(book5);
        lib.RemoveBook(book6);
        lib.RemovePatron(patron4);

        System.Console.WriteLine(lib.GetAllBooks());
        System.Console.WriteLine();

        System.Console.WriteLine(lib.GetBookByAuthor("J. R. R. Tolkien"));
        System.Console.WriteLine();

        if (book1 == lib.GetBookByTitle("Harry Potter")) System.Console.WriteLine("Found the book");
        if (patron1 == lib.GetBookByTitle("NPC 1")) System.Console.WriteLine("Found the patron");
        System.Console.WriteLine();

        lib.BorrowBook(patron1, book2);
        lib.BorrowBook(patron1, book3);

        lib.ReturnBook(patron1, book2);
        lib.ReturnBook(patron1, book1);
    }
}