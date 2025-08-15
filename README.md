# Library Management System

This repository contains a simple digital library management system. This system allows users to manage the books and patrons of a library.

## Prerequisites
- Microsoft .NET 8.0.0^

## Installation
1. Clone this repository to your local machine
2. Change directory into the main directory `library-kata`
3. Run the command `dotnet build`

## How to Use the Application
1. Change directory into the library directory using `cd .\library-kata`
2. Run the command `dotnet run`

## How to Use The Application Programmatically
1. Change directory into the library directory using `cd .\library-kata`
2. Alter the Program.cs file to run how you want it to run. 
    - Program.cs has LibraryApp object and adds a few books and patrons as a demo.
3. Run the command `dotnet run`

<i>Here is a list of the functionality provided by the LibraryApp class</i>

| Command | Parameters | Returns | Description of Function |
| ------- | ---------- | ------- | ----------------------- |
| `new LibraryApp()` | None | An object (e.g. LibraryApp lib) | The constructor |
| `lib.Books` | None | A list of book objects | A getter method for the list of books currently stored by the library |
| `lib.Patrons` | None | A list of patron objects | A getter method for the list of patrons in the library |
| `lib.AddBook()` | IBook book | Nothing | Tries to add a new book to the Books list and outputs the result to the console |
| `lib.RemoveBook()` | IBook book | Nothing | Tries to remove a book from the Books list and outputs the result to the console |
| `lib.GetBookByAuthor()` | string Author | An enumerable of books | Returns all books written by the given author |
| `lib.GetBookByTitle()` | string title | One book | Returns the only book with that title |
| `lib.GetPatronByName()` | string name | One patron | Returns the only patron with that name |
| `lib.GetAllBooks()` | None | A list of books object | Returns the books list |
| `lib.AddPatron()` | IPatron patron | Nothing | Tries to add a new patron to the Patrons list and outputs the result to the console |
| `lib.RemovePatron()` | IPatron patron | Nothing | Tries to remove a patron from the Patrons list and outputs the result to the console |
| `lib.BorrowBook()` | IPatron patron, IBook book | Nothing | Tries to borrow a book on behalf of a patron and outputs the result to the console |
| `lib.ReturnBook()` | IPatron patron, IBook book | Nothing | Tries to return a book on behalf of a patron and outputs the result to the console |

<i>Note: IBook has 2 values: string Title and string Author</i>

<i>Note: IPatron has 1 value: string Name</i>

## How to Run Tests
1. Change directory into the main directory `library-kata`
2. Run the command `dotnet test`