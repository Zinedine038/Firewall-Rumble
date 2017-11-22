using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RebootButton : MonoBehaviour {
    public void Click()
    {
      MotherBoard.instance.EndGame();
    }
}
