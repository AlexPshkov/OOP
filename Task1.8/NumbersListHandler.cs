namespace Task1._8;

public static class NumbersListHandler
{
    private const int DigitsAfterComma = 3;
    
    /// <summary>
    /// Элементы, стоящие на четных позициях массива умножить на 2,
    /// а из элементов, стоящих на нечетных позициях, вычесть сумму всех неотрицательных элементов
    /// </summary>
    public static void Handle( List<double> list )
    {
        double positiveSum = list
            .Where( number => number > 0 )
            .Select( number => double.Round( number, DigitsAfterComma ) )
            .Sum();

        for ( int index = 0; index < list.Count; index++ )
        {
            double number = list[index];
            list[index] = ( index + 1 ) % 2 == 0 ? number * 2 : number - positiveSum;
        }
    }
}