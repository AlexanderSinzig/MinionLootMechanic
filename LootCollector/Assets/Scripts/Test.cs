using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// this script exists just to showcase the player direction on a cube
/// it's purpose was to test if the alignment to the player direction worked
/// it could be deleted it could be deleted, but I didn't, because it also shows my approach to find the source of the move-direction problem
/// </summary>
public class Test : MonoBehaviour {

    private PlayerValues playerValuesScript;
    private Transform target;


    private void Awake()
    {
        //get the playervlauesScript on the player object
        target = GameObject.Find("Player").transform;
        playerValuesScript = target.gameObject.GetComponent<PlayerValues>();
    }

	
	void Update () {
        //align when button is hold
        if (Input.GetButton("Fire1"))
        {
            transform.eulerAngles = new Vector3(0, playerValuesScript.headingDirection, 0);
        }
    }

    
}
