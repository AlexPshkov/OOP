using Task1._3_FindMaxEx.Models;

namespace Task1._3_FindMaxEx.Comparers;

public class SportsmenWeightComparer : IComparer<Sportsmen>
{
    public int Compare( Sportsmen left, Sportsmen right )
    {
        if ( ReferenceEquals( left, right ) ) return 0;
        if ( ReferenceEquals( null, right ) ) return 1;
        if ( ReferenceEquals( null, left ) ) return -1;

        return left.Weight.CompareTo( right.Weight );
    }
}