using LibraryKata.Library.Interfaces;

namespace LibraryKata.Library
{
    public class Library : ILibrary
    {
        public List<IBook> Books { get; }
        public List<IPatron> Patrons { get; }

        public Library()
        {
            this.Books = new List<IBook>();
            this.Patrons = new List<IPatron>();
        }

        public void AddBook(IBook book)
        {

        }
        public void RemoveBook(IBook book)
        {

        }

        public IEnumerable<IBook> GetBookByAuthor(string Author)
        {
            return this.Books.Where(b => b.Author == Author);
        }
        public IEnumerable<IBook> GetBookByTitle(string title)
        {
            return this.Books.Where(b => b.Title == title);
        }
        public List<IBook> GetAllBooks()
        {
            return this.Books;
        }

        public void AddPatron(IPatron patron)
        {

        }
        public void RemovePatron(IPatron patron)
        {

        }

        public void BorrowBook(IPatron patron, IBook book)
        {

        }
        public void ReturnBook(IPatron patron, IBook book)
        {
            
        }
    }
}