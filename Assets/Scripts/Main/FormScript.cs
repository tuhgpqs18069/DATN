using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class FormScript : MonoBehaviour
{
    EventSystem eventSystem;
    public Selectable firstInput;
    public Button submitButton;
    // Start is called before the first frame update
    void Start()
    {
        eventSystem = EventSystem.current;
        firstInput.Select();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab) && Input.GetKey(KeyCode.LeftShift))
        {
            Selectable previous = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnUp();
            if (previous != null)
            {
                previous.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = eventSystem.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            submitButton.onClick.Invoke();
        }
    }
}
