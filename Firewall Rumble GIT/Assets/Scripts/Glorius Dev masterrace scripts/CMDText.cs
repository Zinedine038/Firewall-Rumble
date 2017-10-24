using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CMD Text", menuName = "CMD/Scriptable CMD Text", order = 1)]
public class CMDText : ScriptableObject
{
    public bool clearPrevious;
    public string fileLocation;
    public Line[] lines;	
}

[System.Serializable]
public struct Line
{
    public string line;
    public bool useFileLocation;
}

