using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("ok");
        if(other.CompareTag("Water"))
        {
            this.gameObject.SetActive(false);
            Debug.Log("ok");
        }
        if (other.CompareTag("Fire"))
        {
            this.gameObject.SetActive(true);
        }
    }
}
