using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISerialization
{
    string ContentType { get; }
    T Deserialize<T>(string text);
}
