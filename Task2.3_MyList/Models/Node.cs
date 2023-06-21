namespace Task2._3_MyList.Models;

internal class Node<T>
{
    public T Data { get; set; }
    public Node<T>? PreviousNode { get; set; }
    public Node<T>? NextNode { get; set; }

    public Node( T data, Node<T>? previousNode = null, Node<T>? nextNode = null )
    {
        Data = data;
        PreviousNode = previousNode;
        NextNode = nextNode;
    }
}