namespace LibraryKata.Library.Interfaces
{
    public interface IPatron
    {
        string Name { get; }
        List<IBook> BorrowedBooks { get; }

        void BorrowBook(IBook book);
        void ReturnBook(IBook book);
    }
}