using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoPattern
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

    //The Memento design pattern without violating encapsulation,
    //captures and externalizes an object's internal state so that the object can be restored to this state later.

    // <summary>
    /// The 'Originator' class
    /// </summary>
    public class Originator
    {
        string state;
        public string State
        {
            get => state;
            set
            {
                state = value;
                Console.WriteLine("State = " + state);
            }
        }

        // Creates Memento 
        public Memento StoreObjectState() => new Memento(state);

        // Restores original state
        public void RestoreObjectState(Memento memento)
        {
            Console.WriteLine("Restoring state...");
            State = memento.State;
        }
    }

    /// <summary>
    /// The 'Memento' class
    /// </summary>
    public class Memento
    {
        string state;
        // Constructor
        public Memento(string state)
        {
            this.state = state;
        }
        public string State => state;
    }

    /// <summary>
    /// The 'MementoHandler' class
    /// </summary>
    public class MementoHandler
    {
        Memento memento;
        public Memento Memento
        {
            set => memento = value;
            get => memento;
        }
    }


    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    public class Client
    {
        public void Run()
        {
            Originator originator = new Originator();
            originator.State = "On";
            // Store internal state of the object
            MementoHandler handler = new MementoHandler();
            handler.Memento = originator.StoreObjectState();
            // Continue changing originator object state
            originator.State = "Off";
            // Restore saved state
            originator.RestoreObjectState(handler.Memento);
        }
    }



}
