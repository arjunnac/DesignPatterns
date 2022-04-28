using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediatorPattern
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


    ///This structural code demonstrates the Mediator pattern facilitating loosely coupled communication between different objects and object types. 
    ///The mediator is a central hub through which all interaction must take place.   

    /// <summary>
    /// The 'Mediator' abstract class
    /// </summary>
    public abstract class Mediator
    {
        public abstract void SendMessage(string message, AbstractParticipant participant);
        public abstract void Register(AbstractParticipant participant);
    }

    // <summary>
    /// The 'ConcreteMediator' concrete class
    /// </summary>
    public class ConcreteMediator : Mediator
    {
        ConcretePaticipantOne participantOne;
        ConcretePaticipantTwo participantTwo;

        public override void SendMessage(string message, AbstractParticipant participant)
        {
            if (participant == participantOne)
            {
                participantTwo.ReceiveMessage(message);
            }
            else
            {
                participantOne.ReceiveMessage(message);
            }
        }

        public override void Register(AbstractParticipant participant)
        {
            if (participant is ConcretePaticipantOne participant1)
            {
                participantOne = participant1;
                Console.WriteLine("Register participantOne with ConcreteMediator");
            }
            if (participant is ConcretePaticipantTwo participant2)
            {
                participantTwo = participant2;
                Console.WriteLine("Register participantTwo with ConcreteMediator");
            }
        }
    }

    /// <summary>
    /// The AbstractParticipant abstract class
    /// </summary>
    public abstract class AbstractParticipant
    {
        protected Mediator mediator;
        // Constructor
        public AbstractParticipant(Mediator mediator)
        {
            this.mediator = mediator;
            if (mediator != null)
                mediator.Register(this);
        }

        public virtual void SendMessage(string message)
        {
            mediator.SendMessage(message, this);
        }

        public virtual void ReceiveMessage(string message)
        {
            Console.WriteLine("AbstractParticipant gets message: " + message);
        }
    }

    /// <summary>
    /// A 'ConcretePaticipantOne' class
    /// </summary>
    public class ConcretePaticipantOne : AbstractParticipant
    {
        // Constructor
        public ConcretePaticipantOne(Mediator mediator) : base(mediator)
        {
        }

        public override void SendMessage(string message)
        {
            mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine("ConcretePaticipantOne gets message: " + message);
        }
    }

    /// <summary>
    /// A 'ConcretePaticipantTwo' class
    /// </summary>
    public class ConcretePaticipantTwo : AbstractParticipant
    {
        // Constructor
        public ConcretePaticipantTwo(Mediator mediator) : base(mediator)
        {
        }

        public override void SendMessage(string message)
        {
            mediator.SendMessage(message, this);
        }

        public override void ReceiveMessage(string message)
        {
            Console.WriteLine("ConcretePaticipantTwo gets message: " + message);
        }
    }

    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    public class Client
    {
        public void Run()
        {
            Mediator mediator = new ConcreteMediator();
            ConcretePaticipantOne participantOne = new ConcretePaticipantOne(mediator);
            ConcretePaticipantTwo participantTwo = new ConcretePaticipantTwo(mediator);
            participantOne.SendMessage("How are you?");
            participantTwo.SendMessage("Fine, thanks");
        }
    }

}
