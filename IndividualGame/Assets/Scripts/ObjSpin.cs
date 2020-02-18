using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *Resources:[Unity 4] Making an object spin (JavaScript)
 * https://www.youtube.com/watch?time_continue=149&v=_puSQ-aEmYw&feature=emb_logo
 */

public class ObjSpin : MonoBehaviour
{
    public int spiny = 5; 

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, spiny, 0);
    }
}
