using LibraryKata.Library;

namespace LibraryKata.Tests
{
    public class BookTests
    {
        private Book book;

        [SetUp]
        public void SetUp()
        {
            // Assign
            this.book = new Book("example book", "example author");
        }

        [Test]
        public void Check_That_Book_Title_Is_Correct()
        {
            // Assert
            Assert.That(this.book.Title, Is.EqualTo("example book"));
        }

        [Test]
        public void Check_That_Book_Author_Is_Correct()
        {
            // Assert
            Assert.That(this.book.Author, Is.EqualTo("example author"));
        }

        [Test]
        public void Check_That_Borrow_Book_Makes_Book_Unavailable()
        {
            // Act
            bool success = this.book.Borrow();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(this.book.IsAvailable, Is.False);
            });
        }

        [Test]
        public void Check_That_Borrowing_Non_Available_Book_Returns_False()
        {
            // Act
            _ = this.book.Borrow();
            bool success = this.book.Borrow();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(this.book.IsAvailable, Is.False);
            });
        }

        [Test]
        public void Check_That_Return_Non_Available_Book_Makes_Book_Available()
        {
            // Act
            _ = this.book.Borrow();
            bool success = this.book.Return();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.True);
                Assert.That(this.book.IsAvailable, Is.True);
            });
        }

        [Test]
        public void Check_That_Returning_An_Available_Book_Returns_False()
        {
            // Act
            bool success = this.book.Return();

            // Assert
            Assert.Multiple(() =>
            {
                Assert.That(success, Is.False);
                Assert.That(this.book.IsAvailable, Is.True);
            });
        }
    }
}