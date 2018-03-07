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

        playerValuesScript = GetComponent<PlayerValues>();
    }

    void Start()
    {
        target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

        }

        if (!minionControlScript.Command)
        {
            //x movement
            if (transform.position.x < target.position.x - 3)
            {
                minionRigidbody.velocity = Vector3.right * speed;
                
            }
            else if (transform.position.x > target.position.x + 3)
            {
                minionRigidbody.velocity = -(Vector3.right) * speed;
            }
            //z movement
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
            }
        }

        //Laufbefehl in Blickrichtung
        if (minionControlScript.Command)
        {
            minionRigidbody.velocity = Vector3.forward *playerValuesScript.headingAngleX;
            minionRigidbody.velocity = Vector3.right * playerValuesScript.headingAngleZ;


        }

    }
}
