using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCommand : ICommand
{
    private Player player;  // Receiver

    public JumpCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Jump();  // Player voert de sprong uit
    }
}
