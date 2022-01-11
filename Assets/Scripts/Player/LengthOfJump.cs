using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LengthOfJump : MonoBehaviour
{
    public GameObject jumpLengthStart;
    public Vector3 jumpLengthEnd;
    // Start is called before the first frame update
    void OnDrawGizmos()
    {
        //draw a box around our camera boundary
        Gizmos.color = Color.red;
        //left top to right top
        Gizmos.DrawLine(new Vector2(jumpLengthStart.transform.position.x, jumpLengthStart.transform.position.y), jumpLengthEnd);
        
        

    }
}
