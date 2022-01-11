using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveWorm : MonoBehaviour
{
    //code is to move inbetween an array of points while whiching the animations. 
    //completely ignore the character
    //movingin a inch motion

    private Animator anim;

    //information needed to move between points and have a wait time at those points 
    public float speed;
    public Transform[] patrolPoints;
    public float waitTime;
    int currentPointIndex;
    public float pauseTime;//for moving worm correctly 

    //only want to call corountine once 
    bool once = false;

    private float time = 0.0f;
    public float interpolationPeriod;

    

    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetBool("idle", true);
        anim.SetBool("walking", false);
     
    }

    // Update is called once per frame
    void Update()
    {   
        time += Time.deltaTime;

        if (time < interpolationPeriod && transform.position != patrolPoints[currentPointIndex].position)
        {
            anim.speed = 1;
            transform.position = Vector2.MoveTowards(transform.position, patrolPoints[currentPointIndex].position, speed * Time.deltaTime);
            anim.SetBool("walking", true);
            anim.SetBool("idle", false);

        }
        else
        {
            time = 0.0f;
            anim.speed = 0;
            //have reached patrol point 
            //anim direction switches back and forth with every patrol poitn reached 
            if (once == false)
            {
                once = true;
                StartCoroutine(Wait());
                //anim.SetBool("walking", false);
                //anim.SetBool("idle", true);
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
        Debug.LogError(time);
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        if (currentPointIndex + 1 < patrolPoints.Length)
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
