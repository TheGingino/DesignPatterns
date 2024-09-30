using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private Dictionary<KeyCode, ICommand> commandMap = new Dictionary<KeyCode, ICommand>();
    private Dictionary<MouseButton, ICommand> mouseCommandMap = new Dictionary<MouseButton, ICommand>();

    public void SetCommand(KeyCode key,ICommand command)
    {
        commandMap[key] = command;
    }

    public void SetMouseCommand(MouseButton mouse, ICommand mouseCommand)
    {
        mouseCommandMap[mouse] = mouseCommand;
    }

    void Update()
    {
        foreach (var entry in commandMap)
        {
            if (Input.GetKeyDown(entry.Key))
            {
                entry.Value.Execute();  // Voer het commando uit als de bijbehorende toets wordt ingedrukt
            }
        }
        foreach (var entry in mouseCommandMap)
        {
            if (Input.GetMouseButtonDown((int)entry.Key))  // MouseButton is casted to int for Input.GetMouseButtonDown
            {
                entry.Value.Execute();
            }
        }
    }
}

public enum MouseButton
{
    LeftClick = 0,
    RightClick = 1,
}
