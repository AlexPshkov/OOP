namespace Task1._2_Shapes.UI.Commands;

public abstract class AbstractUserCommand
{
    public abstract string CommandUse { get; }
    public abstract void Execute( string[] args );
}