using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attatched to the grate that opens up and down.
public class UpDownGrate : Grate
{
    
    public bool currentlyOpen = false;
    public bool opening = false;
    public bool closing = false;

    public int endPositionNum = 10;
    public int startPositionNum = 0;

    public int count = 0;

    // Start is called before the first frame update
    void Start()
    {
    }

    public override void close()
    {
        //Starts the closing process
        opening = false;
        closing = true;
    }

    public override void open()
    {
        opening = true;
        closing = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //General Opening Process
        if (opening && count < endPositionNum) //Opens door if open is called when partially closed
        {
            transform.position += new Vector3(0, 10f * Time.deltaTime, 0);
            count++;
        }
        else if (opening) //Finished Opening
        {
            opening = false;
            currentlyOpen = true;
        }

        //General Closing Process
        if (closing && count > startPositionNum) //Closes door if close is called when partially open
        {
            transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
            count--;
        }
        else if (closing) //Finished Closing
        {
            closing = false;
            currentlyOpen = false;
        }

        //General Intertia - Grate Closes in Absense of triggers
        if (!opening && !closing && !currentlyOpen && count > startPositionNum) {
            transform.position += new Vector3(0, -10f * Time.deltaTime, 0);
            count--;
        }
        else if (!opening && !closing && !currentlyOpen) //Finished Closing
        {
            currentlyOpen = false;
        }

    }
}
