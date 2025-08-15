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
            if (BorrowedBooks.Contains(book))
            {
                System.Console.WriteLine($"Patron {this.Name} has already borrowed this book.");
            }
            else
            {
                bool success = book.Borrow();

                if (success)
                {
                    this.BorrowedBooks.Add(book);

                    System.Console.WriteLine($"Patron {this.Name} borrowed book {book.Title}.");
                }
                else
                {
                    System.Console.WriteLine($"The book {book.Title} is already borrowed by someone else.");
                }
            }
        }

        public void ReturnBook(IBook book)
        {
            if (!BorrowedBooks.Contains(book))
            {
                System.Console.WriteLine($"Patron {this.Name} never borrowed this book.");
            }
            else
            {
                bool success = book.Return();

                if (success)
                {
                    this.BorrowedBooks.Remove(book);

                    System.Console.WriteLine($"Patron {this.Name} returned book {book.Title}.");
                }
            }
        }
    }
}