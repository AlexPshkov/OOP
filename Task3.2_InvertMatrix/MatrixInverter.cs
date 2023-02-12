namespace Task3._2_InvertMatrix;

public static class MatrixInverter
{

    public static float[][] InvertMatrix( IReadOnlyList<float[]> matrix )
    {
        float determinant = GetDeterminant( matrix );
        if ( determinant == 0 )
        {
            throw new Exception( "Can't invert. Determinant is 0" );
        }

        return InvertMatrix( determinant, matrix );
    }

    private static float[][] InvertMatrix( float determinant, IReadOnlyList<float[]> matrix )
    {
        float[][] invertedMatrix = Utils.GetEmptyMatrix();

        invertedMatrix[0][0] = matrix[1][1] * matrix[2][2] - matrix[1][2] * matrix[2][1];
        invertedMatrix[0][1] = -( matrix[0][1] * matrix[2][2] - matrix[0][2] * matrix[2][1] );
        invertedMatrix[0][2] = matrix[0][1] * matrix[1][2] - matrix[0][2] * matrix[1][1];

        invertedMatrix[1][0] = -( matrix[1][0] * matrix[2][2] - matrix[1][2] * matrix[2][0] );
        invertedMatrix[1][1] = matrix[0][0] * matrix[2][2] - matrix[0][2] * matrix[2][0];
        invertedMatrix[1][2] = -( matrix[0][0] * matrix[1][2] - matrix[0][2] * matrix[1][0] );

        invertedMatrix[2][0] = matrix[1][0] * matrix[2][1] - matrix[1][1] * matrix[2][0];
        invertedMatrix[2][1] = -( matrix[0][0] * matrix[2][1] - matrix[0][1] * matrix[2][0] );
        invertedMatrix[2][2] = matrix[0][0] * matrix[1][1] - matrix[0][1] * matrix[1][0];

        for ( int i = 0; i < 3; i++ )
        {
            for ( int j = 0; j < 3; j++ )
            {
                invertedMatrix[i][j] *= 1 / determinant;
            }
        }

        return invertedMatrix;
    }
    
    private static float GetDeterminant( IReadOnlyList<float[]> matrix )
    {
        float determinant = 0;

        determinant += matrix[0][0] * (matrix[1][1] * matrix[2][2] - matrix[1][2] * matrix[2][1]);
        determinant -= matrix[0][1] * (matrix[1][0] * matrix[2][2] - matrix[1][2] * matrix[2][0]);
        determinant += matrix[0][2] * (matrix[1][0] * matrix[2][1] - matrix[1][1] * matrix[2][0]);
        
        return determinant;
    }
}