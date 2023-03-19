namespace Task4._4_PrimeNumbers;

public static class EratosthenesSieve
{
    private const int StartIndex = 2;
    
    public static HashSet<int> GeneratePrimeNumbersSet( int upperBound )
    {
        if ( upperBound < StartIndex )
        {
            return new HashSet<int>();
        }
        
        bool[] isPrime = new bool[upperBound + 1];
        for ( int index = StartIndex; index <= upperBound; index++ )
        {
            isPrime[index] = true;
        }

        for ( int index = StartIndex; index * index <= upperBound; index++ )
        {
            if ( !isPrime[index] )
            {
                continue;
            }

            for ( int secondIndex = index * index; secondIndex <= upperBound; secondIndex += index )
            {
                isPrime[secondIndex] = false;
            }
        }

        HashSet<int> primeNumbers = new HashSet<int>();
        for ( int index = StartIndex; index <= upperBound; index++ )
        {
            if ( isPrime[index] )
            {
                primeNumbers.Add( index );
            }
        }

        return primeNumbers;
    }
}