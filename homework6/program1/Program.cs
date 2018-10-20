using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization;
using System.Xml.Serialization;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {

            Order myOrder = new Order("Jeff", "firstOrder");
            myOrder.AddDetail("IphoneX", 5, 8000);
            myOrder.AddDetail("Iphone8", 15, 7000);
            Order newOrder = new Order("Jeff", "secondOrder");
            newOrder.AddDetail("Huawei", 99, 10000);
            OrderService service = new OrderService();
            service.AddOrder(myOrder);
            service.AddOrder(newOrder);
            service.Export();
            OrderService newService = OrderService.Import("s.xml");
            newService.Export("g.xml");
            
            
            }
        }
    }

    [Serializable]
    public class Order
    {
        private List<OrderDetails> data;
        private String client;
        private String id;
        private String name;

        public Order()
        {
            data = new List<OrderDetails>();
            client = "";
            DateTime dateTime = DateTime.Now;
            id = dateTime.ToString();
            name = "";
        }
        public Order(String client, String name = "")
        {
            DateTime dateTime = DateTime.Now;
            id = dateTime.ToString();
            this.client = client;
            this.name = name;
            data = new List< OrderDetails>();
        }

        public String Name { get => name; set => name = value; }
        public String Client { get => client; set => client = value; }
        public String Id { get => id; set => id = id; }
        public List<OrderDetails> Data { get => data; }

        public Double GetSum()
        {
            double prices = data
                .Select(detail => detail.Count * detail.Price)
                .Sum();
            return prices;
        }

        public void AddDetail(String name, double count, double price)
        {
            var select = data
                .Where(d => d.Name == name)
                .Select(d => d)
                .FirstOrDefault();
            if(select == null)
            {
                data.Add(new OrderDetails(price, count, name));
            }
            else
            {
                if(select.Price!=price)
                {
                    return;
                }
                select.Count += count;
            }
        }

        public void DeleteDetail(String name)
        {
            foreach(OrderDetails detail in data)
            {
                if(detail.Name == name)
                {
                    data.Remove(detail);
                }
            }
        }

        public void ChangeCount(String name, double count)
        {
            var select = data.Where(s => s.Name == name).Select(s => s).FirstOrDefault();
            if (select==null)
            {
                throw new CanNotFindEntry($"不存在名为{name}的条目。");
            }
            select.Count = count;
        }

        public void ChangePrice(String name, double price)
        {
            var select = data.Where(s => s.Name == name).Select(s => s).FirstOrDefault();
            if (select==null)
            {
                throw new CanNotFindEntry($"不存在名为{name}的条目。");
            }
            select.Price = price;
        }

        public void Print()
        {
            foreach (OrderDetails item in data)
            {
                Console.WriteLine($"名称：{item.Name}, 价格：{item.Price}， 数目：{item.Count}");
            }
        }
    }

    [Serializable]
    public class OrderDetails
    {
        private double price;
        private double count;
        private String name;

        public OrderDetails()
        {
            price = 0;
            count = 0;
            name = "";
        }
        public OrderDetails(double price, double count, String name)
        {
            this.price = price;
            this.count = count;
            this.name = name;
        }

        //封装属性
        public double Price { get => price; set => price = value; }
        public double Count { get => count; set => count = value; }
        public string Name { get => name; set => name = value; }
    }

    [Serializable]
    public class OrderService
    {
        private List<Order> orderList;
        public List<Order> OrderList { get=>orderList; }

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
            for (int i = orderList.Count - 1; i >= 0; i--)
            {
                if (orderList[i].Id == id)
                {
                    orderList.Remove(orderList[i]);
                }
            }
            if (!find)
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
            if (!find)
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
            if (!find)
            {
                throw new CanNotFindOrder($"不存客户为{client}的订单.");
            }
        }

        public Order CheckByName(String name)
        {
            Order order = orderList
                .Where(s => s.Name == name)
                .Select(s => s)
                .FirstOrDefault();
            if (order != null)
            {
                return order;
            }
            throw new CanNotFindOrder($"不存在名为{name}的订单.");
        }

        public List<Order> CheckByClient(String client)
        {
            var list = orderList
                .Where(order => order.Client == client)
                .Select(order => order);
            if (list.Count() == 0)
            {
                throw new CanNotFindOrder($"不存客户为{client}的订单.");
            }
            return list.ToList();
        }

        public Order CheckById(String Id)
        {
            Order order = orderList
                .Where(o => o.Id == Id)
                .Select(o => o)
                .FirstOrDefault();
            if (order != null)
            {
                return order;
            }
            throw new CanNotFindOrder($"不存ID为{Id}的订单.");
        }

        public List<Order> CheckOverTenThousand()
        {
            List<Order> list = orderList
                .Where(order => order.GetSum() > 10000)
                .Select(order => order)
                .ToList();
            return list;
        }

        public FileInfo Export(String fileName="s.xml")
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
            FileStream fs = new FileStream(fileName, FileMode.Create);
            try
            {
                xmlser.Serialize(fs, this);
            }
            finally
            {
                fs.Close();
            }
            return new FileInfo(fileName);
        }

        public static OrderService Import(String fileName)
        {
            FileStream fs;
            fs = new FileStream(fileName, FileMode.Open);
            XmlSerializer xmlser = new XmlSerializer(typeof(OrderService));
            OrderService service = (OrderService)xmlser.Deserialize(fs);
            fs.Close();
            return service;
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
}
