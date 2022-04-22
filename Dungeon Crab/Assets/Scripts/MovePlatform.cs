using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Based Off: https://www.monkeykidgc.com/2021/03/unity-moving-platform.html#comments
public class MovePlatform : MonoBehaviour
{
    public GameObject platformPathStart;
    public GameObject platformPathEnd;
    public int speed;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Rigidbody rBody;

    public bool isActive = true;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        startPosition = platformPathStart.transform.position;
        endPosition = platformPathEnd.transform.position;
        if (isActive)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
        }
        
    }

    void Update()
    {
        if (!isActive) {
            return;
        }

        if (rBody.position == endPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, startPosition, speed));
            //Vector3LerpCoroutine(gameObject, startPosition, speed);
        }
        if (rBody.position == startPosition)
        {
            StartCoroutine(Vector3LerpCoroutine(gameObject, endPosition, speed));
            //Vector3LerpCoroutine(gameObject, endPosition, speed);
        }
    }

    IEnumerator Vector3LerpCoroutine(GameObject obj, Vector3 target, float speed)
    {
        Debug.Log("Hello");
        Vector3 startPosition = obj.transform.position;
        float time = 0f;

        while (rBody.position != target)
        {
            rBody.MovePosition(Vector3.Lerp(startPosition, target, (time / Vector3.Distance(startPosition, target)) * speed));
            time += Time.deltaTime;
            yield return null;
        }
    }

    public void activate()
    {
        isActive = true;
    }

    public void deactivate()
    {
        isActive = false;
    }

    //This still isn't working :(
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Player") {
            col.gameObject.transform.SetParent(gameObject.transform, true);
        }
        
    }

    private void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Player")
        {
            col.gameObject.transform.parent = null;
        }
    }
}

/*

public class PlatformMovement : MonoBehaviour
{
    

    

    

    
}
*/