namespace LibraryKata.Library.Interfaces
{
    public interface ILibrary
    {
        List<IBook> Books { get; }
        List<IPatron> Patrons { get; }

        void AddBook(IBook book);
        void RemoveBook(IBook book);
        IEnumerable<IBook> GetBookByAuthor(string Author);
        IEnumerable<IBook> GetBookByTitle(string title);
        List<IBook> GetAllBooks();

        void AddPatron(IPatron patron);
        void RemovePatron(IPatron patron);

        void BorrowBook(IPatron patron, IBook book);
        void ReturnBook(IPatron patron, IBook book);
    }
}