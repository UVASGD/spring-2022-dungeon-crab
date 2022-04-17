using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the parent of the locked door object. It handles the opening of the door if the player has a key.
public class ParentGrate : MonoBehaviour
{
    // Start is called before the first frame update
    public bool currentlyOpen = false;
    public bool opening = false;
    public bool closing = false;
    public int countdown = 10;

    void Start()
    {
    }

    public void close()
    {
        opening = false;
        if (countdown != 10) {
            closing = true;
        }
    }

    public void open()
    {
        opening = true;
        closing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (opening&&countdown>0)
        {
            transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
            countdown--;
        }else if (opening)
        {
            opening = false;
            currentlyOpen = true;
        }

        if (closing && countdown < 10)
        {
            transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
            countdown++;
        }
        else if (closing)
        {
            closing = false;
            currentlyOpen = false;
        }
    }
}
