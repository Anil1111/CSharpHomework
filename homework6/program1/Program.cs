using System;
using System.Runtime.Serialization;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {

            Order myOrder = new Order("Jeff", "firstOrder");
            myOrder.AddDetail("IphoneX", 5, 8000);
            myOrder.AddDetail("Iphone8", 15, 7000);
            myOrder.Tel = "+86123465800";
            Order newOrder = new Order("Jeff", "secondOrder");
            newOrder.AddDetail("Huawei", 99, 10000);
            newOrder.Tel = "+555555555500";
            OrderService service = new OrderService();
            service.AddOrder(myOrder);
            service.AddOrder(newOrder);
            service.Export();
        }
    }
}

class CanNotFindOrder : ApplicationException
{
    public CanNotFindOrder(String message) : base(message) { }
}

class CanNotFindEntry : ApplicationException
{
    public CanNotFindEntry(String message) : base(message) { }
}




