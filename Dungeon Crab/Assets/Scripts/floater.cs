using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is for objects that float in water. It provides an actual force to make them float.
// Note: this code is a bit scuffed, but hey it works
public class floater : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody rb;
    private Collider col;
    public float floatingForce = 1.0f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            // only apply force if more than halfway submerged in the water
            if(col.bounds.center.y < other.bounds.max.y)
            {
                // increase drag if in water
                rb.drag = 10;
                rb.angularDrag = 1f;
                float actualForce = floatingForce;

                // cancel out force if already at water's surface
                if (Mathf.Abs(Mathf.Abs(other.bounds.max.y) - Mathf.Abs(col.bounds.center.y)) < 0.005)
                {
                    actualForce = 0f;
                }

                //actually apply the force
                rb.AddForce(new Vector3(0, -1* Physics.gravity.y + actualForce, 0));
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        // decrease drag back to normal on leaving water
        rb.drag = 0;
        rb.angularDrag = 0.05f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.relativeVelocity.magnitude > 2)
        {
            //GetComponent<AudioSource>().Play();
        }
    }


}
