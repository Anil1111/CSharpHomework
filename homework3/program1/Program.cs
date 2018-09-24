using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program1
{
    class Program
    {
        static void Main(string[] args)
        {
            ShapeStore store = new ShapeStore();
            Shape triangle = store.GetShape("triangle",new double[3] { 2, 4, 5 });
            triangle.Show();
            Shape rectangle = store.GetShape("rectangle",new double[2] { 1, 4 });
            rectangle.Show();
            Shape circle = store.GetShape("circle", new double[1] { 1 });
            circle.Show();
            Shape square = store.GetShape("square", new double[1] { 4 });
            square.Show();
        }
    }

    abstract class Shape
    {
        protected double area;
        public double GetArea()
        {
            return area;
        }
        virtual public void Show()
        {
            Console.WriteLine("面积为：" + area);
        }
        abstract protected void SetArea();
    }

    class SimpleShapeFactory
    {
        public Shape CreateShape(String type,double[] datas)
        {
            Shape shape = null;
            switch(type)
            {
                case "triangle":
                case "Triangle":
                    shape = new Triangle(datas);
                    break;
                case "rectangle":
                case "Rectangle":
                    shape = new Rectangle(datas);
                    break;
                case "square":
                case "Square":
                    shape = new Square(datas);
                    break;
                case "circle":
                case "Circle":
                    shape = new Circle(datas);
                    break;
            }
            return shape;
        }
    }

    class ShapeStore
    {
        private SimpleShapeFactory factory;
        public ShapeStore()
        {
            factory = new SimpleShapeFactory();
        }
        public Shape GetShape(String type,double[] datas)
        {
            return factory.CreateShape(type,datas);
        }
    }

    class Triangle : Shape
    {
        private double[] edges;
        public Triangle(double[] edges)
        {
            this.edges = new double[3];
            for(int i = 0;i<3;i++)
            {
                this.edges[i] = edges[i];
            }
            SetArea();
        }
        override protected void SetArea()
        {
            double p = (edges[0] + edges[1] + edges[2]) / 2;
            area = Math.Sqrt(p * (p - edges[0]) * (p - edges[1]) * (p - edges[2]));
        }
        override public void Show()
        {
            Console.Write("该三角形边长分别为： ");
            foreach(double i in edges)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();
            base.Show();
        }
    }

    class Rectangle:Shape
    {
        protected double a;
        protected double b;
        public Rectangle(double[] edges)
        {
            a = edges[0];
            b = edges[1];
            SetArea();
        }
        public Rectangle(double edge)
        {
            a = edge;
            b = edge;
            SetArea();
        }
        override protected void SetArea()
        {
            area = a * b;
        }
        override public void Show()
        {
            Console.Write("该长方形边长分别为： ");
            Console.WriteLine(a + "  " + b);
            base.Show();
        }
    }

    class Circle : Shape
    {
        private double r;
        private const double PI = 3.1415926;
        public Circle(double[] edges)
        {
            r = edges[0];
            SetArea();
        }
        override protected void SetArea()
        {
            area = PI * r * r;
        }
        override public void Show()
        {
            Console.Write("该圆形半径为： ");
            Console.WriteLine(r);
            base.Show();
        }
    }

    class Square:Rectangle
    {
        public Square(double[] edges):base(edges[0]){ }
        override public void Show()
        {
            Console.Write("该正方形边长为： ");
            Console.WriteLine(a);
            Console.WriteLine("面积为： " + area);
        }
    }
}
