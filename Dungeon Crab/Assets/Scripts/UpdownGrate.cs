using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attatched to the grate that opens up and down.
public class UpDownGrate : MonoBehaviour
{
    
    public bool currentlyOpen = false;
    public bool opening = false;
    public bool closing = false;

    public int fullyOpenedDoorNum = 0;
    public int fullyClosedDoorNum = 10;

    public int countdown = 10;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void close()
    {
        //Starts the closing process
        opening = false;
        closing = true;
    }

    public void open()
    {
        opening = true;
        closing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //General Opening Process
        if (opening && countdown > fullyOpenedDoorNum) //Opens door if open is called when partially closed
        {
            transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
            countdown--;
        }
        else if (opening) //Finished Opening
        {
            opening = false;
            currentlyOpen = true;
        }

        //General Closing Process
        if (closing && countdown < fullyClosedDoorNum) //Closes door if close is called when partially open
        {
            transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
            countdown++;
        }
        else if (closing) //Finished Closing
        {
            closing = false;
            currentlyOpen = false;
        }

        //General Intertia - Grate Closes in Absense of triggers
        if (!opening && !closing && !currentlyOpen && countdown < fullyClosedDoorNum) {
            transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
            countdown++;
        }
        else if (!opening && !closing && !currentlyOpen) //Finished Closing
        {
            currentlyOpen = false;
        }

    }
}
