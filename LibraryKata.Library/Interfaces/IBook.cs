namespace LibraryKata.Library.Interfaces
{
    public interface IBook
    {
        string Title { get; }
        string Author { get; }
        bool IsAvailable { get; }

        bool Borrow();
        bool Return();
    }
}