using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Serialization : ISerialization
{
    public string ContentType => "application/json";

    public T Deserialize<T>(string text)
    {
        try
        {
            var result = JsonConvert.DeserializeObject<T>(text);
            return result;
        }
        catch (Exception e)
        {
            Debug.Log(e);
            return default;
        }
    }
}
