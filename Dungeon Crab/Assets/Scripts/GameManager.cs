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
    //static reference to the current GameManager- can be accessed from anywhere with GameManager.instance
    public static GameManager instance;

    //information that's stored between scenes on number of keys the player currently has, water/lava levels
    public int numberOfKeys = 0;
    public int waterLevel = 0;
    public int lavaLevel = 0;

    //time to transition between scenes
    public float transitionTime = 0.2f;
    
    //information about the last level name and the water/lava from before this scene began, used for spawning logic between scenes
    public string lastSceneName = null;
    public int lastWaterLevel = 0;
    public int lastLavaLevel = 0;

    // stores info about whether the player has unlocked the water gun, their current ammo
    public bool waterGunUnlocked = false;
    public int waterGunAmmo = 50;

    // list of the ids all of the burned things that need to stay burned between scenes (mostly door boards)
    public List<string> burnedThings = new List<string>();

    //List of all the key objects that a player has collected already that need to stay collected
    public List<string> keysCollected = new List<string>();

    //private things used in this script
    private AudioManager am = null;
    bool restarting = false;

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
        if(AudioManager.instance != null)
        {
            am = AudioManager.instance;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            if (!restarting)
            {
                restarting = true;
                RestartScene();
            }
        }
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
    //set the lava level to a given int value. Lava objects will look for the lava level to determine if they need to raise/lower.
    public bool setLavaLevel(int level)
    {
        if (lavaLevel == level)
        {
            return false;
        }
        lavaLevel = level;
        return true;
    }

    //useKey: if the player has any keys, lose one key and return true. If the player has no keys, return false.
    public bool useKey()
    {
        if (am != null)
        {
            am.Play("Open Door");
        }
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
        //set water/lava backups so they're remembered on reload
        lastWaterLevel = waterLevel;
        lastLavaLevel = lavaLevel;
        // save this scene name for spawning logic
        lastSceneName = SceneManager.GetActiveScene().name;
        // fade out
        ScreenFade sf = FindObjectOfType<ScreenFade>();
        if (sf)
        {
            sf.FadeOut();
        }
        // load level
        StartCoroutine(LoadLevelFromName(sceneName));
    }
    public void RestartScene()
    {
        //set water/lava back to what they were when the scene began
        waterLevel = lastWaterLevel;
        lavaLevel = lastLavaLevel;
        //fade out
        ScreenFade sf = FindObjectOfType<ScreenFade>();
        if (sf)
        {
            sf.FadeOut();
        }
        //restart level
        StartCoroutine(LoadLevelFromName(SceneManager.GetActiveScene().name));
    }

    IEnumerator LoadLevelFromName(string sceneName)
    {
        //transition.SetTrigger("WipeOut");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneName);
        restarting = false;
    }
}
