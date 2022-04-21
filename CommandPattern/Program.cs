using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandPattern
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

    /// <summary>
    /// The Command design pattern encapsulates a request as an object, thereby letting you parameterize clients with different requests, queue or log requests, and support undoable operations.
    /// The 'Command' abstract command defienition.
    /// </summary>
    public abstract class Command
    {
        protected Receiver receiever;
        // Constructor
        public Command(Receiver receiever)
        {
            this.receiever = receiever;
        }
        public abstract void Execute();
    }

    /// <summary>
    /// The 'ConcreteCommand' class
    /// </summary>
    public class ConcreteCommand : Command
    {
        // Constructor
        public ConcreteCommand(Receiver receiever) : base(receiever)
        {
        }

        public override void Execute()
        {
            receiever.Action();
        }
    }

    /// <summary>
    /// The 'Receiver' class
    /// </summary>
    public class Receiver
    {
        public void Action()
        {
            Console.WriteLine("Called Receiver.Action()");
        }
    }

    /// <summary>
    /// The 'Invoker' class
    /// </summary>
    public class Invoker
    {
        Command command;
        public void SetCommand(Command command)
        {
            this.command = command;
        }

        public void ExecuteCommand()
        {
            command.Execute();
        }
    }

    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    public class Client
    {
        public void Run()
        {
            // Create receiver, command, and invoker
            Receiver receiever = new Receiver();
            Command command = new ConcreteCommand(receiever);
            Invoker invoker = new Invoker();

            // Set and execute command
            invoker.SetCommand(command);
            invoker.ExecuteCommand();
        }
    }

}
