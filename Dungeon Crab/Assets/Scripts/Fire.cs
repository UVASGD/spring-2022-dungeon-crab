using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public bool isFireActive;
    public ParticleSystem fire;
    public ParticleSystem smoke;
    public ParticleSystem burstSmoke;
    public GameObject fireLight;

    private bool waterlogged;

    private void Start()
    {
        if (isFireActive)
        {
            ReLight();
        }
        else
        {
            isFireActive = false;
            fire.Stop();
            smoke.Stop();
            fireLight.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterlogged = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            waterlogged = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {

        if(other.CompareTag("Water") && isFireActive)
        {
            waterlogged = true;
            Extinguish();
        }
        if (other.CompareTag("Fire") && !isFireActive && !waterlogged)
        {
            Fire otherFire = other.GetComponent<Fire>();
            if (otherFire != null && otherFire.isFireActive)
            {
                ReLight();
            }
        }
        if (other.CompareTag("Lava") && !isFireActive)
        {
            ReLight();
        }
    }

    public void Extinguish()
    {
        isFireActive = false;
        fire.Stop();
        smoke.Stop();
        burstSmoke.Play();
        fireLight.SetActive(false);
    }

    public void ReLight()
    {
        isFireActive = true;
        smoke.Play();
        fire.Play();
        burstSmoke.Stop();
        fireLight.SetActive(true);
    }
    void Update()
    {
        if(this.transform.parent != null)
        {
            this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, this.transform.parent.rotation.z * -1.0f);
        }
    }
}
