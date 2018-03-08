using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour {
    Vector3 forward = Vector3.forward;


    public float headingDirection;
    public int playerGold;

    private void Awake()
    {
        playerGold = 0;
    }

    void Update () {

        //headingDirection wird beim halten der Maustaste aktualisiert und auf die aktuelle Blickrichtung gesetzt
		if (Input.GetButton("Fire1"))
        {
            headingDirection = transform.rotation.eulerAngles.y;
            //Debug.Log(headingDirection);
        }
        //nur zum Test
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log(playerGold);
        }
	}
}
