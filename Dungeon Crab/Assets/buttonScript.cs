using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public bool isActive;
    public int numThingsOnButton = 0;
    public ParentGrate grate;
    //List<GameObject> thingsOnButton;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(numThingsOnButton);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //thingsOnButton.Add(other.gameObject);
        numThingsOnButton++;
        if (numThingsOnButton > 0) {
            grate.open();
        }
        Debug.Log(numThingsOnButton);
    }

    private void OnTriggerExit(Collider other)
    {
        numThingsOnButton--;
        if (numThingsOnButton == 0)
        {
            grate.close();
        }

        Debug.Log(numThingsOnButton);
    }
}
