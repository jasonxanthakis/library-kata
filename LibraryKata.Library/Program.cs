using LibraryKata.Library;

class Program
{
    static void Main(string[] args)
    {
        var lib = new Library();
        lib.AddBook(new Book("Harry Potter", "J. K. Rowling"));
        lib.AddBook(new Book("The Hobbit", "J. R. R. Tolkien"));
        lib.AddBook(new Book("The Lord of the Rings", "J. R. R. Tolkien"));
        lib.AddBook(new Book("Pirates of the Carribean: The Price of Freedom", "Ann C. Crispin"));
        lib.AddBook(new Book("Alex Rider", "Anthony Horowitz"));
        lib.AddBook(new Book("The Belgariad", "David Eddings"));

        lib.AddPatron(new Patron("NPC 1"));
        lib.AddPatron(new Patron("NPC 2"));
        lib.AddPatron(new Patron("NPC 3"));
        lib.AddPatron(new Patron("NPC 4"));
    }
}