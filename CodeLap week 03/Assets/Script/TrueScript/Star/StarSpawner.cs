using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    //set this as static
    public static StarSpawner starSpawner;
    
    //set SpawnRate
    public SpawnRate rate;
    public GameObject[] starSpawning;
    
    //set how to calculate spawn
    public SpawnTimes times;
    private int spawnTimesReal;
    private int starNumber;

    void Awake()
    {
        //make static or destroy
        if (starSpawner == null)
        {
            DontDestroyOnLoad(gameObject);
            starSpawner = this;
        }
        else
        {
            Destroy(gameObject);
        }
        
        //set rating method
        starSpawning = new GameObject[rate.size];

        for (int i = 0; i < starSpawning.Length; i++)
        {
            if (i <= rate.yellowRate) //load up rate of yellow
            {
                starSpawning[i] = Resources.Load<GameObject>("Prefab/TruePrefab/Star/StarYellow_Prefab");
            }
            else if (i <= rate.yellowRate + rate.blueRate) //load up rate of blue
            {
                starSpawning[i] = Resources.Load<GameObject>("Prefab/TruePrefab/Star/StarBlue_Prefab");
            }
            else if (i > rate.yellowRate + rate.blueRate) //load up rate of purple
            {
                starSpawning[i] = Resources.Load<GameObject>("Prefab/TruePrefab/Star/StarPurple_Prefab");
            }
        }
    }

    public void spawnStar() //use this function to spawn star
    {
        spawnTimesReal = Random.Range(times.spawnNum_min, times.spawnNum_max);
        
        //spawning
        if (times.maxSpawn > 0)
        {
            for (int i = 0; i < spawnTimesReal; i++)
            {
                starNumber = Random.Range(0, starSpawning.Length);
                Instantiate(starSpawning[starNumber]);
            }

            times.maxSpawn -= 1;
        }
    }
}

[System.Serializable]
//set up spawnStatistic
public class SpawnRate
{
    public int size;
    public int yellowRate;
    public int blueRate;
    public int purpleRate;
}

[System.Serializable]
//set up how to Spawn
public class SpawnTimes
{
    public int maxSpawn;
    public int spawnNum_min;
    public int spawnNum_max;
}
