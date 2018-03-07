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
		for (int i = 0; i < minionIndex.Length; i++)
        {
            Instantiate
            (
                minionPrefab, 
                new Vector3(transform.position.x + i, transform.position.y - 0.5f, transform.position.z + 5 - i), 
                transform.rotation
            );
            //indizierung der Minions
            minionIndex[i] = i;
        }
	}

	void Update () {
		
	}

    public int[] MinionIndex
    {
        get { return minionIndex; }
    }
}
