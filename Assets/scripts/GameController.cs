using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] Platforms;
    private int random;
    public GameObject character;
    public int[] randomfloat = { 1, 2 };
    public List<GameObject> PlatformsInstantiate;
    public GameObject hightPlatform;

    void Start()
    {

    }


    void Update()
    {
        PlatformSpawner();
        
    }


    void PlatformSpawner()
    {
        for (int i = 0; i < PlatformsInstantiate.Count; i++)
        {
            if (PlatformsInstantiate[i].GetComponent<Transform>().position.y > hightPlatform.transform.position.y)
            {
                hightPlatform = PlatformsInstantiate[i];

            }

        }
        if (character.GetComponent<Transform>().position.y >= hightPlatform.GetComponent<Transform>().position.y - 10f)
        {
            SpawnPlatforms();
            PlatformDestoroy();
        }
    }



    private void SpawnPlatforms()
    {
        random = Random.Range(0, Platforms.Length);
        int rElem = randomfloat[Random.Range(0, randomfloat.Length)];


        if (rElem == 1)
        {
            PlatformsInstantiate.Add(Instantiate(Platforms[random], new Vector3(Random.Range(-5f, 5f), hightPlatform.GetComponent<Transform>().position.y + 4f, 0), Quaternion.identity));
        }
        if (rElem == 2)
        {
            PlatformsInstantiate.Add(Instantiate(Platforms[random], new Vector3(Random.Range(1f, 5f), hightPlatform.GetComponent<Transform>().position.y + 4f, 0), Quaternion.identity));
            PlatformsInstantiate.Add(Instantiate(Platforms[random], new Vector3(Random.Range(-5f, -1f), hightPlatform.GetComponent<Transform>().position.y + 4f, 0), Quaternion.identity));
        }
    }

    void PlatformDestoroy()
    {
        for (int i = 0; i < PlatformsInstantiate.Count; i++)
        {
            if (PlatformsInstantiate[i].GetComponent<Transform>().position.y + 12f <= character.GetComponent<Transform>().position.y)
            {
                Destroy(PlatformsInstantiate[i]);
                PlatformsInstantiate.Remove(PlatformsInstantiate[i]);
            }
        }
    }

}
