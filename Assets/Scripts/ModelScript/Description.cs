using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Details", menuName = "ScriptableObjects/Details", order = 1)]
public class Description : ScriptableObject
{
    new public string nameof = "Cube";

    public string description = "Details";
}
