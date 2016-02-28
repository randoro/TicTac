using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{

    abstract class Decision : DecisionOrAction
    {
        public DecisionOrAction falseCalc { set; get; }
        public DecisionOrAction trueCalc { set; get; }

        /// <summary>
        /// Start printing using this node as root.
        /// </summary>
        public override void printTree()
        {
            if (trueCalc != null)
            {
                ((DecisionOrAction)trueCalc).printTree(true, "");
            }
            printNodeValue();
            if (falseCalc != null)
            {
                ((DecisionOrAction)falseCalc).printTree(false, "");
            }
        }

        /// <summary>
        /// Print the node and its children.
        /// </summary>
        public override void printTree(Boolean isRight, String indent)
        {
            if (trueCalc != null)
            {
                ((DecisionOrAction)trueCalc).printTree(true, indent + (isRight ? "        " : "       |      "));
            }
            Console.Write(indent);
            if (isRight)
            {
                Console.Write("       /");
            }
            else
            {
                Console.Write("       \\");
            }
            Console.Write("----- ");
            printNodeValue();
            if (falseCalc != null)
            {
                ((DecisionOrAction)falseCalc).printTree(false, indent + (isRight ? "       |      " : "        "));
            }
        }

        /// <summary>
        /// Print NodeValue.
        /// </summary>
        public override void printNodeValue()
        {
            Console.Write(this.GetType().Name);
            Console.Write('\n');
        }
    }
}
