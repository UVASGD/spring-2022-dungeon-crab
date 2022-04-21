using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunControl : MonoBehaviour
{
    public GameObject WaterGun;
    public float coolDownTime = 1;
    public float spawnDistance = 0.2f;
    public float spawnSpeed = 0f;
    public float coolDown = 0;
    public float spread = 1f;

    private bool keyDown = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKey(KeyCode.RightShift))
        {
            keyDown = true;
        }
        else
        {
            keyDown = false;
        }

        if (keyDown && coolDown <= 0f)
        {
            //Collider[] hitColliders = Physics.OverlapSphere(transform.position + transform.position * spawnDistance, radius);
            //if(hitColliders.Length < 1)
            //{ Quaternion.Euler()
            //for (float i = 0; i < 4; i+=1f)
            //{
                GameObject water = (GameObject)Instantiate(WaterGun, transform.position + transform.forward * spawnDistance * (4/4), transform.rotation);
                Rigidbody rb;
                if ((rb = water.GetComponent<Rigidbody>()) != null)
                {
                    rb.velocity = (new Vector3(Random.Range(transform.forward.x + spread, transform.forward.x - spread), Random.Range(transform.forward.y + spread, transform.forward.y - spread), Random.Range(transform.forward.z + spread, transform.forward.z - spread)).normalized + new Vector3(0, 0.3f, 0)) * spawnSpeed * Random.Range(0.9f,1.1f);
                }
                coolDown = coolDownTime;
            //}
            //}
            
            /*
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            nextSpark.SendMessage("setupDir", nextDirection);
            nextSpark.SendMessage("setupSpark", spark);
            nextSpark.SendMessage("setupIntense", 150);
            nextSpark.SendMessage("setJoint");*/
            
        }

        if(coolDown > 0f)
        {
            coolDown-= Time.deltaTime;
        }
    }
}
