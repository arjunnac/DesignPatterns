using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibility
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
    /// The 'AbstractApprover' abstract handler of the resposibility in the change on resposibility
    /// </summary>
    public abstract class AbstractApprover
    {
        protected AbstractApprover successor;
        public void SetSuccessor(AbstractApprover successor)
        {
            this.successor = successor;
        }

        public abstract void HandleRequest(int request);
    }

    /// <summary>
    /// A 'ApproverOne' class
    /// </summary>
    public class ApproverOne : AbstractApprover
    {
        public override void HandleRequest(int request)
        {
            if (request >= 0 && request < 10)
            {
                Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    /// <summary>
    /// A 'ApproverTwo' class
    /// </summary>
    public class ApproverTwo : AbstractApprover
    {
        public override void HandleRequest(int request)
        {
            if (request >= 10 && request < 20)
            {
                Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
        }
    }

    /// <summary>
    /// A 'ApproverThree' class
    /// </summary>
    public class ApproverThree : AbstractApprover
    {
        public override void HandleRequest(int request)
        {
            if (request >= 20 && request < 30)
            {
                Console.WriteLine("{0} handled request {1}", this.GetType().Name, request);
            }
            else if (successor != null)
            {
                successor.HandleRequest(request);
            }
            else
            {
                Console.WriteLine("Request {0} can not be handled. Please set up a call to handle request.", request);
            }
        }
    }


    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    public class Client
    {
        public void Run()
        {
            // Setup Chain of Responsibility
            AbstractApprover firstApprover = new ApproverOne();
            AbstractApprover secondApprover = new ApproverTwo();
            AbstractApprover thirdApprover = new ApproverThree();
            firstApprover.SetSuccessor(secondApprover);
            secondApprover.SetSuccessor(thirdApprover);
            // Generate and process request
            int[] requests = { 2, 5, 14, 22, 18, 3, 27, 20, 40, 50 };
            foreach (int request in requests)
            {
                firstApprover.HandleRequest(request);
            }
        }
    }

}
