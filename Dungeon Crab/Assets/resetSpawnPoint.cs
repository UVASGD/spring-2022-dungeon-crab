using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resetSpawnPoint : MonoBehaviour
{
    public string spawnPointName = null;
    private GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            gm.lastSceneName = spawnPointName;
            gm.lastWaterLevel = gm.waterLevel;
            gm.lastLavaLevel = gm.lavaLevel;
        }
    }
}
