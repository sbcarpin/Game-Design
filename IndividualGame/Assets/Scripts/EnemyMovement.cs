using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Resources:
 * Moving an object back and forth on a single axis automatically  - Unity Forum
 * https://forum.unity.com/threads/moving-an-object-back-and-forth-on-a-single-axis-automatically.235033/
 */

public class EnemyMovement : MonoBehaviour
{
    //have set default values
    public float min = 2f;
    public float max = 3f;
    public float speed = 10;
    public float distanceOfTravel = 5;

    /*use this to make enemy randomly follower player
     * from unity tutorial
    private Rigidbody enemyrb;
    private GameObject player; */

    // Use this for initialization
    void Start()
    {
        //these values are based on the Z-axis posotion it starts with (gets them)
        min = transform.position.z;
        max = transform.position.z + distanceOfTravel;

        /* use this to make enemy randomly follower player
        enemyrb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player"); */

    }
    //will travel through the min and max values 
    // Update is called once per frame
    void Update()
    {
        /* use this to make enemy randomly follower player
        enemyrb.AddForce((player.transform.position - transform.position).normalized * speed);
        */
        transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong(Time.time * speed, max - min) + min);

    }
}
