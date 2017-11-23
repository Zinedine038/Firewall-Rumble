using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CloneOther : MonoBehaviour {
    public TextMeshPro other;
	// Update is called once per frame
	void Update () {
		GetComponent<TextMeshPro>().text=other.text;
	}
}
