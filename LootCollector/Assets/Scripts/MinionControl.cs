using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionControl : MonoBehaviour
{
    //variables to control the commands
    private bool command = false;
    private int maxTime;
    private int commandTimer;

    //varaibles to mark minions that carry loot
    public bool hasLoot;
    public int lootValue;

    private void Awake()
    {
        //set standard values for the variables
        maxTime = 90;
        commandTimer = 0;
        hasLoot = false;
        lootValue = 0;
    }

	
	void Update () {
        
        //give a command to all minions that are not already executing a command, by switchting their commad state to true and resetting the commandTimer value
        if (Input.GetButton("Fire1"))
        {
            if (Command == false)
            {
                Command = true;
                commandTimer = maxTime;
            }   
        }
        
        //if the commandTimer reaches 0, the command ends
        if (commandTimer > 0)
        {
            commandTimer--;
        }
        else
        {
            Command = false;
        }

        //if any minion's command state is true, it stops following the command and will return
        if (Input.GetButton("Fire2"))
        {
            if (Command == true)
            {
                Command = false;
            }
        }
    }

    /// <summary>
    /// save the amount of gold collected from lootbox, mark as loot carrier and end command
    /// this function is called from another script
    /// </summary>
    /// <param name="goldAmount"></param>
    public void Looting (int goldAmount)
    {
        hasLoot = true;
        lootValue += goldAmount;
        Command = false;
    }

    /// <summary>
    /// to acess command even from outside this script
    /// </summary>
    public bool Command
    {
        get { return command; }
        private set
        {
            if (command != value)
            {
                command = value;
            }
        }
    }
}
