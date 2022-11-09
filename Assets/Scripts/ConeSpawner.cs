using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConeSpawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject conePrefab, newObj;
    public float tempo = 150f;
    private float tempoSpawn = 5f;

    void Update()
    {
        if (Time.time >= tempoSpawn)
        {
            spawnCone();
            tempoSpawn = Time.time + tempo;
        }
    }

    void spawnCone()
    {
        int randomIndex = Random.Range(0, spawnPoints.Length);
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(conePrefab, spawnPoints[i].position, Quaternion.identity);
            }
            else
            {
                newObj = Instantiate(conePrefab, spawnPoints[i].position, Quaternion.identity) as GameObject;
                newObj.GetComponent<SpriteRenderer>().enabled = false;
                newObj.GetComponent<Rigidbody2D>().gameObject.SetActive(true);
                newObj.GetComponent<PolygonCollider2D>().isTrigger = true;
            }
        }
    }
}
