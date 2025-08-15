using LibraryKata.Library.Interfaces;

namespace LibraryKata.Library
{
    public class Book : IBook
    {
        public string Title { get; }
        public string Author { get; }
        public bool IsAvailable { get; set; }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
            this.IsAvailable = true;
        }

        public bool Borrow()
        {
            if (!this.IsAvailable) return false;

            this.IsAvailable = false;
            return true;
        }

        public bool Return()
        {
            if (this.IsAvailable) return false;

            this.IsAvailable = true;
            return true;
        }
    }
}