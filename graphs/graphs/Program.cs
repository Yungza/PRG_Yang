using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace graphs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Nodes node1 = new Nodes(1);
            Nodes node2 = new Nodes(2);
            Nodes node3 = new Nodes(3);
            Nodes node5 = new Nodes(5);
            Nodes node6 = new Nodes(6);
            Nodes node7 = new Nodes(7);
            Nodes node8 = new Nodes(8);
            node1.childrensss.Add(node1);
            node1.childrensss.Add(node2);
            node1.childrensss.Add(node3);
            node2.AddChildren(node5, node6);
            node3.AddChildren(node7, node8);
            Nodes currentNode = node1;
            node1.parent = null;

            while (true)
            {
                currentNode = Move(currentNode);
                Writeinfos(currentNode);
            }
        }
        static Nodes Move(Nodes CurrentNode)
        {
            if (CurrentNode.childrensss != null && CurrentNode.parent != null)
            {
                Console.WriteLine("pohyb WAD");
                ConsoleKeyInfo action = Console.ReadKey();
                switch (action.Key)
                {
                    case ConsoleKey.W:
                        CurrentNode = CurrentNode.parent;
                        break;
                    case ConsoleKey.A:
                        CurrentNode = CurrentNode.childrensss[0];
                        break;
                    case ConsoleKey.D:
                        CurrentNode = CurrentNode.childrensss[1];
                        break;
                }
            }
            else if (CurrentNode.parent != null)
            {
                Console.WriteLine("můžeš se pouze vrátit");
                CurrentNode = CurrentNode.parent;
            }
            else
            {
                Console.WriteLine("pohyb AD");
                ConsoleKeyInfo action = Console.ReadKey();
                switch (action.Key)
                {
                    case ConsoleKey.A:
                        CurrentNode = CurrentNode.childrensss[0];
                        break;
                    case ConsoleKey.D:
                        CurrentNode = CurrentNode.childrensss[1];
                        break;
                }
            }
            return CurrentNode;
        }
        static void Writeinfos(Nodes currentNode)
        {
            if (currentNode.parent == null)
            {
                Console.WriteLine($"jseš na prvním uzlu, jeho děti: {currentNode.childrensss[0].index} a {currentNode.childrensss[1].index} ");
            }
            else if(currentNode.childrensss == null)
            {
                Console.WriteLine($"jseš na {currentNode.index}. uzlu jeho rodič je {currentNode.parent.index}, nemá děti");
            }
            else
            {
                Console.WriteLine($"stojíš na {currentNode.index}. uzlu, jeho rodič je {currentNode.parent.index}, jeho děti jsou {currentNode.childrensss[0].index} a {currentNode.childrensss[1].index}");
            }
            
        }
    }
    public class Nodes
    {
        public int index;
        public Nodes parent;
        public List<Nodes> childrensss = new List<Nodes>();
        public Nodes(int index)
        {
            this.index = index;
        }
        public void AddChildren(Nodes node1, Nodes node2)
        {
            parent = node1;
            node1.parent = this;
            node1.childrensss = null;
            node2.parent = this;
            node2.childrensss = null;
            childrensss.Add(node1);
            childrensss.Add(node2);
        }
    }
}
