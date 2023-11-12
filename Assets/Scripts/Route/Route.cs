using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Route/Combination")]
public class Route : ScriptableObject
{
    public List<RouteRequirement> RequirementList;
    [TextArea(3,10)]
    public string EndingNote;
}
