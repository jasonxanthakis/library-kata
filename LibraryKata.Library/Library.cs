using LibraryKata.Library.Interfaces;

namespace LibraryKata.Library
{
    public class LibraryApp : ILibrary
    {
        public List<IBook> Books { get; }
        public List<IPatron> Patrons { get; }

        public LibraryApp()
        {
            this.Books = new List<IBook>();
            this.Patrons = new List<IPatron>();
        }

        public void AddBook(IBook book)
        {
            if (IsBookInList(book))
            {
                System.Console.WriteLine($"Error: The book {book.Title} is already in the library.");
            }
            else
            {
                this.Books.Add(book);
                System.Console.WriteLine($"Added book {book.Title} to the library.");
            }
        }
        public void RemoveBook(IBook book)
        {
            if (!IsBookInList(book))
            {
                System.Console.WriteLine($"Error: Couldn't find the book {book.Title} in the library.");
            }
            else
            {
                this.Books.Remove(book);
                System.Console.WriteLine($"Removed book {book.Title} from the library.");
            }
        }

        public IEnumerable<IBook> GetBookByAuthor(string Author)
        {
            return this.Books.Where(b => b.Author == Author);
        }
        public IBook GetBookByTitle(string title)
        {
            return this.Books.Where(b => b.Title == title).First();
        }
        public IPatron GetPatronByName(string name)
        {
            return this.Patrons.Where(b => b.Name == name).First();
        }
        public List<IBook> GetAllBooks()
        {
            return this.Books;
        }

        public void AddPatron(IPatron patron)
        {
            if (IsPatronInList(patron))
            {
                System.Console.WriteLine($"Error: The patron {patron.Name} is already a member of the library.");
            }
            else
            {
                this.Patrons.Add(patron);
                System.Console.WriteLine($"Added patron {patron.Name} to the library.");
            }
        }
        public void RemovePatron(IPatron patron)
        {
            if (!IsPatronInList(patron))
            {
                System.Console.WriteLine($"Error: The patron {patron.Name} is not a member of the library. Failed to remove.");
            }
            else
            {
                this.Patrons.Remove(patron);
                System.Console.WriteLine($"Removed patron {patron.Name} from the library.");
            }
        }

        public void BorrowBook(IPatron patron, IBook book)
        {
            patron.BorrowBook(book);
        }
        public void ReturnBook(IPatron patron, IBook book)
        {
            patron.ReturnBook(book);
        }

        private bool IsBookInList(IBook book)
        {
            if (this.Books.Count == 0) return false;

            foreach (var borrowed in this.Books)
            {
                if (borrowed.Title == book.Title) return true;
            }

            return false;
        }
        
        private bool IsPatronInList(IPatron patron)
        {
            if (this.Patrons.Count == 0) return false;

            foreach (var inList in this.Patrons)
            {
                if (inList.Name == patron.Name) return true;
            }

            return false;
        }
    }
}