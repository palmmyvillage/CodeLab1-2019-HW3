using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ClassManager : MonoBehaviour
{
    //set this class as Static
    public static ClassManager classManager;

    public enum Class
    {
        Warrior,
        Cleric,
        Mage,
        Panda
    }

//set up stat for all classes
    public Class_Info[] classInfo;
    
    // Start is called before the first frame update
    void Awake()
    {
        //make static or destroy
        if (classManager == null)
        {
            DontDestroyOnLoad(gameObject);
            classManager = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
    #region Helper Functions

    public float GetClassRunningForce(Class @class)
    {
        foreach (var type in classInfo)
        {
            if (@class == type.my)
                return type.runningForce;
        }

        return 0.0f;
    }
    
    #endregion

}

[System.Serializable]
//set up player class to assign button and statistic
public class Class_Info
{
    [FormerlySerializedAs("myType")] public ClassManager.Class my;
    public string name;
    public float runningForce;
    public float runningLimit;
    public float jumpingForce;
    public float gravityInput;
}
