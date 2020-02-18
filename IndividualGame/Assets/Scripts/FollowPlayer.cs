using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 8.5f, -4);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset;
    }




    /*
     * //https://stackoverflow.com/questions/53897646/camera-rotate-with-player-unity-3d
     * [SerializeField]
     private Transform target;

     [SerializeField]
     private Vector3 offsetPosition = new Vector3(0, 3, -3);

     [SerializeField]
     private Space offsetPositionSpace = Space.Self;

     [SerializeField]
     private bool lookAt = true;

     private void Update()
     {
         Refresh();
     }

     public void Refresh()
     {
         if (target == null)
         {
             Debug.LogWarning("Missing target ref !", this);

             return;
         }

         // compute position
         if (offsetPositionSpace == Space.Self)
         {
             transform.position = target.TransformPoint(offsetPosition);
         }
         else
         {
             transform.position = target.position + offsetPosition;
         }

         // compute rotation
         if (lookAt)
         {
             transform.LookAt(target);
         }
         else
         {
             transform.rotation = target.rotation;
         }
     }*/


}