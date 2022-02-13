using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the script for key objects.
public class keyScript : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager gm;
    void Start()
    {
        gm = FindObjectOfType<GameManager>();
    }

    // rotating animation
    void Update()
    {
        this.transform.Rotate(new Vector3(0,0,1));
    }

    // collect the key if the player walks into the collider trigger
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            gm.keyObtained();
            gameObject.SetActive(false);
        }
    }
}
