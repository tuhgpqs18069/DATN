using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResponseAPIModel
{
    public User user { get; set; }
}
public class User
{
    public string _id { get; set; }
    public string name { get; set; }
    public string email { get; set; }
    public int age { get; set; }
}

