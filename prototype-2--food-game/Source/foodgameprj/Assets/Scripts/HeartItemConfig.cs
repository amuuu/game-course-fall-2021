using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HeartItemConfig", menuName = "FoodGameConfigs/HeartItemConfig")]
public class HeartItemConfig : ScriptableObject
{
    public string heartName;
    public float weight;
    public int value;
}
