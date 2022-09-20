using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    [SerializeField] GameObject mainSquare;
    [SerializeField] Color defaultColor;


    private Stack<ICommand> commands = new Stack<ICommand>(); //Place where we store color changes in order to undo it.



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
            if(commands.Count != 0)
            {
                commands.Pop().Undo();
            }
        }
        if (btnDesignation == "Reset")
        {
            commands.Clear();
            mainSquare.GetComponent<SpriteRenderer>().color = defaultColor;
        }

    }

    public void CommandHandler(ICommand command)
    {
        commands.Push(command);
        command.Execute();
    }



}
