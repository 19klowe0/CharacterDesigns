 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    //offset for camera 
    public float offset;
    

    private Transform playerTransform;
    public Transform butterflyTransform;
    public SpriteSwitch i;

    //boundaries for the camera 
    public float leftlimit;
    public float rightlimit;
    public float bottomlimit;
    public float toplimit;
    void Start()
    {
        //playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //butterflyTransform = GameObject.FindGameObjectWithTag("ButterFly").transform;
    }

    // Update is called once per frame
    private void Update()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        //butterflyTransform = GameObject.FindGameObjectWithTag("ButterFly").transform;
    }

    void LateUpdate()
    {
        Vector3 temp;
        if (i.whichIsOn == 1)
        {
            //we stroew currents camera's position in variable temp
            temp = transform.position;

            //set camera's position x to the player's position x
            temp.x = playerTransform.position.x;
            temp.y = playerTransform.position.y;

            //only offsetting Y position
            temp.y += offset;


            //we set back the camera's temp position to the camera's current position
            transform.position = temp;
        }
        else if (i.whichIsOn == 2)
        {
            //we stroew currents camera's position in variable temp
            temp = transform.position;

            //set camera's position x to the player's position x
            temp.x = butterflyTransform.position.x;
            temp.y = butterflyTransform.position.y;

            //only offsetting Y position
            temp.y += offset;

            //we set back the camera's temp position to the camera's current position
            transform.position = temp;
        }


        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftlimit, rightlimit),
            Mathf.Clamp(transform.position.y, bottomlimit, toplimit),
            transform.position.z
            );

    }

    void OnDrawGizmos()
    {
        //draw a box around our camera boundary
        Gizmos.color = Color.red;
        //left top to right top
        Gizmos.DrawLine(new Vector2(leftlimit, toplimit), new Vector2(rightlimit, toplimit));
        //right line
        Gizmos.DrawLine(new Vector2(rightlimit, toplimit), new Vector2(rightlimit, bottomlimit));
        //bottom line
        Gizmos.DrawLine(new Vector2(leftlimit, bottomlimit), new Vector2(rightlimit, bottomlimit));
        //left line
        Gizmos.DrawLine(new Vector2(leftlimit, toplimit), new Vector2(leftlimit, bottomlimit));

    }
}
