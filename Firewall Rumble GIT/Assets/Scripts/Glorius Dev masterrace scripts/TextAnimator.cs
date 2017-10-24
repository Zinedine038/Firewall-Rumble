using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(AudioSource))]
public class TextAnimator : MonoBehaviour {
    public static TextAnimator instance;
    public TextMeshPro textMesh;
    private bool idle;
    private string newLine = "\n";
    public AudioClip keySound;
    public List<CMDTextEntry> queue;
    bool processorFinished=true;
    private void Start()
    {
        instance=this;
        StartCoroutine(Idle());
        StartCoroutine(Queue());
    }

    public void ProcessTextImmidiate(CMDText scriptableLines)
    {
       StopAllCoroutines();
       StartCoroutine(TextProcessor(scriptableLines,true));
    }

    IEnumerator Queue()
    {
        while(true)
        {
            if(processorFinished && queue.Count>0)
            {
                yield return new WaitForSeconds(queue[0].delay);
                print(queue[0]);
                StartCoroutine(TextProcessor(queue[0].cmdText));
                queue.RemoveAt(0);
            }
            yield return null;
        }
    }

    IEnumerator TextProcessor(CMDText scriptableLines, bool immediate = false)
    {
        processorFinished=false;
        if(scriptableLines.clearPrevious)
        {
            textMesh.text="";
        }
        idle=false;
        textMesh.text = textMesh.text.Replace(">", "");
        foreach (Line line in scriptableLines.lines)
        {
            textMesh.text=textMesh.text+"\n";
            string newLine;
            if(line.useFileLocation)
            {
               newLine = scriptableLines.fileLocation + line.line;
            }
            else
            {
                newLine=line.line;
            }
            foreach(char c in newLine.ToCharArray())
            {
                GetComponent<AudioSource>().PlayOneShot(keySound);
                textMesh.text+=c;
                yield return new WaitForSeconds(0.05f);
            }
        }
        idle=true;
        processorFinished=true;
        if(immediate)
        {
            queue.Clear();
            StartCoroutine(Queue());
            StartCoroutine(Idle());
        }
    }


    IEnumerator Idle()
    {
        idle=true;
        while(true)
        {
            while (idle)
            {
                textMesh.text = textMesh.text + "_";
                yield return new WaitForSeconds(0.5f);
                textMesh.text = textMesh.text.Replace("_", "");
                yield return new WaitForSeconds(0.5f);
            }
            yield return null;
        }
    }
}
