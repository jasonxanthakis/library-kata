using LibraryKata.Library;

namespace LibraryKata.Tests
{
    public class PatronTests
    {
        private Patron patron1;
        private Patron patron2;
        private Book book1;

        [SetUp]
        public void SetUp()
        {
            // Assign
            this.patron1 = new Patron("example patron 1");
            this.patron2 = new Patron("example patron 2");

            this.book1 = new Book("example book 1", "example author");
        }

        [Test]
        public void Check_That_Patron_Name_Is_Correct()
        {
            // Assert
            Assert.That(this.patron1.Name, Is.EqualTo("example patron 1"));
        }

        [Test]
        public void Check_That_Patron_Can_Borrow_An_Available_Book()
        {
            // Assign
            StringWriter sw = new StringWriter();

            // Act
            Console.SetOut(sw);
            this.patron1.BorrowBook(this.book1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.book1.IsAvailable, Is.False);
                Assert.That(this.patron1.BorrowedBooks.Contains(this.book1), Is.True);
                Assert.That(sw.ToString(), Is.EqualTo("Patron example patron 1 borrowed book example book 1.\r\n"));
            });
        }

        [Test]
        public void Check_That_Patron_Cannot_Borrow_A_Book_He_Has_Already_Borrowed()
        {
            // Assign
            StringWriter sw = new StringWriter();

            // Act
            this.patron1.BorrowBook(this.book1);

            Console.SetOut(sw);
            this.patron1.BorrowBook(this.book1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.book1.IsAvailable, Is.False);
                Assert.That(this.patron1.BorrowedBooks.Contains(this.book1), Is.True);
                Assert.That(sw.ToString(), Is.EqualTo("Patron example patron 1 has already borrowed this book.\r\n"));
            });
        }

        [Test]
        public void Check_That_Patron_Cannot_Borrow_A_Book_Already_Borrowed_By_Others()
        {
            // Assign
            StringWriter sw = new StringWriter();

            // Act
            this.patron2.BorrowBook(this.book1);

            Console.SetOut(sw);
            this.patron1.BorrowBook(this.book1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.book1.IsAvailable, Is.False);
                Assert.That(this.patron1.BorrowedBooks.Contains(this.book1), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("The book example book 1 is already borrowed by someone else.\r\n"));
            });
        }

        [Test]
        public void Check_That_Patron_Can_Return_A_Book_He_Has_Borrowed()
        {
            // Assign
            StringWriter sw = new StringWriter();

            // Act
            this.patron1.BorrowBook(this.book1);

            Console.SetOut(sw);
            this.patron1.ReturnBook(this.book1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.book1.IsAvailable, Is.True);
                Assert.That(this.patron1.BorrowedBooks.Contains(this.book1), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Patron example patron 1 returned book example book 1.\r\n"));
            });
        }

        [Test]
        public void Check_That_Patron_Cannot_Return_An_Available_Book()
        {
            // Assign
            StringWriter sw = new StringWriter();

            // Act
            Console.SetOut(sw);
            this.patron1.ReturnBook(this.book1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.book1.IsAvailable, Is.True);
                Assert.That(this.patron1.BorrowedBooks.Contains(this.book1), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Patron example patron 1 never borrowed this book.\r\n"));
            });
        }
        
        [Test]
        public void Check_That_Patron_Cannot_Return_Books_Borrowed_By_Others()
        {
            // Assign
            StringWriter sw = new StringWriter();

            // Act
            this.patron2.BorrowBook(this.book1);

            Console.SetOut(sw);
            this.patron1.ReturnBook(this.book1);

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(this.book1.IsAvailable, Is.False);
                Assert.That(this.patron1.BorrowedBooks.Contains(this.book1), Is.False);
                Assert.That(sw.ToString(), Is.EqualTo("Patron example patron 1 never borrowed this book.\r\n"));
            });
        }
    }
}