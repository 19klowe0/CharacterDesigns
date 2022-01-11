using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blinking : MonoBehaviour

{
    private float itsTimeToBlink;
    private IEnumerator doBlinkCoroutine;
    void Start()
    {
        this.gameObject.GetComponent<Renderer>().enabled = false;
        itsTimeToBlink = 0f;

    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(waiter());
        if (Time.time > itsTimeToBlink)
        {
            doBlinkCoroutine = DoBlink();
            StartCoroutine(doBlinkCoroutine);
        }

    }
    IEnumerator DoBlink()
    {
        this.gameObject.GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(0.25f);
        this.gameObject.GetComponent<Renderer>().enabled = false;
        // Debug.Log("Started Coroutine at timestamp : " + Time.time);
        itsTimeToBlink = Time.time + Random.Range(2f, 5f);

    }


}
