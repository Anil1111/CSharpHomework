using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace program1
{
    [Serializable]
    public class OrderService
    {
        private List<Order> orderList;
        public List<Order> OrderList { get => orderList; }

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

        public FileInfo Export(String fileName = "s.xml")
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

        public FileInfo ExportHtml(String url)
        {
            try{
                this.Export();
                XmlDocument doc = new XmlDocument();
                doc.Load("s.xml");
                XPathNavigator nav = doc.CreateNavigator();
                nav.MoveToRoot();
                XslCompiledTransform xt = new XslCompiledTransform();
                xt.Load("s.xslt");
                XmlTextWriter writer = new XmlTextWriter(new FileStream(url, FileMode.Create), System.Text.Encoding.UTF8);
                xt.Transform(nav, null, writer);
            }
            catch (XmlException e)
            {
                Console.WriteLine("Exception caught:" + e.ToString());
            }
            catch (XsltException e)
            {
                Console.WriteLine("Exception caught:" + e.ToString());
            }
            return new FileInfo(url);
        }
    }

}
