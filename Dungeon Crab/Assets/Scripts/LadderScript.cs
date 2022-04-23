using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderScript : MonoBehaviour
{

    //public Transform charController;
    bool inside = false;
    bool keyDown = false;
    public float speed = 3.3f;
    public playermovement MoveInput;
    // Start is called before the first frame update
    void Start()
    {
        MoveInput = GetComponent<playermovement>();
        inside = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            inside = !inside;
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Ladder")
        {
            inside = !inside;
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.E))
        {
            keyDown = true;
        }
        else {
            keyDown = false;
        }
        if (inside == true && keyDown == true)
        {
            Debug.Log("Test");
            MoveInput.enabled = false;
            this.transform.position += Vector3.up / speed;
        }
        else {
            MoveInput.enabled = true;
        }

        /*if (inside == true && Input.GetKey("d"))
        {
            charController.transform.position += Vector3.down / speed;
        }*/
    }
}
