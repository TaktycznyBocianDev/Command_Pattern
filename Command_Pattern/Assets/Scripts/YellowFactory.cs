using UnityEngine;
public class YellowFactory : ICommand
{

    GameObject square; //This is our "player". It means this black square in the center of the screen.
    Color previousColor; //Color that square has before we change it.Command object should remember it for undo action.

    public YellowFactory(GameObject square)
	{
        this.square = square;
        this.previousColor = square.GetComponent<SpriteRenderer>().color;
    }

    public void Execute()
    {
        square.GetComponent<SpriteRenderer>().color = Color.yellow; //Set right color
    }

    public void Undo()
    {
        square.GetComponent<SpriteRenderer>().color = previousColor; //Set color as the one that square has before we change it
    }
}
