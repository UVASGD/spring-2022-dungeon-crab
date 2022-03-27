using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Keys : MonoBehaviour
{
    // Start is called before the first frame update
    public Text keys;

    // Update is called once per frame
    void Update()
    {
        keys.text = "Keys: "+GameManager.instance.getKeys().ToString();
    }
}
