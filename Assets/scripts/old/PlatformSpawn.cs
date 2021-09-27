using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlatformSpawn : MonoBehaviour
{
    public bool spawn = false;
    public GameObject BottomPlatform;
    public GameObject[] Platforms;
    private int random;
    public GameObject character;
    public int[] randomfloat = { 1, 2 };
    private RaycastHit hit;
    public List<GameObject> PlatformsInstantiate;
  


    void Start()
    {


    }


    void Update()
    {




    }
    public void OnCollisionEnter(Collision other)
    {
       
        BottomPlatform = other.gameObject;

        if (other.transform.tag == "isGround")
        {
            if (BottomPlatform.GetComponent<PlatfornSpawnOFF>().platformSpawnOff == 1)
            {
                SpawnOff_Right();
                SpawnOff_Left();
               
                random = Random.Range(0, Platforms.Length);
                SpawnPlatforms();
                BottomPlatform.GetComponent<PlatfornSpawnOFF>().platformSpawnOff = 0;
                hit.transform.gameObject.GetComponent<PlatfornSpawnOFF>().platformSpawnOff = 0;
            }

        }


    }

    bool SpawnOff_Left()
    {
        return (Physics.Raycast(transform.position, new Vector3(-1,0,0),out hit, 10f, 1, QueryTriggerInteraction.Ignore));
    }
    bool SpawnOff_Right()
    {
        return (Physics.Raycast(transform.position, new Vector3(1,0,0),out hit, 10f, 1, QueryTriggerInteraction.Ignore));
    }

    private void SpawnPlatforms()
    {

        int rElem = randomfloat[Random.Range(0, randomfloat.Length)];


        if (rElem == 1)
        {
           PlatformsInstantiate.Add(Instantiate(Platforms[random], new Vector3(Random.Range(-5f, 5f), character.GetComponent<Transform>().position.y + 5.5f, 0), Quaternion.identity));
           
          
        }
        if (rElem == 2)
        {
           PlatformsInstantiate.Add(Instantiate(Platforms[random], new Vector3(Random.Range(1f, 5f), character.GetComponent<Transform>().position.y + 5.5f, 0), Quaternion.identity));
            PlatformsInstantiate.Add(Instantiate(Platforms[random], new Vector3(Random.Range(-5f, -1f), character.GetComponent<Transform>().position.y + 5.5f, 0), Quaternion.identity));
        }
    }


}