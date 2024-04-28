using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatCity : MonoBehaviour
{
    private Vector3 startPosition;
    private float repeatLength;
    private float speed = 1.0f;
    private GameManager gameManager;
    private SpawnManager spawnBuilding;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        repeatLength = GetComponent<BoxCollider>().size.z / 20;
        Debug.Log($"startPosition: {startPosition}");
        Debug.Log($"actual size: {GetComponent<BoxCollider>().size.z} & repeatLength: {repeatLength}");
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        spawnBuilding = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameStart == false)
        {
            speed -= 0.005f;
            
            if (speed <= 1.0f)
            {
                speed = 1.0f;
            }
        }
        else if (gameManager.isGameStart == true)
        {
            speed += 0.005f;

            if (speed >= 2.5f)
            {
                speed = 2.5f;
            }
        }

        //Debug.Log($"Nak tau speed city: {speed}");

        transform.Translate(Vector3.back * speed * Time.deltaTime, Space.World);

        /*if (transform.position.z < startPosition.z - repeatLength)
        {
            transform.position = startPosition;
        }*/

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
            //Instantiate(buildingPrefab[0], new Vector3(0, 0, 120), buildingPrefab[0].transform.rotation);
            spawnBuilding.SpawnBuilding();
        }


    }
}
