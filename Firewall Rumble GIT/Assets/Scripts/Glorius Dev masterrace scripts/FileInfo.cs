using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FileInfo : Rim {

    public Sign linkedSign;

    public override void Update()
    {
        reference.SetColor("_EmissionColor", new Color(2.0f, 0.0f, 0.0f, 1.0f) * intensity);
    }

    public override void GlowRim(FlyingObject fo)
    {
        base.GlowRim(fo);
        if(fo.goodFile)
        {
            linkedSign.SetText(fo.fileType,Color.green);
        }
        else
        {
            linkedSign.SetText(fo.fileType,Color.red);
        }

        if(InitializeGame.instance.currentMinutes<1 && fo.vague)
        {
            linkedSign.SetText(fo.fileType, new Color(1f,0.5f,0f,1f));
        }
    }
}
