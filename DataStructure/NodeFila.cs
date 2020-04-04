using ProjetoGrafos.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Labirinto.DataStructure
{
    class NodeFila
    {
        public Node Node { get; set; }
        public Edge Edge { get; set; }
        public double Cost { get; set; }
        public NodeFila Next { get; set; }

        public NodeFila(Node node, Edge edge, double cost, NodeFila next)
        {
            this.Node = node;
            this.Edge = edge;
            this.Cost = cost;
            this.Next = next;
        }

        public NodeFila()
        {
        }

        public void Insert(Node node, Edge edge, double cost)
        {

            if (this.Next == null)
            {
                this.Next = new NodeFila(node, edge, cost, null);
                return;
            }
               
            if(this.Next.Cost <= cost)
            {
                this.Next.Insert(node, edge, cost);
            }
                
            else
            {
                NodeFila n = new NodeFila(node, edge, cost, this.Next);
                this.Next = n;
            }
        }


        public NodeFila Remove()
        {
            NodeFila n = this.Next;

            if (this.Next != null)
                this.Next = this.Next.Next;

            return n;
        }

        public bool FilaVazia()
        {
            if (this.Next == null)
                return true;

            return false;
        }

    }
}
