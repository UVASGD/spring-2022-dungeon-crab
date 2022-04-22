using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnPoint : MonoBehaviour
{
    public string spawnFromSceneName = null;
    public float startingDirection = 0f;
    public GameObject prefabToSpawn;
    // Start is called before the first frame update
    void Start()
    {
        //If there's no player in the scene, and the last transition corresponds to this spawn point, then spawn a player
        if (FindObjectOfType<playermovement>() == null && GameManager.instance != null && GameManager.instance.lastSceneName != null && GameManager.instance.lastSceneName == spawnFromSceneName)
        {
            GameObject player = GameObject.Instantiate(prefabToSpawn, new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z), Quaternion.identity);
            player.transform.rotation = Quaternion.Euler(0, startingDirection, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
