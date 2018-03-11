using UnityEngine;

public class MinionMovement : MonoBehaviour
{
    
    public float speed = 2.0f;
    //variables to save own rigidbody, other ojects and other scripts
    private Transform target;
    private Rigidbody minionRigidbody;
    private MinionControl minionControlScript;
    private PlayerValues playerValuesScript;


    //find own ridigbody, the player-object and other scripts
    private void Awake()
    {
        minionRigidbody = GetComponent<Rigidbody>();

        minionControlScript = GetComponent<MinionControl>();

        target = GameObject.Find("Player").transform;
        playerValuesScript = target.gameObject.GetComponent<PlayerValues>();


    }

    void Update()
    {
        //minion-behaviour if they aren't following a command
        if (!minionControlScript.Command)
        {
            //x movement, if player is too far away
            if (transform.position.x < target.position.x - 3)
            {
                minionRigidbody.velocity = Vector3.right * speed;
                
            }
            else if (transform.position.x > target.position.x + 3)
            {
                minionRigidbody.velocity = -(Vector3.right) * speed;
            }

            //z movement, if player is too far away
            else if (transform.position.z < target.position.z - 3)
            {
                minionRigidbody.velocity = Vector3.forward * speed;
            }
            else if (transform.position.z > target.position.z + 3)
            {
                minionRigidbody.velocity = -(Vector3.forward) * speed;
            }

            //stop when player is close
            else
            {
                minionRigidbody.velocity = Vector3.zero;

                //deliver loot and reset status by calling the function in the control script
                if (minionControlScript.hasLoot)
                {
                    playerValuesScript.playerNewGold += minionControlScript.lootValue;
                    minionControlScript.lootValue = 0;
                    minionControlScript.hasLoot = false;
                }
            }
        }

        //move in the directtion the player is facing
        if (minionControlScript.Command)
        {
            //align to the players view (from playeraluesScript)
            transform.eulerAngles = new Vector3(0, playerValuesScript.headingDirection, 0);   

            //move forward
            minionRigidbody.velocity = transform.forward * speed;


        }

    }
}
