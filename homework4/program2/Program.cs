using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Order myOrder = new Order("Jeff", "firstOrder");
                myOrder.AddDetail("IphoneX", 5, 8000);
                myOrder.AddDetail("Iphone8", 15, 7000);
                Order newOrder = new Order("Jeff", "secondOrder");
                newOrder.AddDetail("Huawei", 99, 10000);
                OrderService service = new OrderService();
                service.AddOrder(myOrder);
                service.AddOrder(newOrder);
                service.DeleteByName("secondOrder");
                //service.CheckByName("secondOrder");
                Order aim = service.CheckByName("firstOrder");
                aim.Print();
                aim.ChangePrice("IphoneX", 5000);
                aim.Print();
                aim.ChangeCount("Huawei", 5);
            }
            catch (CanNotFindOrder e)
            {
                Console.WriteLine(e.Message);
            }
            catch(CanNotFindEntry e)
            {
                Console.WriteLine(e.Message);
            }
            
        }
    }

    class Order
    {
        private Dictionary<String,OrderDetails> data;
        private String client;
        private String id;
        private String name;

        public Order(String client,String name="")
        {
            DateTime dateTime = DateTime.Now;
            id = dateTime.ToString();
            this.client = client;
            this.name = name;
            data = new Dictionary<String, OrderDetails>();
        }

        public String Name { get => name; set => name = value; }
        public String Client { get => client; }
        public String Id { get => id;}
        

        public void AddDetail(String name, double count, double price)
        {
            if(data.ContainsKey(name))
            {
                if(data[name].Price!=price)
                {
                    return;
                }
                data[name].Count += count;
            }
            else
            {
                data.Add(name, new OrderDetails(price, count));
            }
        }

        public void DeleteDetail(String name)
        {
            data.Remove(name);
        }

        public void ChangeCount(String name,double count)
        {
            if(!data.ContainsKey(name))
            {
                throw new CanNotFindEntry($"不存在名为{name}的条目。");
            }
            data[name].Count = count;
        }

        public void ChangePrice(String name, double price)
        {
            if (!data.ContainsKey(name))
            {
                throw new CanNotFindEntry($"不存在名为{name}的条目。");
            }
            data[name].Price = price;
        }

        public void Print()
        {
            foreach(String itemName in data.Keys)
            {
                Console.WriteLine($"名称：{itemName}, 价格：{data[itemName].Price}， 数目：{data[itemName].Count}");
            }
        }
    }

    class OrderDetails
    {
        private double price;
        private double count;

        public OrderDetails(double price,double count)
        {
            this.price = price;
            this.count = count;
        }

        //封装属性
        public double Price { get => price; set => price = value; }
        public double Count { get => count; set => count = value; }
    }

    class OrderService
    {
        private List<Order> orderList;

        public OrderService()
        {
            orderList = new List<Order>();
        }

        public void AddOrder(Order newOrder)
        {
            orderList.Add(newOrder);
        }

        public void DeleteById(String id)
        {
            bool find = false;
            for(int i=orderList.Count-1;i>=0;i--)
            {
                if (orderList[i].Id == id)
                {
                    orderList.Remove(orderList[i]);
                }
            }
            if(!find)
            {
                throw new CanNotFindOrder($"不存ID为{id}的订单.");
            }
        }

        public void DeleteByName(String name)
        {
            bool find = false;
            for (int i = orderList.Count - 1; i >= 0; i--)
            {
                if (orderList[i].Name == name)
                {
                    orderList.Remove(orderList[i]);
                    find = true;
                }
            }
            if(!find)
            {
                throw new CanNotFindOrder($"不存在名为{name}的订单.");
            }
        }

        public void DeleteByClient(String client)
        {
            bool find = false;
            for (int i = orderList.Count - 1; i >= 0; i--)
            {
                if (orderList[i].Client == client)
                {
                    orderList.Remove(orderList[i]);
                    find = true;
                }
            }
            if(!find)
            {
                throw new CanNotFindOrder($"不存客户为{client}的订单.");
            }
        }

        public Order CheckByName(String name)
        {
            foreach (Order order in orderList)
            {
                if (order.Name == name)
                {
                    return order;
                }
            }
            throw new CanNotFindOrder($"不存在名为{name}的订单.");
        }

        public List<Order> CheckByClient(String client)
        {
            List<Order> list = new List<Order>();
            foreach (Order order in orderList)
            {
                if (order.Client == client)
                {
                    list.Add(order);
                }
            }
            if(list.Count==0)
            {
                throw new CanNotFindOrder($"不存客户为{client}的订单.");
            }
            return list;
        }

        public Order CheckById(String Id)
        {
            foreach (Order order in orderList)
            {
                 if (order.Id == Id)
                 {
                     return order;
                 }
            }
            throw new CanNotFindOrder($"不存ID为{Id}的订单.");
        }
    }


    class CanNotFindOrder:ApplicationException
    {
        public CanNotFindOrder(String message) : base(message) { }
    }

    class CanNotFindEntry:ApplicationException
    {
        public CanNotFindEntry(String message) : base(message) { }
    }
}
