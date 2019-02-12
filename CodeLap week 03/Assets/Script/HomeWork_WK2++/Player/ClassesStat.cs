using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassesStat : MonoBehaviour
{
    //set this class as Static
    public static ClassesStat classesStat;
    
    //set up stat for all classes
    public Class_Info[] classInfo;
    
    // Start is called before the first frame update
    void Awake()
    {
        classesStat = this;
    }

}

[System.Serializable]
//set up player class to assign button and statistic
public class Class_Info
{
    public string name;
    public float runningForce;
    public float runningLimit;
    public float jumpingForce;
    public float gravityInput;
}
