using System;

namespace NewEgg
{
    class Program
    {
        static void Main(string[] args)
        {
            OrderInfo orderinfo = new OrderInfo();

            try
            {
                orderinfo.GetOrderInfo();
            } 
            catch(Exception ex)
            {
                Console.WriteLine("Exit with error.");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }

            Console.WriteLine("Exit.");
            Console.ReadKey();
        } 
    }
}
