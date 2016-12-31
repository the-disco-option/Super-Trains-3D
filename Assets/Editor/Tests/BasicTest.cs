using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System.Collections.Generic;

public class BasicTest {

    [Test]
    public void EditorTest()
    {
        //Arrange
        var gameObject = new GameObject();

        //Act
        //Try to rename the GameObject
        var newGameObjectName = "My game object";
        gameObject.name = newGameObjectName;

        //Assert
        //The object has a new name
        Assert.AreEqual(newGameObjectName, gameObject.name);
    }
    [Test]
    public void addition()
    {
        float a = 5.5F;
        float b = 4.5F;
        float result = 10;

        Assert.AreEqual(a + b, result);
    }
    [Test]
    public void MakeWithCTest()
    {
        var J1 = Func_Lib.MakeWithC<Junction>();
        Assert.IsNotNull(J1.GetComponent<Junction>());
    }
    
}
[TestFixture]
public class JunctionTests
{
    public GameObject j;

    [SetUp]
    public void Setup()
    {
        j = Func_Lib.MakeJunction();
    }
    [Test]
    public void MakeJunctionTestObj()
    {
        //var j1 = Func_Lib.MakeJunction();
        Assert.NotNull(j.gameObject);
    }

    [Test]
    public void MakeJunctionTestAddNodeObj()
    {
        var j2 = Func_Lib.MakeJunction(new List<GameObject>(new GameObject[] { j }));
        var c = j2.GetComponent<Junction>();
        Debug.Log(c.nodes);
        Assert.Equals(c.nodes[1], j);
    }

    [Test]
    public void FindLineTest()
    {

        var j1 = Func_Lib.MakeJunction();
        var p1 = "";
        var j2 = Func_Lib.MakeNode();
    }
}