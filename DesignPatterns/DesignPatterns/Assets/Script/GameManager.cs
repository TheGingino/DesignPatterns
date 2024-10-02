
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputHandler inputHandler;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
        inputHandler = gameObject.AddComponent<InputHandler>();  
        inputHandler.Initialize(player);
        
        inputHandler.SetCommand(KeyCode.Space, new JumpCommand(player));
        
        inputHandler.SetCommand(KeyCode.W, new WalkCommand(player, Vector3.forward));  
        inputHandler.SetCommand(KeyCode.S, new WalkCommand(player, Vector3.back));     
        inputHandler.SetCommand(KeyCode.A, new WalkCommand(player, Vector3.left));     
        inputHandler.SetCommand(KeyCode.D, new WalkCommand(player, Vector3.right));    

        inputHandler.SetMouseCommand(MouseButton.LeftClick, new AttackCommand(player));
        inputHandler.SetMouseCommand(MouseButton.RightClick, new DefendCommand(player));
    }
}
