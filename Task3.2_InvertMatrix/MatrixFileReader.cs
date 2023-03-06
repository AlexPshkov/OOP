namespace Task3._2_InvertMatrix;

public class MatrixFileReader : StreamReader
{
    private const int MatrixSize = 3;
    
    public float[][] Matrix { get; } = Utils.GetEmptyMatrix();

    private int _lineCounter;

    public MatrixFileReader( string filePath ) : base( filePath )
    {
        try
        {
            StartReader();
        }
        finally
        {
            Close();
            Dispose();
        }
    }

    public sealed override void Close()
    {
        base.Close();
    }

    private void StartReader()
    {
        while ( !EndOfStream )
        {
            HandleNewLine( ReadLine() );
        }
        
        if ( _lineCounter != MatrixSize )
        {
            throw new Exception( $"Invalid matrix format. Must be {MatrixSize}x{MatrixSize}" );
        }
    }

    private void HandleNewLine( string? line )
    {
        if ( string.IsNullOrEmpty( line ) )
        {
            return;
        }
        _lineCounter += 1;

        string[] lineArguments = line.Trim().Split( " " );
        if ( lineArguments.Length != MatrixSize )
        {
            throw new Exception( $"Invalid matrix format. Must be {MatrixSize}x{MatrixSize}" );
        }

        for ( int i = 0; i < lineArguments.Length; i++ )
        {
            Matrix[_lineCounter - 1][i] = Utils.TryGetInteger(lineArguments[i]);
        }
    }
}