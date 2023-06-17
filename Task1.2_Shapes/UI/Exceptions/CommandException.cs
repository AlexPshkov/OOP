using Task1._2_Shapes.UI.Commands;

namespace Task1._2_Shapes.UI.Exceptions;

public class CommandException : Exception
{
    public CommandException( AbstractUserCommand abstractUserCommand, string message ) 
        : base( $"{message} {abstractUserCommand.CommandUse}" )
    {
    }
}