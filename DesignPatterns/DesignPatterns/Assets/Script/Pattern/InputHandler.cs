using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InputHandler : MonoBehaviour
{
    private Dictionary<KeyCode, ICommand> commandMap = new Dictionary<KeyCode, ICommand>();
    private Dictionary<MouseButton, ICommand> mouseCommandMap = new Dictionary<MouseButton, ICommand>();

    private Player player;  

    public void Initialize(Player player)
    {
        this.player = player;
    }
    
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
            if (Input.GetKey(entry.Key))
            {
                entry.Value.Execute(); 
            }
        }
        foreach (var entry in mouseCommandMap)
        {
            if (Input.GetMouseButtonDown((int)entry.Key))  
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
