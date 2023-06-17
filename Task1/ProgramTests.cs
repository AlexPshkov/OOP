using System.Drawing;
using NUnit.Framework;
using Task1._2_Shapes.Shapes;
using Task1._2_Shapes.Shapes.Implementation;
using Rectangle = Task1._2_Shapes.Shapes.Implementation.Rectangle;

namespace Task1._2_Shapes.Tests;

public class ProgramTests
{
    [Test]
    public void Program_GetShapeWithHighestArea_NormalInput_CorrectAnswer()
    {
        // Arrange 
        Circle circle = new Circle( new Point( 0, 0 ), 10, Color.Aqua, Color.Aqua );
        Rectangle rectangle = new Rectangle( new Point( 0, 0 ), new Point( 2, 2 ), Color.Aqua, Color.Brown );
        Triangle triangle = new Triangle( new Point( 0, 0 ), new Point( 1, 1 ),new Point( 2, 0 ), Color.Aqua, Color.Red );

        Program.AddShape( circle );
        Program.AddShape( rectangle );
        Program.AddShape( triangle );

        // Act 
        IShape? highestAreaShape = Program.GetShapeWithHighestArea();

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( highestAreaShape.GetArea(), Is.InRange( 314.159, 314.1593 ) );
            Assert.That( highestAreaShape.GetPerimeter(), Is.InRange( 62.831, 62.832 ) );
            Assert.That( highestAreaShape.GetOutlineColor(), Is.EqualTo( Color.Aqua ) );
        } );
    }
    
    [Test]
    public void Program_GetShapeWithSmallestPerimeter_NormalInput_CorrectAnswer()
    {
        // Arrange 
        Circle circle = new Circle( new Point( 0, 0 ), 10, Color.Aqua, Color.Aqua );
        Rectangle rectangle = new Rectangle( new Point( 0, 0 ), new Point( 2, 2 ), Color.Aqua, Color.Brown );
        Triangle triangle = new Triangle( new Point( 0, 0 ), new Point( 1, 1 ),new Point( 2, 0 ), Color.Aqua, Color.Red );

        Program.AddShape( circle );
        Program.AddShape( rectangle );
        Program.AddShape( triangle );

        // Act 
        IShape? highestAreaShape = Program.GetShapeWithSmallestPerimeter();

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( highestAreaShape.GetArea(), Is.InRange( 1.553, 1.554 ) );
            Assert.That( highestAreaShape.GetPerimeter(), Is.InRange( 4.828, 4.829 ) );
            Assert.That( highestAreaShape.GetOutlineColor(), Is.EqualTo( Color.Red ) );
        } );
    }
    
    [Test]
    public void Program_GetShapeWithSmallestPerimeter_NoShapes_NoExceptions()
    {
        // Arrange
        Program.ClearShapes();
        
        // Act 
        IShape? highestAreaShape = Program.GetShapeWithSmallestPerimeter();

        // Assert
        Assert.That( highestAreaShape, Is.EqualTo( null ) );
    }
    
    [Test]
    public void Program_GetShapeWithHighestArea_NoShapes_NoExceptions()
    {
        // Arrange
        Program.ClearShapes();
        
        // Act 
        IShape? highestAreaShape = Program.GetShapeWithHighestArea();

        // Assert
        Assert.That( highestAreaShape, Is.EqualTo( null ) );
    }
}