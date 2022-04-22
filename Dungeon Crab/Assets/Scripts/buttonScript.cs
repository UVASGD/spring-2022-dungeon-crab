using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public bool isActive; //Boolean that controls whether the button is active
    public int numThingsOnButton = 0; //Number of items on the button
    public bool buttonOpensGrate = true; //Whether the button opens or closes the grate

    public List<Grate> grateList = new List<Grate>(); //List of Grates controlled by the button

    //List of Tags that cannot trigger the button
    //TODO: Should this instead be a list of items that do trigger the button?
    public List<string> tagDoesntTriggerButton = new List<string>();

    // Start is called before the first frame update
    void Start()
    {
        tagDoesntTriggerButton.Add("Fire");
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Should the isActive turn the trigger off entirely?
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isTriggerActive(other))
        {
            return;
        }

        numThingsOnButton++;
        if (numThingsOnButton > 0){

            if (buttonOpensGrate)
            {
                openAllGrates();
            }
            else
            {
                closeAllGrates();
            }
        }
        
    }

    private void OnTriggerExit(Collider other) { 

        //Break method if the button isn't active for safety
        if (!isTriggerActive(other))
        {
            return;
        }

        numThingsOnButton--;
        if (numThingsOnButton == 0)
        {
            if (buttonOpensGrate)
            {
                closeAllGrates();
            }
            else {
                openAllGrates();
            }
        }

    }

    private bool isTriggerActive(Collider other) {
        //Break method if the button isn't active for safety
        //don't trigger if tag is in list, for example, fire in crates don't trigger the button
        if (isActive && !tagDoesntTriggerButton.Contains(other.gameObject.tag))
        {
            return true;
        }

        return false;
    }

    private void openAllGrates() {
        foreach (Grate g in grateList) {
            g.open();
        }
    }

    private void closeAllGrates()
    {
        foreach (Grate g in grateList)
        {
            g.close();
        }
    }

    /*
    IEnumerator Reset()
    {
        //Code to prevent trigger from calling multiple times on objects
        //https://answers.unity.com/questions/738991/ontriggerenter-being-called-multiple-times-in-succ.html 
        yield return new WaitForEndOfFrame();
        isColliding = false;

        //Doesn't seem to work if one object has two colliding features. 
    }*/
}
