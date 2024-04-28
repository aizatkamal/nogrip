using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficCar : MonoBehaviour
{
    private Rigidbody vehicle;
    //private RepeatTrack track;
    private float speed = 4;
    private float topSpeed = 3;
    private GameManager gameManager;
    //private PlayerController player;

    // Start is called before the first frame update
    void Start()
    {
        vehicle = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        //track = GameObject.Find("Track").GetComponent<RepeatTrack>();
    }

    private void FixedUpdate()
    {
        //Debug.Log($"Track speed: {track.speed} & Car speed: {speed}");
        //vehicle.AddForce(Vector3.back * -speed * Time.deltaTime, ForceMode.Impulse);
        if (gameManager.isGameStart == true)
        {
            vehicle.AddForce(Vector3.back * speed * Time.deltaTime, ForceMode.Impulse);
        }
        else if (gameManager.isGameStart == false || gameManager.isGameActive == false)
        {
            vehicle.AddForce(Vector3.back * -2.0f * Time.deltaTime, ForceMode.Impulse);
        }

        vehicle.detectCollisions = false;
        if (transform.position.z < 90.0f)
        {
            vehicle.detectCollisions = true;
        }

        if (transform.position.z < 15.0f)
        {
            speed++;
        }
        //StartCoroutine(ActivateCollisions());

        //sensor.MovePosition(transform.position + (Vector3.forward * speed * Time.deltaTime));
    }

    // Update is called once per frame
    void Update()
    {
        // Destroy object out of scene
        if (transform.position.z < -10.0f || transform.position.z > 150.0f)
        {
            Destroy(gameObject);
        }


        if (transform.position.z < 0.8f)
        {
            // TODO : Put a swooshing overtake sound effects
            //Debug.Log("Swooshhhhh...!!");
        }


    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Traffic"))
        {
            //Debug.Log("Clashed !!");

            if (vehicle.transform.position.z > 90.0f || vehicle.transform.position.z < 21.0f)
            {
                Destroy(gameObject);
                Destroy(collision.gameObject);
            }

            //Destroy(gameObject);
            //Destroy(collision.gameObject);
           
        }
        /*else if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("BOOM !!! Game Over !!");
        }*/

    }

    


}
