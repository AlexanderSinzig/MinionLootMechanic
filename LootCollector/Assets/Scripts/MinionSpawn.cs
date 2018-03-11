using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionSpawn : MonoBehaviour
{
    public GameObject minionPrefab;
    private int[] minionIndex;

    private void Awake()
    {
        minionIndex = new int[5];
    }

    void Start () {
        //create several minions as instances of the same prefab
		for (int i = 0; i < minionIndex.Length; i++)
        {
            Instantiate
            (
                minionPrefab, 
                new Vector3(transform.position.x + i, transform.position.y - 0.5f, transform.position.z + 5 - i), 
                transform.rotation
            );
            //give each minion its own index
            //this would have been necessary if the minions would be controlled separately
            //minionIndex[i] = i;
        }
	}

    /*
    //this part is also not needed if all minions are controlled at once
    public int[] MinionIndex
    {
        get { return minionIndex; }
    }
    */
}
