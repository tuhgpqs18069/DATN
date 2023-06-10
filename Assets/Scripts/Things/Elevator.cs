using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{

    public Transform player;
    public Transform elevatorSwitch;
    public Transform downPos;
    public Transform upperPos;

    public float speed;
    bool isElevatorDown;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartElevator1();
    }

    void StartElevator1()
    {
        if (Vector2.Distance(player.position, elevatorSwitch.position) < 2.5f && Input.GetKeyDown("x"))
        {
            if(transform.position.y <= downPos.position.y)
            {
                isElevatorDown = true;
            }
            else if(transform.position.y >= upperPos.position.y){
                isElevatorDown = false;
            }
        }

        if (isElevatorDown)
        {
            transform.position = Vector2.MoveTowards(transform.position, upperPos.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, downPos.position, speed * Time.deltaTime);
        }
    }

}
