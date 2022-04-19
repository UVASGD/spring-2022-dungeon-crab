using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public bool isActive; //Boolean that controls whether the button is active
    public int numThingsOnButton = 0; //Number of items on the button
    public bool buttonOpensGrate = true; //Whether the button opens or closes the grate
    public UpDownGrate grate; //Grate controlled by the button

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
        //Break method if the button isn't active for safety
        if (!isActive)
        {
            return;
        }

        //don't trigger if tag is in list, for example, fire in crates don't trigger the button
        if (tagDoesntTriggerButton.Contains(other.gameObject.tag))
        {
            return;
        }

        numThingsOnButton++;
        if (numThingsOnButton > 0){

            if (buttonOpensGrate)
            {
                grate.open();
            }
            else
            {
                grate.close();
            }
        }
        
    }

    private void OnTriggerExit(Collider other) { 

        //Break method if the button isn't active for safety
        if (!isActive)
        {
            return;
        }

        //don't trigger if tag is in list, for example, fire in crates don't trigger the button
        if (tagDoesntTriggerButton.Contains(other.gameObject.tag))
        {
            return;
        }

        numThingsOnButton--;
        if (numThingsOnButton == 0)
        {
            if (buttonOpensGrate)
            {
                grate.close();
            }
            else {
                grate.open();
            }
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
