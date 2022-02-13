using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//This script is for the game manager, which is an object that keeps track of various game data/states.
// There should be one game manager in every scene. Objects can reference the game manager in a scene in order to access this data.
// Note that Game Managers use the singleton structure: what this means is that there will always be one in a scene at a time.
// Also, if you switch scenes, the Game Manager will actually carry over; this means that if you need any info
// to carry over between scenes (ie number of keys, player health), use the Game Manager to store that information.
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public int numberOfKeys = 0;
    public int waterLevel = 0;
    public float transitionTime = 0.2f;
    private void Awake()
    {
        // this is the code to ensure there's only one gameManager in a scene at a time
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        //This is the code that carries the GM over between scenes
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //returns the number of keys the player currently has.
    public int getKeys()
    {
        return numberOfKeys;
    }

    //add a key to the players inventory.
    public void keyObtained()
    {
        numberOfKeys++;
    }
    //set the water level to a given int value. Water objects will look for the water level to determine if they need to raise/lower.
    public bool setWaterLevel(int level)
    {
        if(waterLevel == level)
        {
            return false;
        }
        waterLevel = level;
        return true;
    }

    //useKey: if the player has any keys, lose one key and return true. If the player has no keys, return false.
    public bool useKey()
    {
        if (numberOfKeys > 0)
        {
            numberOfKeys--;
            return true;
        }
        else
        {
            return false;
        }
    }

    public void loadLevel(string sceneName)
    {
        StartCoroutine(LoadLevelFromName(sceneName));
    }

    IEnumerator LoadLevelFromName(string sceneName)
    {
        //transition.SetTrigger("WipeOut");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
    }
}
