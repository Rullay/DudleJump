using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderOff : MonoBehaviour
{
    public GameObject[] Platforms;
    public GameObject character;

    void Start()
    {
        
    }


    void Update()
    {
       // colliderOff();
    }
    void colliderOff()
    {
        if (character.GetComponent<Move>().verticalVelocity >= 1)
        {
            Platforms = GameObject.FindGameObjectsWithTag("isGround");
            foreach (GameObject platform in Platforms)
            {
                platform.GetComponent<BoxCollider>().enabled = false;
            }
        }

        if (character.GetComponent<Move>().verticalVelocity < 1)
        {
            Platforms = GameObject.FindGameObjectsWithTag("isGround");
            foreach (GameObject platform in Platforms)
            {
                platform.GetComponent<BoxCollider>().enabled = true;
            }
        }
    }

   



}
