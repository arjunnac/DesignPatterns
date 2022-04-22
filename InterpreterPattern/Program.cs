using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterpreterPattern
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
    /// The 'Context' class
    /// </summary>
    public class Context
    {
        // Builder uses a complex series of step
        public Context()
        {
        }
    }

    /// <summary>
    /// The 'AbstractExpression' abstract class
    /// </summary>
    public abstract class AbstractExpression
    {
        public abstract void Interpret(Context context);
    }

    /// <summary>
    /// The 'TerminalExpression' abstract class
    /// </summary>
    public class TerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called TerminalExpression.Interpret()");
        }
    }

    /// <summary>
    /// The 'NonTerminalExpression' abstract class
    /// </summary>
    public class NonTerminalExpression : AbstractExpression
    {
        public override void Interpret(Context context)
        {
            Console.WriteLine("Called NonTerminalExpression.Interpret()");
        }
    }

    /// <summary>
    /// The 'Client' class. Interaction environment for the products.
    /// </summary>
    public class Client
    {
        public void Run()
        {
            Context context = new Context();
            // Usually a tree 
            List<AbstractExpression> expressionList = new List<AbstractExpression>();
            // Populate 'abstract syntax tree' 
            expressionList.Add(new TerminalExpression());
            expressionList.Add(new NonTerminalExpression());
            expressionList.Add(new TerminalExpression());
            expressionList.Add(new TerminalExpression());
            // Interpret
            foreach (AbstractExpression expr in expressionList)
            {
                expr.Interpret(context);
            }
        }

    }


}
