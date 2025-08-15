using LibraryKata.Library.Interfaces;

namespace LibraryKata.Library
{
    public class Patron : IPatron
    {
        public string Name { get; }
        public List<IBook> BorrowedBooks { get; }

        public Patron(string name)
        {
            this.Name = name;
            this.BorrowedBooks = new List<IBook>();
        }

        public void BorrowBook(IBook book)
        {

        }

        public void ReturnBook(IBook book)
        {
            
        }
    }
}