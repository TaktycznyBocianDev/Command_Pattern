using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] GameObject mainSquare; //The nice thing is, there could be basically any object with SpriteRenderer.
    [SerializeField] Color defaultColor;    //Could be just assigning in Start method. But as this is just black, I left it.

    //Place where we store color changes in order to undo it.
    //I use Stack as it support the "Last in - first out" mechanic.
    private Stack<ICommand> commands = new Stack<ICommand>();

    //This function check which button was pressed and make new command objects for CommandHandler function.
    public void ListenForCommands(string btnDesignation)
    {
        if (btnDesignation == "Yellow")
        {
            CommandHandler(new YellowFactory(mainSquare));
        }
        if (btnDesignation == "Blue")
        {
            CommandHandler(new BlueFactory(mainSquare));
        }
        if (btnDesignation == "Green")
        {
            CommandHandler(new GreenFactory(mainSquare));
        }
        if (btnDesignation == "Undo")
        {
            //It was nice feeling when I got how to use stack and make this small thing here.
            if(commands.Count != 0)
            {
                commands.Pop().Undo();
            }
        }
        if (btnDesignation == "Reset")
        {
            //Yes, It could (should) be another command subclass. But not everything is a nail when I have a hammer.
            //I choose the quicker way.
            commands.Clear();
            mainSquare.GetComponent<SpriteRenderer>().color = defaultColor; 
        }

    }

    //Place command in stack and execute it.
    public void CommandHandler(ICommand command)
    {
        commands.Push(command);
        command.Execute();
    }



}
