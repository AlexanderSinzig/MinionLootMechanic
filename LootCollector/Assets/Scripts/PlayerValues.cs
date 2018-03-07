using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerValues : MonoBehaviour {
    // Get a copy of your forward vector
    Vector3 forward = Vector3.forward;


    public float headingAngleX;
    public float headingAngleZ;

    // Use this for initialization
    void Awake () {
        // Zero out the y component of your forward vector to only get the direction in the X,Z plane
        forward.x = 0;
        forward.z = 0;
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("Fire1"))
        {
            headingAngleX = Quaternion.LookRotation(forward).eulerAngles.x;
            //headingAngleZ = Quaternion.LookRotation(forward).eulerAngles.z;
        }
	}
}
