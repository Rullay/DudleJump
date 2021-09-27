using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject character;
    private float hightCameraPosition;
    private Vector3 p;

    void Start()
    {
        hightCameraPosition = 0;
    }

    void Update()
    {

        p = Vector3.Lerp(new Vector3(transform.position.x, transform.position.y, transform.position.z), new Vector3(transform.position.x, hightCameraPosition, transform.position.z), 0.05f);

        p.x = transform.position.x;
        p.z = transform.position.z;
        if (character.GetComponent<Move>().CHARACTERDEATH)
        {
            p.y = transform.position.y;
        }

        if (character.GetComponent<Transform>().position.y > hightCameraPosition)
        {
            hightCameraPosition = Mathf.Lerp(hightCameraPosition, character.GetComponent<Transform>().position.y, 0.5f);
        }

        if (hightCameraPosition - 3f >= character.GetComponent<Transform>().position.y)
        {
            hightCameraPosition = Mathf.Lerp(hightCameraPosition, hightCameraPosition - 3f, 0.7f);
        }
        transform.position = p;
    }



    void LateUpdate()
    {

    }

}
