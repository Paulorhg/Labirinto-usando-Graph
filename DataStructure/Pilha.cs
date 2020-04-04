using ProjetoGrafos.DataStructure;
using System;

public class Pilha
{
    private Node[] elementos;
    private int topo, max;

    public Pilha(int maximo)
    {
        max = maximo;
        elementos = new Node[max];
        topo = 0;
    }

    public void Push(Node x) {
        if (PilhaCheia())
            throw new Exception("Pilha Cheia!");

        elementos[topo++] = x;
    }

    public Node Pop() {
        if (PilhaVazia())
            throw new Exception("Pilha Vazia!");

        return elementos[--topo];
    }

    public bool PilhaCheia()
    {
        return topo == max;
    }

    public bool PilhaVazia()
    {
        return topo == 0;
    }

}
