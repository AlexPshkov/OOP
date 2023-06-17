using System.Drawing;
using NUnit.Framework;
using Task1._2_Shapes.Shapes.Implementation;
using Rectangle = Task1._2_Shapes.Shapes.Implementation.Rectangle;

namespace Task1._2_Shapes.Tests;

public class ShapesTests
{
    [Test]
    public void Circle_Ctor_NormalValue_CorrectCreate()
    {
        // Arrange 
        Point centerPoint = new Point( 0, 0 );

        // Act 
        Circle circle = new Circle( centerPoint, 10, Color.Aqua, Color.Brown );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( circle.GetArea(), Is.InRange( 314.1, 314.2 ) );
            Assert.That( circle.GetPerimeter(), Is.InRange( 62.83, 62.833 ) );
            Assert.That( circle.GetFillColor(), Is.EqualTo( Color.Aqua ) );
            Assert.That( circle.GetOutlineColor(), Is.EqualTo( Color.Brown ) );
        } );
    }

    [Test]
    public void Rectangle_Ctor_NormalValue_CorrectCreate()
    {
        // Arrange 
        Point leftPoint = new Point( 1, 0 );
        Point rightPoint = new Point( 0, 1 );

        // Act 
        Rectangle rectangle = new Rectangle( leftPoint, rightPoint, Color.Aqua, Color.Brown );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( rectangle.GetArea(), Is.EqualTo( 1d ) );
            Assert.That( rectangle.GetPerimeter(), Is.EqualTo( 4d ) );
            Assert.That( rectangle.GetFillColor(), Is.EqualTo( Color.Aqua ) );
            Assert.That( rectangle.GetOutlineColor(), Is.EqualTo( Color.Brown ) );
        } );
    }

    [Test]
    public void Triangle_Ctor_NormalValue_CorrectCreate()
    {
        // Arrange 
        Point firstVertex = new Point( 0, 0 );
        Point secondVertex = new Point( 1, 1 );
        Point thirdVertex = new Point( 2, 0 );

        // Act 
        Triangle rectangle = new Triangle( firstVertex, secondVertex, thirdVertex, Color.Aqua, Color.Brown );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( rectangle.GetArea(), Is.InRange( 1.553, 1.554 ) );
            Assert.That( rectangle.GetPerimeter(), Is.InRange( 4.828, 4.829 ) );
            Assert.That( rectangle.GetFillColor(), Is.EqualTo( Color.Aqua ) );
            Assert.That( rectangle.GetOutlineColor(), Is.EqualTo( Color.Brown ) );
        } );
    }
    
    [Test]
    public void LineSegment_Ctor_NormalValue_CorrectCreate()
    {
        // Arrange 
        Point startPoint = new Point( 0, 0 );
        Point endPoint = new Point( 1, 1 );
        
        // Act 
        LineSegment lineSegment = new LineSegment( startPoint, endPoint, Color.Aqua );

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( lineSegment.GetArea(), Is.EqualTo( 0 ) );
            Assert.That( lineSegment.GetPerimeter(), Is.InRange( 1.414, 1.415 ) );
            Assert.That( lineSegment.GetOutlineColor(), Is.EqualTo( Color.Aqua ) );
        } );
    }
}