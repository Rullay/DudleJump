using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfornSpawnOFF : MonoBehaviour
{
    public GameObject isGround;
    public float platformSpawnOff;
    public GameObject character;

    void Start()
    {
        platformSpawnOff = 1;
        character = GameObject.Find("character");
    }


    void Update()   
    {
       //DestroyPlatform();
    }

    void DestroyPlatform()
    {
        
        if (transform.position.y <= character.GetComponent<Transform>().position.y - 10f)
        {
            Destroy(gameObject);
            //isGround.GetComponent<PlatformSpawn>().PlatformsInstantiate.Remove(gameObject);
        }
    }

    
}
