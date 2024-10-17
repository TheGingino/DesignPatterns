using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCommand : ICommand
{
    private Player player;

    public AttackCommand(Player player)
    {
        this.player = player;
    }
    
    

    public void Execute()
    {
        player.Attack(); 
    }
}
