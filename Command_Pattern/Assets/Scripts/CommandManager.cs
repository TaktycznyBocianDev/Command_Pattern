using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommandManager : MonoBehaviour
{
    private Queue<ICommand> commands; //Place where we store color changes in order to undo it.
}
