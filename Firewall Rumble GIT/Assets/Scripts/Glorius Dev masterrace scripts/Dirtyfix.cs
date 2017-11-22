using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dirtyfix : MonoBehaviour
{
	public GameObject[] objs;
    public static Dirtyfix instance;

    private void Start()
    {
        instance=this;
    }

    public void ToggleGuns(bool toggle)
    {
        objs[0].SetActive(toggle);
        objs[1].SetActive(toggle);
    }
}
