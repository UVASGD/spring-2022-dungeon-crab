using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//script to be placed on the parent of a fire object (ie, box) that allows the parent to be burned up and get deleted by the fire object
public class flammableParent : MonoBehaviour
{
    private bool started = false;
    public int loopsUntilCleanup = 200;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (started)
        {
            loopsUntilCleanup--;
        }
        
        if(loopsUntilCleanup < 0)
        {
            Destroy(this.gameObject);
        }
    }

    public void BurnUp()
    {
        if (!started)
        {
            if (this.GetComponent<MeshRenderer>() != null)
                this.GetComponent<MeshRenderer>().enabled = false;
            if (this.GetComponent<Rigidbody>() != null)
                Destroy(this.GetComponent<Rigidbody>());
            if (this.GetComponent<BoxCollider>() != null)
                this.GetComponent<BoxCollider>().enabled = false;
        }
        started = true;
    }
}
