using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TicTac
{
    abstract class Action : DecisionOrAction
    {
        /// <summary>
        /// Start printing using this node as root.
        /// </summary>
        public override void printTree()
        {
            printNodeValue();
        }

        /// <summary>
        /// Print the node and its children.
        /// </summary>
        public override void printTree(Boolean isRight, String indent)
        {
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
