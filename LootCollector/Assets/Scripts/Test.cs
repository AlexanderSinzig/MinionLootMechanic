using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    private PlayerValues playerValuesScript;
    private Transform target;


    private void Awake()
    {

        target = GameObject.Find("Player").transform;
        playerValuesScript = target.gameObject.GetComponent<PlayerValues>();


    }


    // Use this for initialization
    void Start () {

}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Fire1"))
        {
            //Ausrichtung des Spielers muss übernommen werden

            //playerValuesScript.headingDirection
            transform.eulerAngles = new Vector3(0, playerValuesScript.headingDirection, 0);




        }
    }

    
}
