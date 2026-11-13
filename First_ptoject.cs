using System;
using System.Text;
using System.Collections;
using System.Drawing;
using Pastel;
static class BookTrack
{
    public static string[] books = new string[8];
    public static int bookCount = 0;

    public static void AddBook()
    {
        if (bookCount <= books.Length)
        {
            Console.Write("Enter the title of the book please: ");
            string title = (Console.ReadLine() ?? "").Trim();

            if (string.IsNullOrEmpty(title))
            {
                Console.WriteLine("Please Enter Something sir.".Pastel(Color.Red));
            }
            else
            {
                books[bookCount] = title;
                Console.WriteLine("The book is added successfully \u2714".Pastel(Color.Orange));
                bookCount ++;
            }
        }
        else {Console.WriteLine("Sorry, the library is full");}
    }
    public static void ViewBooks()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("Sorry ,the library is empty".Pastel(Color.Red));
            return;
        }
        else
        {
            for (int i=0; i < bookCount; i++)
            {
                if (books[i].EndsWith("Borrowed"))
                {
                    Console.WriteLine((i+1) + "." + books[i].Pastel(Color.Blue));
                }
                else
                {
                    Console.WriteLine((i+1) + "." + books[i].Pastel(Color.Yellow));
                }
            }
        }
    }

    public static void BorrowBook()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("There are no books to borrow".Pastel(Color.Red));
        }
        Console.Write("Enter the book number to borrow: ");
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            int bookIndex = input - 1;
            if (bookIndex >= 0 && bookIndex < bookCount)
            {
                if (books[bookIndex].EndsWith("Borrowed"))
                {
                    Console.WriteLine("This book is already borrowed".Pastel(Color.Red));
                }
                else
                {
                    books[bookIndex] = books[bookIndex] + " Borrowed";
                    Console.WriteLine("The book is borrowed successfully".Pastel(Color.Blue));
                }
            }
            else
            {
                Console.WriteLine("Please enter a number within the renge of books avaialbe . [Hint : If you do not know the number of books choose option 'View books']".Pastel(Color.Red));
            }
        }
        else
        {
            Console.WriteLine("Please enter a valid number".Pastel(Color.Red));
        }
    }
    public static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        bool running = true;
        while (running)
        {
            Console.WriteLine("Choose what you want to do: ");
            Console.WriteLine("1. Add a book\n2. View books\n3. Borrow a book\n4. Exit");
            
            string choice = (Console.ReadLine() ?? "").Trim();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    ViewBooks();
                    break;
                case "3":
                    BorrowBook();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Exiting program".Pastel(Color.PaleVioletRed));
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please choose 1, 2, 3, 4.".Pastel(Color.Red));
                    break;
            }
        }
    }
}
