using LibraryKata.Library;
using LibraryKata.Library.Interfaces;

namespace LibraryKata.Tests
{
    public class LibraryTests
    {
        private LibraryApp lib;

        [SetUp]
        public void SetUp()
        {
            this.lib = new LibraryApp();
            this.lib.AddBook(new Book("Harry Potter", "J. K. Rowling"));
            this.lib.AddBook(new Book("The Hobbit", "J. R. R. Tolkien"));
            this.lib.AddBook(new Book("The Lord of the Rings", "J. R. R. Tolkien"));
            this.lib.AddBook(new Book("Pirates of the Carribean: The Price of Freedom", "Ann C. Crispin"));
            this.lib.AddBook(new Book("Alex Rider", "Anthony Horowitz"));
            this.lib.AddBook(new Book("The Belgariad", "David Eddings"));

            this.lib.AddPatron(new Patron("NPC 1"));
            this.lib.AddPatron(new Patron("NPC 2"));
            this.lib.AddPatron(new Patron("NPC 3"));
            this.lib.AddPatron(new Patron("NPC 4"));
        }

        [Test]
        public void Check_That_AddBook_Adds_Book_To_Books_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testBook = new Book("test book", "test author");

            // Act
            Console.SetOut(sw);
            this.lib.AddBook(testBook);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Books.Contains(testBook), Is.True);
                Assert.That(sw.ToString(), Is.EqualTo("Added book test book to the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_AddBook_Does_Not_Add_Book_If_Already_In_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testBook = new Book("Harry Potter", "J. K. Rowling");

            // Act
            Console.SetOut(sw);
            this.lib.AddBook(testBook);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Books.Contains(testBook), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Error: The book Harry Potter is already in the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_RemoveBook_Removes_Book_From_Books_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testBook = new Book("test book", "test author");

            // Act
            this.lib.AddBook(testBook);

            Console.SetOut(sw);
            this.lib.RemoveBook(testBook);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Books.Contains(testBook), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Removed book test book from the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_RemoveBook_Does_Not_Remove_Book_If_Not_In_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testBook = new Book("test book", "test author");

            // Act
            Console.SetOut(sw);
            this.lib.RemoveBook(testBook);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Books.Contains(testBook), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Error: Couldn't find the book test book in the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_GetAllBooks_Returns_Books_List()
        {
            // Assert
            Assert.That(this.lib.GetAllBooks, Is.EqualTo(this.lib.Books));
        }

        [Test]
        public void Check_That_GetBookByAuthor_Returns_Books_List()
        {
            // Act
            var booksByAuthor = this.lib.GetBookByAuthor("J. R. R. Tolkien");

            // Assert
            Assert.Multiple(() =>
            {
                foreach (IBook book in booksByAuthor)
                {
                    Assert.That(book.Author, Is.EqualTo("J. R. R. Tolkien"));
                    Assert.That(this.lib.Books.Contains(book), Is.True);
                }
            });
        }

        [Test]
        public void Check_That_GetBookByTitle_Returns_Book()
        {
            // Act
            var booksByTitle = this.lib.GetBookByTitle("The Hobbit");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(booksByTitle.Title, Is.EqualTo("The Hobbit"));
                Assert.That(this.lib.Books.Contains(booksByTitle), Is.True);
            });
        }

        [Test]
        public void Check_That_GetPatronByName_Returns_Patron()
        {
            // Act
            var patronByName = this.lib.GetPatronByName("NPC 1");

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(patronByName.Name, Is.EqualTo("NPC 1"));
                Assert.That(this.lib.Patrons.Contains(patronByName), Is.True);
            });
        }

        [Test]
        public void Check_That_AddPatron_Adds_Patron_To_Patron_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testPatron = new Patron("test name");

            // Act
            Console.SetOut(sw);
            this.lib.AddPatron(testPatron);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Patrons.Contains(testPatron), Is.True);
                Assert.That(sw.ToString(), Is.EqualTo("Added patron test name to the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_AddPatron_Does_Not_Add_Patron_If_Already_In_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testPatron = new Patron("NPC 1");

            // Act
            Console.SetOut(sw);
            this.lib.AddPatron(testPatron);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Patrons.Contains(testPatron), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Error: The patron NPC 1 is already a member of the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_RemovePatron_Removes_Patron_From_Patron_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testPatron = new Patron("test name");

            // Act
            this.lib.AddPatron(testPatron);

            Console.SetOut(sw);
            this.lib.RemovePatron(testPatron);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Patrons.Contains(testPatron), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Removed patron test name from the library.\r\n"));
            });
        }

        [Test]
        public void Check_That_RemovePatron_Does_Not_Remove_Patron_If_Not_In_List()
        {
            // Assign
            StringWriter sw = new StringWriter();
            var testPatron = new Patron("test name");

            // Act
            Console.SetOut(sw);
            this.lib.RemovePatron(testPatron);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.lib.Patrons.Contains(testPatron), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Error: The patron test name is not a member of the library. Failed to remove.\r\n"));
            });
        }

        [Test]
        public void Check_That_BorrowBook_Works_As_Intened()
        {
            // Assign
            StringWriter sw = new StringWriter();
            IPatron patron = this.lib.GetPatronByName("NPC 1");
            IBook book = this.lib.GetBookByTitle("Harry Potter");

            // Act
            Console.SetOut(sw);
            this.lib.BorrowBook(patron, book);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sw.ToString(), Is.EqualTo("Patron NPC 1 borrowed book Harry Potter.\r\n"));
                Assert.That(patron.BorrowedBooks.Contains(book), Is.True);
            });
        }
        
        [Test]
        public void Check_That_ReturnBook_Works_As_Intened()
        {
            // Assign
            StringWriter sw = new StringWriter();
            IPatron patron = this.lib.GetPatronByName("NPC 1");
            IBook book = this.lib.GetBookByTitle("Harry Potter");

            // Act
            this.lib.BorrowBook(patron, book);

            Console.SetOut(sw);
            this.lib.ReturnBook(patron, book);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(sw.ToString(), Is.EqualTo("Patron NPC 1 returned book Harry Potter.\r\n"));
                Assert.That(patron.BorrowedBooks.Contains(book), Is.False);
            });
        }
    }
}