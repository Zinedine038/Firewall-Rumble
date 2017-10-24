using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MotherBoard : MonoBehaviour {
    public static MotherBoard instance;
    public TextMeshPro corruptionText;
    public float corruptionLevel;
	public void Corrupt(float corruptionAmount)
    {
        corruptionLevel+=corruptionAmount;
        corruptionText.text=("System Corruption: " + corruptionLevel + "%");
        if(corruptionLevel>=100)
        {
            //die
        }
    }
}
