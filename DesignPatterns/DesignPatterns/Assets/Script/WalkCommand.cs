using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkCommand : ICommand
{
    private Player player;
    private Vector3 direction;  // De richting waarin de speler moet lopen

    public WalkCommand(Player player, Vector3 direction)
    {
        this.player = player;
        this.direction = direction;
    }

    public void Execute()
    {
        player.Walk(direction);  // Speler beweegt in de gegeven richting
    }
}
