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

        public void Borrow()
        {

        }

        public void Return()
        {
            
        }
    }
}