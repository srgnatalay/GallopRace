using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{
    public GameObject[] platformPrefabs;
    private float zPosition = 166f;
    

    public void Start()
    {
        SpawnPlatform();
        SpawnPlatform();
        SpawnPlatform();
    }

    public void SpawnPlatform()
    {
        GameObject go = Instantiate(platformPrefabs[Random.Range(0,4)],
            new Vector3(transform.position.x, transform.position.y, zPosition), Quaternion.identity, this.transform);
        zPosition += 83;
    }

}
