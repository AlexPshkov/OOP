namespace Task1._8.Sort;

public static class QuickSort
{
    public static List<double> Sort( IEnumerable<double> inputList )
    {
        List<double> list = new List<double>( inputList );
        
        Stack<int> stack = new Stack<int>();
        stack.Push( 0 );
        stack.Push( list.Count - 1 );

        while ( stack.Count > 0 )
        {
            int rightIndex = stack.Pop();
            int leftIndex = stack.Pop();

            if ( leftIndex >= rightIndex )
            {
                continue;
            }
            
            int pivotIndex = Partition( list, leftIndex, rightIndex );

            stack.Push( leftIndex );
            stack.Push( pivotIndex - 1 );
            stack.Push( pivotIndex + 1 );
            stack.Push( rightIndex );
        }

        return list;
    }

    private static int Partition( IList<double> list, int leftIndex, int rightIndex )
    {
        double pivotValue = list[rightIndex];
        int firstIndex = leftIndex - 1;

        for ( int secondIndex = leftIndex; secondIndex < rightIndex; secondIndex++ )
        {
            if ( !( list[secondIndex] <= pivotValue ) )
            {
                continue;
            }
            Swap( list, ++firstIndex, secondIndex );
        }

        Swap( list, firstIndex + 1, rightIndex );

        return firstIndex + 1;
    }

    private static void Swap( IList<double> list, int firstIndex, int secondIndex )
    {
        ( list[firstIndex], list[secondIndex] ) = ( list[secondIndex], list[firstIndex] );
    }
}