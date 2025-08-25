using System.Data.Common;
using System.Data.SqlClient;

namespace ADO.NET_hw_1;

class Program
{
    static void Main(string[] args)
    {
       
    var app=new DataAccess();
    while (true)
    {
        Console.WriteLine("Welcome");
        app.ShowCategories();
        Console.WriteLine("Choose one of them:");
        string choice=Console.ReadLine();
        Console.Clear();
        app.SelectCategoryWithId(int.Parse(choice));
        Console.WriteLine("Choose one of them:");
        string choice2=Console.ReadLine();
        app.SelectAuthor(app.AuthorList[int.Parse(choice2)-1],int.Parse(choice));
        Console.WriteLine("Choose one of them:");
        string choice3=Console.ReadLine();
        Console.Clear();
        Console.WriteLine(app.BookList[int.Parse(choice3)-1]);
        Console.WriteLine("1.Change Pages");
        Console.WriteLine("2.Change Quantity");
        Console.WriteLine("Choose one of them:");
        string choice4=Console.ReadLine();
        if (choice4 == "1")
        {
            Console.WriteLine("Enter new page count");
            string newPage = Console.ReadLine();
            app.UpdateBooksPage(app.BookList[int.Parse(choice3)-1],int.Parse(newPage));
        }
        else if (choice4 == "2")
        {
            Console.WriteLine("Enter new quantity");
            string newQuantity = Console.ReadLine();
            app.UpdateBooksQuantity(app.BookList[int.Parse(choice3)-1],int.Parse(newQuantity));
        }
    }        
        
        

    }
}