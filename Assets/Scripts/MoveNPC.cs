using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNPC : MonoBehaviour
{
    //code is to move inbetween an array of points while whiching the animations. 
    //completely ignore the character 
    
    private Animator anim;

    //information needed to move between points and have a wait time at those points 
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;

    //only want to call corountine once 
    bool once;
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("walking", false);
        anim.SetBool("wakeup", false);
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x != patrolPoints[currentPointIndex].position.x)
        {
            //move only the x transform
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(patrolPoints[currentPointIndex].position.x, transform.position.y), speed*Time.deltaTime);
            anim.SetBool("walking", true);
            anim.SetBool("idle", false);

        }
        else
        {
            //have reached patrol point 
            //anim direction switches back and forth with every patrol point reached 
            if (once == false)
            {
                once = true;
                
                anim.SetBool("walking", false);
                anim.SetBool("idle", true);
                StartCoroutine(Wait());
                if (transform.eulerAngles.Equals(new Vector3(0, 180, 0)))
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 180, 0);
                }
                
            }
           
        }
    }

    IEnumerator Wait()
    {
        
        yield return new WaitForSeconds(waitTime);
        if(currentPointIndex+1 < patrolPoints.Length)
        {
            currentPointIndex++;
        }
        else
        {
            currentPointIndex = 0;
        }

        once = false;
    }
}
