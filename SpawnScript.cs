using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    public GameObject[] bubbles;

    public float spawnTime;
    public float spawnCounter;
    public float speedUpCounter;

    void Start()
    {
        spawnTime = 2f;

        SpawnPattern();

    }

    void Update()
    {
        spawnCounter += Time.deltaTime;
        if (spawnCounter >= spawnTime)
        {
            SpawnPattern();
            spawnCounter = 0;
        }


        speedUpCounter += Time.deltaTime;
        SpeedUp();


        SetBubbleSpeed();
    }

    void SpawnPattern()
    {
        int rng = Random.Range(1, 101);

        if (rng <= 15)
        {
            TripleSpawn();
        }
        else if(rng <= 45)
        {
            DoubleSpawn();
        }
        else
        {
            SpawnBubbles();
        }
    }

    void SpawnBubbles()
    {
        float randomX = Random.Range(-8, 6.76f);
        int randomColor = Random.Range(0, 3);

        Instantiate(bubbles[randomColor], new Vector3(randomX, 6.5f), Quaternion.identity);
    }

    void DoubleSpawn()
    {
        for (int i = 0; i < 2; i++)
        {
            SpawnBubbles();
        }
    }

    void TripleSpawn()
    {
        for (int i = 0; i < 3; i++)
        {
            SpawnBubbles();
        }
    }

    void SetBubbleSpeed()
    {
        BubbleScript[] AllBubbles = FindObjectsOfType<BubbleScript>();

        foreach (BubbleScript bubble in AllBubbles)
        {
            //bubble.bubbleMoveSpeed = 5f;
            bubble.bubbleMoveSpeed = 1f;
        }
    }

    void SpeedUp()
    {
        
        if(speedUpCounter >= 1)
        {
            if (spawnTime >= 0.8f)
            {
                spawnTime -= 0.01f;
                speedUpCounter = 0;
            }
            
        }
    }
}
