using NUnit.Framework;
using Task2._3_MyList.Models;

namespace Task2._3_MyList.Tests;

public class MyListTests
{
    [Test]
    public void MyList_Insert_NormalInput_CorrectCount()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();

        // Act
        myList.InsertAtTheStart( "some string 1" );
        myList.InsertAtTheEnd( "some string 2" );
        myList.InsertAtTheEnd( "some string 3" );

        // Assert
        Assert.That( myList, Has.Count.EqualTo( 3 ) );
    }
    
    [Test]
    public void MyList_Insert_InvalidPosition_ReceiveException()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.Add( "some string 0" );

        // Act && Assert
        Assert.Throws<ArgumentOutOfRangeException>(() => myList.Insert( -1, "some string 1" ) );
        Assert.Throws<ArgumentOutOfRangeException>(() => myList.Insert( 2, "some string 1" ) );
        Assert.Throws<ArgumentOutOfRangeException>(() => myList[1] = "" );
    }
    
    [Test]
    public void MyList_Clear_NormalInput_EmptyList()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.Add( "some string 1" );
        myList.Add( "some string 2" );
        myList.Add( "some string 3" );

        // Act
        myList.Clear();

        // Assert
        Assert.That( myList, Has.Count.EqualTo( 0 ) );
    }

    [Test]
    public void MyList_Copy_NormalInput_EmptyList()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.Add( "some string 1" );
        myList.Add( "some string 2" );
        myList.Add( "some string 3" );
        
        // Act
        MyList<string> copy = myList.Copy();
        
        // Assert
        Assert.That( copy, Is.EqualTo( myList ) );
    }

    [Test]
    public void MyList_InsertWithOverwrite_NormalInput_CorrectCount()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.InsertAtTheStart( "some string 1" );
        myList.InsertAtTheEnd( "some string 2" );
        myList.InsertAtTheEnd( "some string 3" );

        // Act
        myList[0] = "some string 4";
        myList[2] = "some string 5";
        myList.InsertAtTheEnd( "some string 6" );

        // Assert
        Assert.That( myList, Has.Count.EqualTo( 4 ) );
        Assert.Multiple( () =>
        {
            Assert.That( myList.ElementAt( 0 ), Is.EqualTo( "some string 4" ) );
            Assert.That( myList.ElementAt( 2 ), Is.EqualTo( "some string 5" ) );
            Assert.That( myList.ElementAt( 3 ), Is.EqualTo( "some string 6" ) );
        } );
    }

    [Test]
    public void MyList_InsertNew_NormalInput_CorrectCount()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.Add( "some string 1" );
        myList.Add( "some string 2" );
        myList.Add( "some string 3" );

        // Act
        myList.Insert( 0, "some string 0" );
        myList.Insert( 1, "some string 0.5" );
        myList.Insert( 5, "some string 4" );

        // Assert
        Assert.That( myList, Has.Count.EqualTo( 6 ) );
        Assert.Multiple( () =>
        {
            Assert.That( myList.ElementAt( 0 ), Is.EqualTo( "some string 0" ) );
            Assert.That( myList.ElementAt( 1 ), Is.EqualTo( "some string 0.5" ) );
            Assert.That( myList.ElementAt( 2 ), Is.EqualTo( "some string 1" ) );
            Assert.That( myList.ElementAt( 3 ), Is.EqualTo( "some string 2" ) );
            Assert.That( myList.ElementAt( 4 ), Is.EqualTo( "some string 3" ) );
            Assert.That( myList.ElementAt( 5 ), Is.EqualTo( "some string 4" ) );
        } );
    }

    [Test]
    public void MyList_RemoveAt_NormalInput_CorrectCount()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.InsertAtTheStart( "some string 1" );
        myList.InsertAtTheEnd( "some string 2" );
        myList.InsertAtTheEnd( "some string 3" );

        // Act
        myList.RemoveAt( 2 );

        // Assert
        Assert.That( myList, Has.Count.EqualTo( 2 ) );
        Assert.Multiple( () =>
        {
            Assert.That( myList.ElementAt( 0 ), Is.EqualTo( "some string 1" ) );
            Assert.That( myList[ 1 ], Is.EqualTo( "some string 2" ) );
        } );
    }

    [Test]
    public void MyList_GetForwardEnumerator_NormalInput_CorrectEnumerate()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.InsertAtTheEnd( "some string 1" );
        myList.InsertAtTheStart( "some string 2" );
        myList.InsertAtTheEnd( "some string 3" );

        List<string> result = new List<string>();

        // Act
        IEnumerator<string> enumerator = myList.GetForwardEnumerator();
        while ( enumerator.MoveNext() )
        {
            result.Add( enumerator.Current );
        }

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( myList, Has.Count.EqualTo( 3 ) );
            Assert.That( result, Is.EqualTo( new List<string>
            {
                "some string 2",
                "some string 1",
                "some string 3"
            } ) );
        } );
    }

    [Test]
    public void MyList_GetBackwardEnumerator_NormalInput_CorrectEnumerate()
    {
        // Arrange
        MyList<string> myList = new MyList<string>();
        myList.InsertAtTheEnd( "some string 1" );
        myList.InsertAtTheStart( "some string 2" );
        myList.InsertAtTheEnd( "some string 3" );

        List<string> result = new List<string>();

        // Act
        IEnumerator<string> enumerator = myList.GetBackwardEnumerator();
        while ( enumerator.MoveNext() )
        {
            result.Add( enumerator.Current );
        }

        // Assert
        Assert.Multiple( () =>
        {
            Assert.That( myList, Has.Count.EqualTo( 3 ) );
            Assert.That( result, Is.EqualTo( new List<string>
            {
                "some string 3",
                "some string 1",
                "some string 2"
            } ) );
        } );
    }
}