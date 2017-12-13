using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Sign : MonoBehaviour {
    private TextMeshPro tmp;
	// Use this for initialization
	void Start ()
    {
		tmp = GetComponentInChildren<TextMeshPro>();
	}
	
    public void SetText(string text, Color color)
    {
        tmp.text=text;
        tmp.color=color;
    }
}
