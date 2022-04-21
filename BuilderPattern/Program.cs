using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.Run();
            Console.ReadLine();
        }
    }
    public class Client
    {
        public void Run()
        {
            // Create director and builders
            DirectorClass director = new DirectorClass();
            BuilderClass b1 = new ConcreteBuilderOne();
            BuilderClass b2 = new ConcreteBuilderTwo();
            // Construct two products
            director.Construct(b1);
            ProductClass p1 = b1.GetProductFromBuilder();
            p1.Show();
            director.Construct(b2);
            ProductClass p2 = b2.GetProductFromBuilder();
            p2.Show();
        }
    }
    /// <summary>
    /// The 'DirectorClass' class
    /// </summary>
    class DirectorClass
    {
        // Builder uses a complex series of step
        public void Construct(BuilderClass builder)
        {
            builder.BuilderMethod1();
            builder.BuilderMethod2();
            builder.BuilderMethod3();
        }
    }

    /// <summary>
    /// The 'BuilderClass' abstract class
    /// </summary>
    abstract class BuilderClass
    {
        public abstract void BuilderMethod1();
        public abstract void BuilderMethod2();
        public abstract void BuilderMethod3();
        public abstract ProductClass GetProductFromBuilder();
    }

    /// <summary>
    /// The 'ProductClass' class
    /// </summary>
    class ProductClass
    {
        private List<string> _parts = new List<string>();
        public void Add(string part)
        {
            _parts.Add(part);
        }
        public void Show()
        {
            Console.WriteLine("\nActual product Parts -------");
            foreach (string part in _parts)
                Console.WriteLine(part);
        }
    }

    /// <summary>
    /// The 'ConcreteBuilderOne' class 
    /// </summary>
    class ConcreteBuilderOne : BuilderClass
    {
        private ProductClass _product = new ProductClass();
        public override void BuilderMethod1()
        {
            _product.Add("ConcreteBuilderOne " + " BuilderMethod1");
        }
        public override void BuilderMethod2()
        {
            _product.Add("ConcreteBuilderOne " + " BuilderMethod2");
        }
        public override void BuilderMethod3()
        {
            _product.Add("ConcreteBuilderOne " + " BuilderMethod3");
        }

        public override ProductClass GetProductFromBuilder()
        {
            return _product;
        }
    }

    /// <summary>
    /// The 'ConcreteBuilderTwo' class 
    /// </summary>
    class ConcreteBuilderTwo : BuilderClass
    {
        private ProductClass _product = new ProductClass();
        public override void BuilderMethod1()
        {
            _product.Add("ConcreteBuilderTwo " + " BuilderMethod1");
        }
        public override void BuilderMethod2()
        {
            _product.Add("ConcreteBuilderTwo " + "BuilderMethod2");
        }
        public override void BuilderMethod3()
        {
            _product.Add("ConcreteBuilderTwo " + "BuilderMethod3");
        }

        public override ProductClass GetProductFromBuilder()
        {
            return _product;
        }
    }

}
