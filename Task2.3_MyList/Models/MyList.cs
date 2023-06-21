using System.Collections;
using System.Diagnostics;

namespace Task2._3_MyList.Models;

public class MyList<T> : IList<T>
{
    // •	Вставка элемента в начало и в конец списка + 
    // •	Методы begin(), end(), rbegin() и rend(), возвращающие итераторы для перебора элементов списка в прямом и обратном направлении +
    // •	Информация о количестве элементов списка +
    // •	Вставка элемента в позицию списка, заданную итератором
    // •	Удаление элемента из списка в позиции, заданной итератором
    // •	Конструктор копирования и оператор присваивания.
    // •	Конструктор перемещения и перемещающий оператор присваивания.

    private Node<T>? _firstNode;
    private Node<T>? _lastNode;

    public int Count { get; private set; }
    public bool IsReadOnly { get; set; }
    
    public MyList( bool isReadOnly = false )
    {
        IsReadOnly = isReadOnly;
    }

    public T this[int index]
    {
        get => GetNodeAt(index).Data;
        set => Insert( index, value );
    }
    
    public void Add( T item )
    {
        InsertAtTheEnd( item );
    }

    public MyList<T> Copy()
    {
        MyList<T> result = new MyList<T>();
        
        foreach ( T item in this )
        {
            result.Add( item );
        }

        return result;
    }
    
    public void Clear()
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }
        
        _firstNode = null;
        _lastNode = null;
        Count = 0;
    }
    
    // Из интерфейса IList. Мне он не нужен
    public void CopyTo( T[] array, int arrayIndex )
    {
        throw new NotImplementedException();
    }

    public bool Contains( T item )
    {
        return Count != 0 && IndexOf(item) >= 0;
    }
    
    public bool Remove( T item )
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }
        
        int index = IndexOf( item );
        if ( index == -1 )
        {
            return false;
        }
        
        RemoveAt( index );

        return true;
    }
    
    public int IndexOf( T item )
    {
        int index = 0;
        foreach ( T element in this )
        {
            if ( element!.Equals( item ) )
            {
                return index;
            }

            index++;
        }

        return -1;
    }

    public IEnumerator<T> GetEnumerator()
    {
        return GetForwardEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void InsertAtTheStart( T item )
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }
        
        Node<T> node = new Node<T>( item );

        Count++;
        if ( _firstNode == null )
        {
            _firstNode = node;
            _lastNode = node;
            return;
        }

        node.NextNode = _firstNode;
        _firstNode.PreviousNode = node;
        _firstNode = node;
        
    }
    
    public void InsertAtTheEnd( T element )
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }
        
        Node<T> node = new Node<T>( element );

        Count++;
        if ( _firstNode == null )
        {
            _firstNode = node;
            _lastNode = node;
            return;
        }

        node.PreviousNode = _lastNode;
        _lastNode!.NextNode = node;
        _lastNode = node;
    }
    
    public void InsertNew( int position, T item )
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }

        if ( position == Count )
        {
            InsertAtTheEnd( item );
            return;
        }
        
        if ( position == 0 )
        {
            InsertAtTheStart( item );
            return;
        }

        ValidatePosition( position );

        Node<T> prevNode = GetNodeAt( position - 1 );
        Node<T> newNode = new Node<T>( item )
        {
            PreviousNode = prevNode,
            NextNode = prevNode.NextNode
        };
        prevNode.NextNode = newNode;
        
        if ( position == Count - 1 )
        {
            _lastNode = prevNode;
        }

        Count++;
    }
    
    public void Insert( int position, T item )
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }
        
        ValidatePosition( position );
        
        Node<T> existingNode = GetNodeAt( position );
        existingNode.Data = item;
    }

    public void RemoveAt( int position )
    {
        if ( IsReadOnly )
        {
            throw new NotSupportedException( "U can't change readonly list" );
        }
        
        ValidatePosition( position );
        
        Node<T> existingNode = GetNodeAt( position );

        Node<T>? previousNode = existingNode.PreviousNode;
        Node<T>? nextNode = existingNode.NextNode;
        
        if ( previousNode != null )
        {
            previousNode.NextNode = nextNode;
        }
        
        if ( nextNode != null )
        {
            nextNode.PreviousNode = previousNode;
        }

        if ( position == 0 )
        {
            _firstNode = nextNode;
        }
        
        if ( position == Count - 1 )
        {
            _lastNode = previousNode;
        }

        Count--;
    }

    private Node<T> GetNodeAt( int position )
    {
        ValidatePosition( position );

        bool iterateForward = position < (float) Count / 2;
        int currentIndex = iterateForward ? 0 : Count - 1;

        IEnumerator<Node<T>> enumerator = iterateForward ? GetNodeForwardEnumerator() : GetNodeBackwardEnumerator();
        while ( enumerator.MoveNext() )
        {
            if ( currentIndex == position )
            {
                return enumerator.Current;
            }
            
            currentIndex += iterateForward ? 1 : -1;
        }

        throw new UnreachableException( $"Node at position {position} is unreachable" );
    }

    #region Enumerators

    public IEnumerator<T> GetForwardEnumerator()
    {
        IEnumerator<Node<T>> enumerator = GetNodeForwardEnumerator();
        while ( enumerator.MoveNext() )
        {
            yield return enumerator.Current.Data;
        }
    }
    
    public IEnumerator<T> GetBackwardEnumerator()
    {
        IEnumerator<Node<T>> enumerator = GetNodeBackwardEnumerator();
        while ( enumerator.MoveNext() )
        {
            yield return enumerator.Current.Data;
        }
    }
    
    private IEnumerator<Node<T>> GetNodeForwardEnumerator()
    {
        Node<T>? current = _firstNode;
        while ( current != null )
        {
            yield return current;
            current = current.NextNode;
        }
    }
    
    private IEnumerator<Node<T>> GetNodeBackwardEnumerator()
    {
        Node<T>? current = _lastNode;
        while ( current != null )
        {
            yield return current;
            current = current.PreviousNode;
        }
    }

    #endregion
    
    private void ValidatePosition( int position )
    {
        if ( position < 0 || position >= Count )
        {
            throw new ArgumentOutOfRangeException( 
                nameof( position ),
                "Position of element can't be less then 0 and more then amount of elements" );
        }
    }
}