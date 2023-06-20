namespace Task1._3_FindMaxEx;

public static class ListUtils
{
    public static bool FindMaxEx<T>( List<T> list, IComparer<T> comparer, out T maxValue )
    {
        if ( !list.Any() )
        {
            maxValue = default;
            return false;
        }

        int position = 0;
        for ( int index = 0; index < list.Count; ++index )
        {
            if ( comparer.Compare( list[position], list[index] ) < 0 )
            {
                position = index;
            }
        }
        maxValue = list[position];

        return true;
    }
}