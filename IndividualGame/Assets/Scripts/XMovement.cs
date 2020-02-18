using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XMovement : MonoBehaviour
{
    public float min = 2f;
    public float max = 3f;
    public float speed = 10;
    public float distanceOfTravel = 13;

    void Start()
    {
        //these values are based on the Z-axis posotion it starts with (gets them)
        min = transform.position.x;
        max = transform.position.x + distanceOfTravel;

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
        transform.position = new Vector3(Mathf.PingPong(Time.time * speed, max - min) + min, transform.position.y, transform.position.z);

    }
}
