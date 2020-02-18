using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Resource:  [Tutorial] - Moving a Cube with Arrow Keys (Unity)
 * https://www.youtube.com/watch?time_continue=96&v=WxCsnNiJnhA&feature=emb_title
*/

public class PlayerControl : MonoBehaviour
{
    //private Rigidbody rb;
    public int cameraSpeed = 30;

    //public ParticleSystem explosion;

    public static float movementSpeed = 9.5f;
    public float clockwise = 100.0f;
    public float counterClockwise = -100.0f;

    // Use this for initialization
    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal") * cameraSpeed;
        //float v = Input.GetAxis("Vertical") * speed;
        /*Vector3 vel = rb.velocity;
        vel.x = h;
        vel.z = v;
        rb.velocity = vel;*/

        
        //https://answers.unity.com/questions/616195/how-to-make-an-object-go-the-direction-it-is-facin.html


         if (Input.GetKey(KeyCode.UpArrow))
         {
             transform.position += transform.forward * Time.deltaTime * movementSpeed;
         }
         else if (Input.GetKey(KeyCode.DownArrow))
         {
             transform.position += -transform.forward * Time.deltaTime * movementSpeed;
           
         }
         else if (Input.GetKey(KeyCode.LeftArrow))
         {
            transform.position += -transform.right * Time.deltaTime * movementSpeed;
            //rb.position += Vector3.left * Time.deltaTime * movementSpeed;
            //transform.Rotate(0, Time.deltaTime * counterClockwise, 0);
        }
         else if (Input.GetKey(KeyCode.RightArrow))
         {
            transform.position += transform.right * Time.deltaTime * movementSpeed;
            //rb.position += Vector3.right * Time.deltaTime * movementSpeed;
            //transform.Rotate(0, Time.deltaTime * clockwise, 0);
        }
         else if (Input.GetKey(KeyCode.A))
         {
            transform.Rotate(Vector3.up * h * cameraSpeed * Time.deltaTime);
         }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up * h * cameraSpeed * Time.deltaTime);
        }
    }
}

