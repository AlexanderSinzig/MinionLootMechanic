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
        maxTime = 60;
        commandTimer = 0;
	}
	
	void Update () {
        
        //untaetige Minions erhalten einen Befehl
        if (Input.GetButtonDown("Fire1"))
        {
            if (Command == false)
            {
                Command = true;
                commandTimer = maxTime;
            }   
        }
        
        //Befehl endet nach 60 Frames
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
