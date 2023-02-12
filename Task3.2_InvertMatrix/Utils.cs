namespace Task3._2_InvertMatrix;

public static class Utils
{

    public static float[][] GetEmptyMatrix()
    {
        float[][] emptyMatrix = new float[3][];
        
        emptyMatrix[0] = new float[] {0, 0, 0};
        emptyMatrix[1] = new float[] {0, 0, 0};
        emptyMatrix[2] = new float[] {0, 0, 0};

        return emptyMatrix;
    }
    
    public static int TryGetInteger( string strNumber )
    {
        if ( int.TryParse( strNumber, out int result ) )
        {
            return result;
        }

        throw new Exception($"{strNumber} is not a number");
    }
}