using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using TMPro;

//broadcast visual syncing network message and displays red bar as a visual synchronization marker (used to syncing gameplay videos captured on different devices)
public class VisualSyncManager : MonoBehaviour
{
    //float elapsedTime;
    //[SerializeField] TextMeshProGUI timerText;
    public void DoHostGUI(Host host)
    {
        if (!NetworkingManager.Instance.hideGui && GUILayout.Button($"Visual syncing"))
        {
            host.BroadcastMessage(new VisualSyncMessage());
            DisplayMarker();
            //DisplayTimer();
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

    //public void DisplayTimer()
    //{
    //    elapsedTime += Time.deltaTime;
    //    timerText.text = elapsedTime.ToString();
    //}

    IEnumerator coroutine;

    IEnumerator ShowMarkerCoroutine()
    {
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(1f);
        GetComponent<Renderer>().enabled = false;
    }
}
