using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attached to the parent of the locked door object. It handles the opening of the door if the player has a key.
public class ParentDoor : MonoBehaviour
{
    // Start is called before the first frame update
    public bool currentlyOpen = false;
    public bool opening = false;
    public int countdown = 110;
    public bool requiresKey = true;
    public GameObject thelock;
    public GameObject ps;
    private GameManager gm;
    private BoxCollider playerDetect;
    void Start()
    {
        gm = GameManager.instance;
        playerDetect = GetComponent<BoxCollider>();
    }

    public void open()
    {
        opening = true;
        playerDetect.enabled = false;
        thelock.SetActive(false);
        ps.SetActive(true);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (opening&&countdown>0)
        {
            transform.Rotate(0,1,0);
            countdown--;
        }else if (opening)
        {
            opening = false;
            currentlyOpen = true;
        }
    }
    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (!requiresKey)
            {
                open();
            }
        }
    }
    */
}
