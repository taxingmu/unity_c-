using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//一次性实现一些算法的不变部分,如数据库的登录
namespace TemplateMetod
{
    //算法不变的部分用虚函数写好，变得部分写成抽象函数
    class Program
    {
        static void Main(string[] args)
        {
            DataAccessObject dao;
            dao = new Categories();
            dao.Run(); dao = new Products(); dao.Run();
            // Wait for user 
            Console.Read();

        }
    }
}
//现有上到下，抽象出步骤
public abstract class DataAccessObject

{
    protected string connectionString;

    protected DataSet dataSet;
    //因为以及有默认方法实现，所以用virtual虚函数
    protected virtual void Connect()

    {
        connectionString =

            "Server=.;User Id=sa;Password=;Database=Northwind";

    }

    protected abstract void Select();

    protected abstract void Display();


    protected virtual void Disconnect()

    {
        connectionString = "";
    }

    // The "Template Method" 

    public void Run()

    {
        Connect();

        Select();

        Display();

        Disconnect();
    }
}
//实现类
class Categories : DataAccessObject

{
    protected override void Select()
    {
        string sql = "select CategoryName from Categories";

        SqlDataAdapter dataAdapter = new SqlDataAdapter(

            sql, connectionString);

        dataSet = new DataSet();

        dataAdapter.Fill(dataSet, "Categories");

    }

    protected override void Display()

    {

        Console.WriteLine("Categories ---- ");

        DataTable dataTable = dataSet.Tables["Categories"];

        foreach (DataRow row in dataTable.Rows)

        {

            Console.WriteLine(row["CategoryName"].ToString());

        }

        Console.WriteLine();

    }
}
class Products : DataAccessObject

{
    protected override void Select()

    {
        string sql = "select top 10 ProductName from Products";

        SqlDataAdapter dataAdapter = new SqlDataAdapter(

            sql, connectionString);

        dataSet = new DataSet();

        dataAdapter.Fill(dataSet, "Products");

    }

    protected override void Display()

    {

        Console.WriteLine("Products ---- ");

        DataTable dataTable = dataSet.Tables["Products"];

        foreach (DataRow row in dataTable.Rows)

        {
            Console.WriteLine(row["ProductName"].ToString());

        }

        Console.WriteLine();

    }

}

