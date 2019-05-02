using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    //简化客户程序与子系统的交互接口，依赖解耦
    ///四个逻辑层，分别为：用户层UI，业务外观层Business Façade，业务规则层Business Rule，数据访问层Data Access
    //只给需求需要的东西，而不让他们关心这个东西是怎么实现的，实现拿来即用，内部变化并不影响接口变化
    //外观模式简化接口，适配器转换接口。桥接注重分离，装饰则是对象拓展功能
   
    //外观类
 public class Mortgage
 {
     private Bank bank = new Bank();
     private Loan loan = new Loan();
     private Credit credit = new Credit();
 
     public bool IsEligible(Customer cust, int amount)
     {
         Console.WriteLine("{0} applies for {1:C} loan\n",
           cust.Name, amount);
 
         bool eligible = true;
 
         if (!bank.HasSufficientSavings(cust, amount))
         {
             eligible = false;
         }
         else if (!loan.HasNoBadLoans(cust))
         {
             eligible = false;
         }
         else if (!credit.HasGoodCredit(cust))
         {
             eligible = false;
         }

       return eligible;
   }
  }//银行子系统
 public class Bank
 {
     public bool HasSufficientSavings(Customer c, int amount)
     {
         Console.WriteLine("Check bank for " + c.Name);
         return true;
     }
 }
 
 //信用证子系统
 public class Credit
 {
     public bool HasGoodCredit(Customer c)
     {
         Console.WriteLine("Check credit for " + c.Name);
         return true;
     }
 }
 
 //贷款子系统
 public class Loan
 {
     public bool HasNoBadLoans(Customer c)
     {
         Console.WriteLine("Check loans for " + c.Name);
         return true;
     }
 }
 
 //顾客类
 public class Customer
 {
     private string name;
 
     public Customer(string name)
     {
         this.name = name;
     }
 
     public string Name
     {
         get { return name; }
     }
 }
//而此时客户程序的实现：
 //客户程序类
 public class MainApp
 {
     public static void Main()
     {
         //外观
         Mortgage mortgage = new Mortgage();
 
         Customer customer = new Customer("Ann McKinsey");
         bool eligable = mortgage.IsEligible(customer, 125000);
 
         Console.WriteLine("\n" + customer.Name +
             " has been " + (eligable? "Approved" : "Rejected")); 
         Console.ReadLine();
     }
 }
}
