using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionControl : MonoBehaviour
{
    public MinionSpawn minionSpawnScript;
    private bool command = false;
    private int maxTime;
    private int commandTimer;

    private void Awake()
    {
        minionSpawnScript = GetComponent<MinionSpawn>();
    }

    void Start () {
        maxTime = 90;
        commandTimer = 0;
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
