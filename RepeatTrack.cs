using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatTrack : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatLength;
    private float initialSpeed = 20.0f;
    public float speed;
    //private float minSpeed = 5.0f;
    private float maxSpeed = 120.0f;
    //private float slowSpeed = 10.0f;
    //private float tiltAngle = 15.0f;
    //private int repeatCounter = 0;
    private GameManager gameManager;

    //private TrafficCar traffic;
    //private GameObject[] sensor;

    private void Awake()
    {
        speed = initialSpeed;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        /*traffic = GameObject.FindGameObjectWithTag("Traffic").GetComponent<TrafficCar>();*/
        startPosition = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z * 4;
        Debug.Log($"startPosition: {startPosition}");
        Debug.Log($"repeatLength: {repeatLength}");
        
    }

    // Update is called once per frame
    void Update()
    {
        //sensor = GameObject.FindGameObjectsWithTag("Traffic");

        if (transform.position.z < startPosition.z - repeatLength)
        {
            //repeatCounter++;
            transform.position = startPosition;
            //Debug.Log($"Position repeated : {repeatCounter}");
        }
    }

    private void FixedUpdate()
    {
        MoveTrack();

        /*if (Input.GetKey(KeyCode.DownArrow))
        {
            BreakingTrack();
            MoveTrafficForward();
        } 
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            MoveTrack();
            MoveTrafficBackward();
        }*/
    }

    void MoveTrack()
    {
        if (gameManager.isGameStart == true)
        {
            speed += 0.1f;
        }
        else if (gameManager.isGameStart == false)
        {
            speed -= 0.1f;
        }

        if (speed > maxSpeed)
        {
            speed = maxSpeed;
        }
        else if (speed < initialSpeed)
        {
            speed = initialSpeed;
        }

        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    /*void BreakingTrack()
    {
        speed -= 0.2f;

        if (speed < minSpeed)
        {
            speed = minSpeed;
        }

        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }*/

    /*public void MoveTrafficForward()
    {
        // GetComponent from all objects with the "Traffic" tag
        foreach (GameObject automobile in sensor)
        {
            if (automobile != null)
            {
                automobile.GetComponent<TrafficCar>().speed += 0.05f;

                if (automobile.GetComponent<TrafficCar>().speed > automobile.GetComponent<TrafficCar>().topSpeed)
                {
                    automobile.GetComponent<TrafficCar>().speed = automobile.GetComponent<TrafficCar>().topSpeed;
                }

                //Debug.Log($"The traffic drive speed: {automobile.GetComponent<TrafficCar>().speed}");
            }
        }

        // GetComponent from one object with the "Traffic" tag
        *//*traffic.speed += 0.05f;

        if (traffic.speed > traffic.topSpeed)
        {
            traffic.speed = traffic.topSpeed;
        }*//*
    }*/

    /*public void MoveTrafficBackward()
    {
        // GetComponent from all objects with the "Traffic" tag
        foreach (GameObject automobile in sensor)
        {
            if (automobile != null)
            {
                automobile.GetComponent<TrafficCar>().speed = -3.0f;

                *//*if (automobile.GetComponent<TrafficCar>().speed < -1.0f)
                {
                    automobile.GetComponent<TrafficCar>().speed = -1.0f;
                }
    *//*
                //Debug.Log($"The traffic breaking speed: {automobile.GetComponent<TrafficCar>().speed}");
            }
        }

        // GetComponent from one object with the "Traffic" tag
        *//*traffic.speed = -1.0f;*//*
    }*/


}
