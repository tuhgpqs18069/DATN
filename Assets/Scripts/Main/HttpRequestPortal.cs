using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Networking;

public class HttpRequestPortal : MonoBehaviour
{
    private readonly ISerialization _serialization;

    public HttpRequestPortal(ISerialization serialization)
    {
        _serialization = serialization;
    }

    public async Task<T> Get<T>(string url)
    {
        try
        {
            using var www = UnityWebRequest.Get(url);
            www.SetRequestHeader("Content-Type", _serialization.ContentType);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = _serialization.Deserialize<T>(www.downloadHandler.text);
            return result;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }
    public async Task<T> Post<T>(string url, WWWForm form)
    {
        try
        {
            using var www = UnityWebRequest.Post(url, form);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = _serialization.Deserialize<T>(www.downloadHandler.text);
            return result;
        }
        catch (Exception e)
        {

            Debug.Log(e.Message);
            return default;
        }
    }
}
