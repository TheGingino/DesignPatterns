using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefendCommand : ICommand
{
    private Player player;

    public DefendCommand(Player player)
    {
        this.player = player;
    }

    public void Execute()
    {
        player.Defend();  // Player voert de verdediging uit
    }
}
