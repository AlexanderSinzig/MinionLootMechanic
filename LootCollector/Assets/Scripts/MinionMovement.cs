using UnityEngine;

public class MinionMovement : MonoBehaviour
{

    public float speed = 2.0f;
    private Transform target;
    private Rigidbody minionRigidbody;
    private MinionControl minionControlScript;
    private PlayerValues playerValuesScript;


    private void Awake()
    {

        minionRigidbody = GetComponent<Rigidbody>();

        minionControlScript = GetComponent<MinionControl>();

        target = GameObject.Find("Player").transform;
        playerValuesScript = target.gameObject.GetComponent<PlayerValues>();


    }

    void Start()
    {
       
    }

    void Update()
    {
        if (!minionControlScript.Command)
        {
            //x Bewegung
            if (transform.position.x < target.position.x - 3)
            {
                minionRigidbody.velocity = Vector3.right * speed;
                
            }
            else if (transform.position.x > target.position.x + 3)
            {
                minionRigidbody.velocity = -(Vector3.right) * speed;
            }
            //z Bewegung
            else if (transform.position.z < target.position.z - 3)
            {
                minionRigidbody.velocity = Vector3.forward * speed;
            }
            else if (transform.position.z > target.position.z + 3)
            {
                minionRigidbody.velocity = -(Vector3.forward) * speed;
            }
            else
            {
                minionRigidbody.velocity = Vector3.zero;

                //Loot abgeben
                if (minionControlScript.hasLoot)
                {
                    playerValuesScript.playerGold += minionControlScript.lootValue;
                    minionControlScript.lootValue = 0;
                    minionControlScript.hasLoot = false;
                }
            }
        }

        //Laufbefehl in Blickrichtung
        if (minionControlScript.Command)
        {
            //Ausrichtung des Spielers muss übernommen werden
            transform.eulerAngles = new Vector3(0, playerValuesScript.headingDirection, 0);   
            minionRigidbody.velocity = transform.forward * speed;


        }

    }
}
