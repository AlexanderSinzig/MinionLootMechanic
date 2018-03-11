using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    //variables for the amount saved in the box and to save the other scripts
    private int amount;
    private GameObject collidingMinion;
    private MinionControl minionControlScript;

    //create a random amount of gold
    void Awake () {
        amount = Random.Range(1, 30);
	}
	
    /// <summary>
    /// minions can collect the loot from the box, save the value and remove the box
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter(Collider other)
    {
        //call the control script of the colliding minion
        collidingMinion = other.gameObject;
        minionControlScript = collidingMinion.GetComponent<MinionControl>();
        //transfer gold
        minionControlScript.Looting(amount);
        //destroy the box afterwards, so it can't be collected again
        Destroy(gameObject);
    }
}
