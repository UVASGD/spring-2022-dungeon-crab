using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    public bool isActive; //Boolean that controls whether the button is active
    public int numThingsOnButton = 0; //Number of items on the button
    public bool buttonOpensGrate = true; //Whether the button opens or closes the grate
    public ParentGrate grate; //Grate controlled by the button

    //List of Tags that cannot trigger the button
    //TODO: Should this instead be a list of items that do trigger the button?
    public List<string> tagDoesntTriggerButton = new List<string>();

    bool isColliding;

    // Start is called before the first frame update
    void Start()
    {
        tagDoesntTriggerButton.Add("Fire");
        Debug.Log(numThingsOnButton);
    }

    // Update is called once per frame
    void Update()
    {
        //TODO: Should the isActive turn the trigger off entirely?
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("enter:" + other.gameObject.name);
        Debug.Log("enter: 1");

        //Break method if the button isn't active for safety
        if (!isActive)
        {
            return;
        }

        Debug.Log("enter: 2");

        //don't trigger if tag is in list, for example, fire in crates don't trigger the button
        if (tagDoesntTriggerButton.Contains(other.gameObject.tag))
        {
            return;
        }

        Debug.Log("enter: 3");

        numThingsOnButton++;
        if (numThingsOnButton > 0){

            Debug.Log("enter: 4");
            if (buttonOpensGrate)
            {
                grate.open();
            }
            else
            {
                grate.close();
            }
        }

        Debug.Log(numThingsOnButton);
        
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log(other.gameObject.name);

        Debug.Log("exit: 1");

        //Break method if the button isn't active for safety
        if (!isActive)
        {
            return;
        }

        Debug.Log("exit: 2");
        //don't trigger if tag is in list, for example, fire in crates don't trigger the button
        if (tagDoesntTriggerButton.Contains(other.gameObject.tag))
        {
            return;
        }

        Debug.Log("exit: 3");
        numThingsOnButton--;
        if (numThingsOnButton == 0)
        {
            Debug.Log("exit: 4");
            if (buttonOpensGrate)
            {
                grate.close();
            }
            else {
                grate.open();
            }
        }

        Debug.Log(numThingsOnButton);

    }

    IEnumerator Reset()
    {
        //Code to prevent trigger from calling multiple times on objects
        //https://answers.unity.com/questions/738991/ontriggerenter-being-called-multiple-times-in-succ.html 
        yield return new WaitForEndOfFrame();
        isColliding = false;

        //Doesn't seem to work if one object has two colliding features. 
    }
}
