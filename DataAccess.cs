using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace ADO.NET_hw_1;

public class DataAccess
{
    DbConnection? conn =
        new SqlConnection(
            "Server=localhost,1433;Database=library;User Id=sa;Password=MyS3cure_P@ssw0rd123;TrustServerCertificate=True;");

    public List<string> AuthorList = new List<string>();
    public List<string> BookList = new List<string>();

    public void ShowCategories()
    {
        SqlDataReader? reader = null;
        try
        {
            conn?.Open();

            using SqlCommand cmd = new SqlCommand("SELECT Name FROM Categories", (SqlConnection)conn);
            reader = cmd.ExecuteReader();

            int count = 0;
            while (reader.Read())
            {
                count++;
                Console.WriteLine($"{count}.{reader[0]}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            conn?.Close();
            reader?.Close();
        }
    }

    public void SelectCategoryWithId(int category_id)
    {
        SqlDataReader? reader = null;
        try
        {
            conn?.Open();
            using SqlCommand cmd = new SqlCommand("SELECT * FROM ChooseCategory(@category_id)", (SqlConnection)conn);
            cmd.Parameters.AddWithValue("@category_id", category_id);
            reader = cmd.ExecuteReader();

            int count = 0;
            AuthorList = new List<string>();
            while (reader.Read())
            {
                count++;
                Console.WriteLine($"{count}.{reader[0]}");
                AuthorList.Add(reader[0].ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            conn?.Close();
            reader?.Close();
        }
    }

    public void SelectAuthor(string author, int categoryId)
    {
        SqlDataReader? reader = null;
        try
        {
            conn?.Open();
            using SqlCommand cmd =
                new SqlCommand("SELECT * FROM ChooseAuthors(@author,@categoryId)", (SqlConnection)conn);
            cmd.Parameters.AddWithValue("@author", author);
            cmd.Parameters.AddWithValue("@categoryId", categoryId);
            reader = cmd.ExecuteReader();
            int count = 0;
            BookList = new List<string>();
            while (reader.Read())
            {
                count++;
                Console.WriteLine($"{count}.{reader[0]}");
                BookList.Add(reader[0].ToString());
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            conn?.Close();
            reader?.Close();
        }
    }

    public void UpdateBooksPage(string BookName, int NewPage)
    {
        try
        {
            conn?.Open();

            using SqlCommand cmd = new SqlCommand("UpdateBookPage", (SqlConnection)conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@BookName", SqlDbType.NVarChar, 100) { Value = BookName });

            cmd.Parameters.Add(new SqlParameter("@NewPage", SqlDbType.Int) { Value = NewPage });

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.Clear();
        }
        finally
        {
            conn?.Close();
        }
    }

    
    public void UpdateBooksQuantity(string BookName, int NewQuantity)
    {
        try
        {
            conn?.Open();

            using SqlCommand cmd = new SqlCommand("UpdateBookQuantity", (SqlConnection)conn);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@BookName", SqlDbType.NVarChar, 100) { Value = BookName });

            cmd.Parameters.Add(new SqlParameter("@NewQuantity", SqlDbType.Int) { Value = NewQuantity });

            int rowsAffected = cmd.ExecuteNonQuery();
            Console.Clear();

        }
        finally
        {
            conn?.Close();
        }
    }

}