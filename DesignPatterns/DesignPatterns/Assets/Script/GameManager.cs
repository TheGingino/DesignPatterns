
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private InputHandler inputHandler;
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();  // Zoek de Player in de scene
        inputHandler = gameObject.AddComponent<InputHandler>();  // Voeg InputHandler toe aan de GameObject

        // Koppel toetsen aan commando's
        inputHandler.SetCommand(KeyCode.Space, new JumpCommand(player));
        
        // Walking commands (WASD or Arrow keys)
        inputHandler.SetCommand(KeyCode.W, new WalkCommand(player, Vector3.forward));  // Naar voren lopen
        inputHandler.SetCommand(KeyCode.S, new WalkCommand(player, Vector3.back));     // Naar achteren lopen
        inputHandler.SetCommand(KeyCode.A, new WalkCommand(player, Vector3.left));     // Naar links lopen
        inputHandler.SetCommand(KeyCode.D, new WalkCommand(player, Vector3.right));    // Naar rechts lopen
        
        
        inputHandler.SetMouseCommand(MouseButton.LeftClick, new AttackCommand(player));
        inputHandler.SetMouseCommand(MouseButton.RightClick, new DefendCommand(player));
        
    }
}
