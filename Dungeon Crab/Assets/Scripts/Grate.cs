using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script is attatched to the grate that opens up and down.
public abstract class Grate : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    abstract public void close();

    abstract public void open();

}
