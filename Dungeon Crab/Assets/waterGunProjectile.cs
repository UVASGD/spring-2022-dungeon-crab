using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waterGunProjectile : MonoBehaviour
{
    bool destroy = false;
    float timeToDestroy = 0.15f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (destroy)
        {
            timeToDestroy -= Time.deltaTime;
            this.transform.localScale -= new Vector3(transform.localScale.x * Time.deltaTime / timeToDestroy, transform.localScale.x * Time.deltaTime / timeToDestroy, transform.localScale.x * Time.deltaTime / timeToDestroy);
        }
    }
    private void FixedUpdate()
    {
        if (timeToDestroy < 0)
        {
            Object.Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag != "Player" && other.isTrigger == false)
        {
            destroy = true;
        }
    }
}
