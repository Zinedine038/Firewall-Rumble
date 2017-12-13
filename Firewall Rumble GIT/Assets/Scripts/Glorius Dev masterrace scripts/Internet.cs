using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Internet : MonoBehaviour
{
    public TextMeshPro status, website, download;
    public GameObject[] fakeNews;
    public GameObject[] dodgyFiles;
    public GameObject[] normalFiles;
    private string statusConnected,statusUnstable,statusLost;
    public string[] websites;
    public string[] dodgyWebsites;
    public string[] fakeNewsSite;
    private int downloads;
    private float downloadSpeed;
    private bool connected;
    [Header("SendingObjects")]
    public Transform origin;
    public Transform destination;
    private Color green;
    public List<Transform> rims = new List<Transform>();
    private void Start()
    {
        green=download.color;
        EventManager.instance.events.Add(VisitWebsiteNormal);
        EventManager.instance.events.Add(VisitWebsiteDodgy);
        EventManager.instance.events.Add(VisitWebsiteNormalDownload);
        EventManager.instance.middleGood=VisitWebsiteNormalDownload;
        EventManager.instance.middleBad=VisitWebsiteDodgy;
    }

    #region Downloads
    public void BeginDownload()
    {
        downloads ++;
    }
    IEnumerator SetDownloadSpeed()
    {
        //if disconnected speed = 0
        while(true)
        {
            downloadSpeed = ( downloads * UnityEngine.Random.Range(200,300) ) + UnityEngine.Random.Range(-100,100);
            if(downloadSpeed>1000)
            {
                download.text = ("Current Downloads: " + downloads +" at " + (downloadSpeed/1000).ToString("F1") + "mb/s");
            }
            else
            {
                download.text = ("Current Downloads: " + downloads + " at " + downloadSpeed + "kb/s");
            }
            if(downloads<=0)
            {
                download.text = ("Current Downloads: 0 at 0 kb/s");
                downloadSpeed = 0;
            }
            yield return new WaitForSeconds(0.1f);
        }
    }
    public void RemoveDownload()
    {
        downloads -= 1;
    }
    public void DownloadDodgyFile()
    {
        GameObject DodgyFileTemp = dodgyFiles[UnityEngine.Random.Range(0, dodgyFiles.Length)];
        FlyingObjectHandler.instance.Send(DodgyFileTemp, origin, destination,rims,true, true);
        website.text=DodgyFileTemp.GetComponent<FlyingObject>().fileType;
        BeginDownload();
    }
    public void DownloadNormalFile()
    {
        GameObject normalFile = normalFiles[UnityEngine.Random.Range(0, normalFiles.Length)];
        normalFile.GetComponent<FlyingObject>().goodFile=true;
        FlyingObjectHandler.instance.Send(normalFile, origin, destination, rims, true, true);
        website.text = normalFile.GetComponent<FlyingObject>().fileType;
        BeginDownload();
    }
    #endregion

    #region Websites
    public void OpenWebsite(string url)
    {
        //website.text = ("Current Website: " + url);
    }
    public void SendFakeNews()
    {
        //FlyingObjectHandler.instance.Send(fakeNews[UnityEngine.Random.Range(0, fakeNews.Length)], origin, destination, rims, true);
    }
    #endregion

    #region WiFi
    public void Disconnected()
    {
        status.text=("Status: Disconnected");
        status.color = Color.red;
        connected=false;
    }

    public void Reconnected()
    {
        status.text=("Status: Connected");
        status.color = green;
        connected=true;
    }
    #endregion

    #region Events
    public void VisitWebsiteNormal()
    {
        OpenWebsite(websites[UnityEngine.Random.Range(0,websites.Length)]);
    }

    public void VisitWebsiteNormalDownload()
    {
        OpenWebsite(websites[UnityEngine.Random.Range(0, websites.Length)]);
        DownloadNormalFile();
    }

    public void VisitWebsiteDodgy()
    {
        OpenWebsite(dodgyWebsites[UnityEngine.Random.Range(0, dodgyWebsites.Length)]);
        DownloadDodgyFile();
    }

    public void VisitWebsiteFakeNews()
    {
        OpenWebsite(fakeNewsSite[UnityEngine.Random.Range(0, fakeNewsSite.Length)]);
        SendFakeNews();
    }
    #endregion


}
