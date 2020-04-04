using System;

namespace ProjetoGrafos.DataStructure
{

    public class Fila
    {
        private Node[] elements;
        private int rear, front, tam, cont = 0;

        public Fila(int max)
        {
            tam = max;
            elements = new Node[tam];
            front = 0;
            rear = 0;

        }


        public void Insert(Node x)
        {
            if (FilaCheia())
                throw new Exception("Fila Cheia");

            else
            {
                elements[rear] = x;

                if (rear == tam -1)
                    rear = 0;
                else
                    rear++;

                cont++;
            }
        }

        public Node Remove()
        {
            Node x;

            if (FilaVazia())
                throw new Exception("Fila Cheia");

            else
            {
                x = elements[front];
                cont--;
                if (front > tam)
                {
                    front = 0;
                }
                else
                    front++;
            }
            return x;
        }

        public bool FilaCheia()
        {
            return cont == tam;
        }

        public bool FilaVazia()
        {

            return cont == 0;
        }
    }
}
