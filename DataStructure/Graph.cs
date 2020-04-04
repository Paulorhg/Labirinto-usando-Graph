using Labirinto.DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGrafos.DataStructure
{
    /// <summary>
    /// Classe que representa um grafo.
    /// </summary>
    public class Graph
    {

        private List<Node> nodes;

        public Graph()
        {
            nodes = new List<Node>();
        }

        public List<Node> ShortestPath(string begin, string end)
        {

            Node n = Find(begin);
            Node nEnd = Find(end);
            //nof -> nó auxiliar para o nó da fila de prioridade
            NodeFila nof;

            if(n != null && nEnd != null)
            {
                //nf -> ponteiro para a fila de prioridade
                NodeFila nf = new NodeFila();
                List<Node> list = new List<Node>();

                nf.Insert(n, new Edge(null,n), 0);

                while (!nf.FilaVazia())
                {
                    nof = nf.Remove();

                    if(nof.Node.Visited == false)
                    {
                        nof.Node.Parent = nof.Edge.From;
                        nof.Node.Visited = true;
                        list.Add(nof.Node);

                        if (nof.Node == nEnd)
                            break;
                        
                        foreach (Edge e in nof.Node.Edges)
                        {
                            nf.Insert(e.To, e, e.Cost + nof.Cost);
                        }
                    }
                }

                foreach(Node no in nodes)
                {
                    no.Visited = false;
                }
                return list;
            }
            return null;
        }

        public List<Node> BreadthFirstSearch(string begin)
        {
            
            Node n = Find(begin);
            
            if(n != null)
            {
                List<Node> list = new List<Node>();
                Fila f = new Fila(225);

                f.Insert(n);
                n.Visited = true;

                while(!f.FilaVazia())
                {
                    n = f.Remove();
                    list.Add(n);

                    foreach(Edge e in n.Edges)
                    {
                        if(e.To.Visited == false)
                        {
                            e.To.Visited = true;
                            e.To.Parent = n;
                            f.Insert(e.To);
                        }
                    }
                }

                foreach(Node m in nodes)
                {
                    m.Visited = false;
                }

                return list;
            }
            return null;
        }

        public List<Node> DepthFirstSearch(string begin)
        {
            
            Node n = Find(begin);
            
            if(n != null)
            {
                Pilha p = new Pilha(225);
                List<Node> list = new List<Node>();
                bool ver = true;

                p.Push(n);
                list.Add(n);
                n.Visited = true;

                do
                {
                    if (ver == false)
                    {
                        n = p.Pop();
                    }

                    ver = false;

                    foreach (Edge e in n.Edges)
                    {
                        if (e.To.Visited == false)
                        {
                            ver = true;

                            e.To.Parent = n;
                            n = e.To;
                            n.Visited = true;
                            p.Push(n);
                            list.Add(n);
                            break;
                        }
                    }

                } while (!p.PilhaVazia());
                
                foreach(Node m in nodes)
                {
                    m.Visited = false;
                }
                return list;
            }

            return null;
        }

        public void AddNode(string name, object info)
        {
            if (Find(name) == null)
                nodes.Add(new Node(name, info));
        }

        public void AddEdge(string nameFrom, string nameTo, int cost)
        {
            Node from = Find(nameFrom);
            Node to = Find(nameTo);

            if (from != null && to != null)
            {
                from.AddEdge(to, cost);
            }
        }

        private Node Find(string name)
        {
            foreach (Node n in nodes)
            {
                if (n.Name.Equals(name))
                {
                    return n;
                }
            }

            return null;
        }

    }
}
