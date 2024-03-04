using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;
using static ApiHandler;

public class ApiHandler : MonoBehaviour
{
    //public TextMeshProUGUI outputText;

    //IEnumerator Start()
    //{
    //    string url = "https://qa.sunbasedata.com/sunbase/portal/api/assignment.jsp?cmd=client_data";

    //    UnityWebRequest request = UnityWebRequest.Get(url);

    //    yield return request.SendWebRequest();

    //    if (request.result != UnityWebRequest.Result.Success)
    //    {
    //        Debug.Log("Error : " + request.error);
    //    }
    //    else
    //    {
    //        JSONNode Info = JSON.Parse(request.downloadHandler.text);
    //    }
    //}
}
