using System;
using System.Collections.Generic;

namespace console_library.Models
{
    class Library
    {
        public string Name { get; set; }
        public string Owner { get; set; }
        public string City { get; set; }
        private List<Book> AvailableBooks { get; set; }
        private List<Book> CheckedOutBooks { get; set; }



        public void AddBook(Book book)
        {
            if(book.Available)
            {
                AvailableBooks.Add(book);
            }else
            {
                CheckedOutBooks.Add(book);
            }
        }

        public void ViewBooks(List<Book> books)
        {
            int count = 1;
            foreach (Book book in books)
            {
                System.Console.WriteLine($"{count}. {book.Title} - {book.Author}");
                count ++;
            }
        }

        public bool PrintDirectory()
        {
            bool StayInLibrary = true;
            System.Console.WriteLine("(V)iew all books");
            System.Console.WriteLine("(R)eturn a book");
            System.Console.WriteLine("(C)heckout a book");
            System.Console.WriteLine("(Q) to leave the Library.");
            string input = Console.ReadLine();
            switch(input.ToLower()) {
                case "v":
                    ViewBooks(AvailableBooks);
                    break;
                case "r":
                    ReturnBook();
                    break;
                case "c":
                    CheckoutBook();
                    break;
                case "q":
                    StayInLibrary = false;
                    break;
                default:
                    System.Console.WriteLine("Invalid Option! \nPress Enter to continue.");
                    Console.ReadLine();
                    Console.Clear();
                    PrintDirectory();
                    break;
            }
            return StayInLibrary;
        }

        public void CheckoutBook()
        {
            System.Console.WriteLine("Enter the number of the book you'd like to checkout.");
            ViewBooks(AvailableBooks);
            Book bookToCheckout = ValidateUserInput(AvailableBooks);
            if (bookToCheckout == null) return;
            bookToCheckout.Available = true;
            AvailableBooks.Remove(bookToCheckout);
            CheckedOutBooks.Add(bookToCheckout);
            System.Console.WriteLine($"Enjoy your copy of {bookToCheckout.Title}.");
        }


        public void ReturnBook()
        {
            System.Console.WriteLine("Enter the number of the book you'd like to return.");
            ViewBooks(CheckedOutBooks);
            Book bookToReturn = ValidateUserInput(CheckedOutBooks);
            //null check to prevent breaking errors
            if(bookToReturn == null) return;
            //if found a book to return then:
            //1. reassign the available property to true
            //2. remove the book from the checkoutbooks list
            //3. add the book to the availablebooks list
            bookToReturn.Available = true;
            CheckedOutBooks.Remove(bookToReturn);
            AvailableBooks.Add(bookToReturn);
            System.Console.WriteLine("Thanks for returning {0}", bookToReturn.Title);
        }
       
       
        public Book ValidateUserInput(List<Book> books)
        {
            if (books.Count == 0)
            {
                System.Console.WriteLine("No books are checked out currently.");
                return  null;
            }
            int bookNum = 0;
            while(!Int32.TryParse(Console.ReadLine(), out bookNum) || bookNum < 1 || bookNum > books.Count) {
                System.Console.WriteLine("Not a valid choice.");
            }
            return books[bookNum-1];
            }
        

        public void Greeting()
        {
            System.Console.WriteLine($"Welcome to {City}. Thanks for visiting {Name}.");
        }

        //constructor method
        //always always is named the same as the class name
        //is used to assign values to the class properties
        public Library(string name, string owner, string city)
        {
            Name = name;
            Owner = owner;
            City = city;
            AvailableBooks = new List<Book>();
            CheckedOutBooks = new List<Book>();
        }

    }
    }