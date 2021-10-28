using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "FoodItemConfig", menuName = "FoodGameConfigs/FoodItemConfig")]
public class FoodItemConfig : ScriptableObject
{
    public string foodName;
    //using mass wasn't working well for me, so i used rigidbody's drag instead
    public float drag;
    public int score;
}
