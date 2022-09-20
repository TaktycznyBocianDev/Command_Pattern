using System;
using UnityEngine;

public class BlueFactory : ICommand
{

    GameObject square; //This is our "player"
    Color previousColor; //Color that square have before we change it; current one;

    public BlueFactory(GameObject square)
    {
        this.square = square;
        this.previousColor = square.GetComponent<SpriteRenderer>().color;
    }

    public void Execute()
    {
        square.GetComponent<SpriteRenderer>().color = Color.blue;
    }

    public void Undo()
    {
        square.GetComponent<SpriteRenderer>().color = previousColor;
    }
}
