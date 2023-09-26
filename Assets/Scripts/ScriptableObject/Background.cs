using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBackGroundData", menuName = "ScriptableObjects/Background")]
public class Background : ScriptableObject
{
    public List<Sprite> background;
}

