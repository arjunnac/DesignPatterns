using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingletonPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            SingletonConnection.GetInstance();
            SingletonConnection.GetInstance();
            Console.ReadLine();
        }
    }


    sealed class SingletonConnection
    {
        private static SingletonConnection _instance;
        // Lock synchronization object
        private static object syncLock = new object();

        //Constructor is proteccted or private.
        protected SingletonConnection()
        {
        }

        ///Method which returns single instance of the class				   
        public static SingletonConnection GetInstance()
        {
            if (_instance == null)
            {
                lock (syncLock)
                {
                    if (_instance is null)
                    {
                        _instance = new SingletonConnection();
                    }
                }
            }
            return _instance;
        }
    }

}
