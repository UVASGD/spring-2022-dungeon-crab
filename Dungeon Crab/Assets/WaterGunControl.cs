using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterGunControl : MonoBehaviour
{
    public GameObject WaterGun;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            GameObject water = (GameObject)Instantiate(WaterGun, transform.position, transform.rotation);
            /*
            Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            nextSpark.SendMessage("setupDir", nextDirection);
            nextSpark.SendMessage("setupSpark", spark);
            nextSpark.SendMessage("setupIntense", 150);
            nextSpark.SendMessage("setJoint");*/
        }
    }
}
