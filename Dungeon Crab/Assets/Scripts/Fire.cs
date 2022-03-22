using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This scipt defines the behavior of fire. It is set to active when meeting other fire and disappear
//when in contact with water
public class Fire : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Water"))
        {
            foreach(Transform child in this.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
        if (other.CompareTag("Fire"))
        {
            foreach (Transform child in this.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }
}
