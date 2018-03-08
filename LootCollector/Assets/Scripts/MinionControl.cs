using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionControl : MonoBehaviour
{
    
    private bool command = false;
    private int maxTime;
    private int commandTimer;

    //fuer das looten
    public bool hasLoot;
    public int lootValue;

    private void Awake()
    {
        maxTime = 90;
        commandTimer = 0;
        hasLoot = false;
        lootValue = 0;
    }

	
	void Update () {
        
        //untaetige Minions erhalten einen Befehl
        if (Input.GetButton("Fire1"))
        {
            if (Command == false)
            {
                Command = true;
                commandTimer = maxTime;
            }   
        }
        
        //Befehl endet nach 'maxTime' Frames
        if (commandTimer > 0)
        {
            commandTimer--;
        }
        else
        {
            Command = false;
        }

        //alle Minions mit Befehl werden zurueck gerufen
        if (Input.GetButton("Fire2"))
        {
            if (Command == true)
            {
                Command = false;
            }
        }
    }

    public void Looting (int goldAmount)
    {
        //Gold speichern und Befehl beenden
        hasLoot = true;
        lootValue += goldAmount;
        Command = false;
    }

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
