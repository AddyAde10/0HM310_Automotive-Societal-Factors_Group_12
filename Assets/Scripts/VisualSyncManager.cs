using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//broadcast visual syncing network message and displays red bar as a visual synchronization marker (used to syncing gameplay videos captured on different devices)
public class VisualSyncManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;

    public void Update()
    {   
        
        elapsedTime += Time.deltaTime;
    }

    public void DoHostGUI(Host host)
    {
        if (!NetworkingManager.Instance.hideGui && GUILayout.Button($"Visual syncing"))
        {
            host.BroadcastMessage(new VisualSyncMessage());
            DisplayMarker();
            print(elapsedTime);
        }
    }



    public void DisplayMarker()
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        coroutine = ShowMarkerCoroutine();
        StartCoroutine(coroutine);
    }

    IEnumerator coroutine;

    IEnumerator ShowMarkerCoroutine()
    {
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        GetComponent<Renderer>().enabled = false;
    }
}

