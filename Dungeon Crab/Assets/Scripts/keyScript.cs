using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// This is the script for key objects.
public class keyScript : MonoBehaviour
{
    //this id is used in the game manager to keep track of which keys have been collected already
    private string id;
    // Start is called before the first frame update
    void Start()
    {
        id = SceneManager.GetActiveScene().name + this.transform.ToString();
        // if this key has already been collected, destroy it
        if (GameManager.instance.keysCollected.Contains(id) == true)
        {
            Destroy(this.gameObject);
        }
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
            GameManager.instance.keyObtained();
            if (GameManager.instance.keysCollected.Contains(id) == false)
            {
                GameManager.instance.keysCollected.Add(id);
            }
            gameObject.SetActive(false);
        }
    }
}
