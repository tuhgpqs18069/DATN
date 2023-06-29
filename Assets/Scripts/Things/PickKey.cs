using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickKey : MonoBehaviour
{

    public Component doorCollider;
    public GameObject keyGone;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.E)) {
            doorCollider.GetComponent<DoorOpened>().enabled = true;
            keyGone.SetActive(false);
        }
        
    }
}
    