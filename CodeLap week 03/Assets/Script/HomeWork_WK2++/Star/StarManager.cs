using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarManager : MonoBehaviour
{
    //set thisn as static
    public static StarManager starManager;
    
    //set Star info
    public Star_Info[] starsInfo;
    
    // Start is called before the first frame update
    void Awake()
    {
        starManager = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

[System.Serializable]
//set up player class to assign button and statistic
public class Star_Info
{
    public string name;
    public int score;
}