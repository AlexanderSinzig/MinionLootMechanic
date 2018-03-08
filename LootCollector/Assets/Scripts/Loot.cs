using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loot : MonoBehaviour {

    private int amount;
    private GameObject collidingMinion;
    private MinionControl minionControlScript;

    // Use this for initialization
    void Awake () {
        amount = Random.Range(1, 30);
	}
	

    private void OnTriggerEnter(Collider other)
    {
        //das control script des kollidierenden Minions ansprechen
        collidingMinion = other.gameObject;
        minionControlScript = collidingMinion.GetComponent<MinionControl>();
        minionControlScript.Looting(amount);
        Destroy(gameObject);
    }
}
