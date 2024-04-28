using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] vehiclePrefab;
    public GameObject[] buildingPrefab;
    public GameObject sensor;
    //private Rigidbody vehicleRb;
    //private float spawnXPos;
    //private float spawnZPos;
    //private float previousXPos = 0;
    //private float previousZPos = 120.0f;
    private float[] xPos = { -7.0f, -2.3f, 2.3f, 7.0f };
    private float yPos = 3.5f;
    private float zPos;
    private GameManager gameManager;

    // Start is called before the first frame update

    void Start()
    {
        InvokeRepeating("SpawnWhenStart", 0.5f, 1.8f);
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*//Invoke("SpawnVehicle", 3.0f * Time.deltaTime);
        if (Input.GetKeyDown(KeyCode.T))
        {
            CancelInvoke();
            InvokeRepeating("SpawnVehicles", 2.0f, 1.0f);
        }*/


        if (gameManager.isGameActive == false)
        {
            CancelInvoke();
        }
               

    }

    /*int JMax(int j, List<Vector3> spawnPos)
    {
        int jMax = (j == 0) ? Random.Range(2, spawnPos.Count - 1) : Random.Range(3, spawnPos.Count + 1);
        return jMax;
    }*/

    void SpawnWhenStart()
    {
        if (gameManager.isGameStart == true)
        {
            SpawnVehicles();
        }
    }

    void SpawnVehicles()
    {
        List<Vector3> spawnPosList = new List<Vector3>();
        //List<Vector3> spawnSection = new List<Vector3>();

        for (int i = 0; i < xPos.Length; i++)
        {
            zPos = Random.Range(120.0f, 130.0f);
            Vector3 spawnPos = new Vector3(xPos[i], yPos, zPos);
            spawnPosList.Add(spawnPos);
        }

        /*for (int j = Random.Range(0, 3); j < JMax(j, spawnPosList); j++)
        {
            int vehicleIndex = Random.Range(0, vehiclePrefab.Length);
            Instantiate(vehiclePrefab[vehicleIndex], spawnPosList[j], vehiclePrefab[vehicleIndex].transform.rotation);
        }*/

        // Get one index to be ignored from instantiated. To get 3 out of 4 vehicles at a time.
        int ignorePos = Random.Range(0, spawnPosList.Count);

        for (int k = 0; k < spawnPosList.Count; k++)
        {
            int vehicleIndex = Random.Range(0, vehiclePrefab.Length);

            if (k != ignorePos)
            {
                Instantiate(vehiclePrefab[vehicleIndex], spawnPosList[k], vehiclePrefab[vehicleIndex].transform.rotation);
                //vehicleRb = vehiclePrefab[vehicleIndex].gameObject.GetComponent<Rigidbody>();
                //vehicleRb.detectCollisions = false;
                //StartCoroutine(ActivateCollisions());
            }
        }

        Instantiate(sensor, new Vector3(0, 3.0f, 130.0f), sensor.transform.rotation);


        

        //Debug.Log($"How many counts : {spawnPosList.Count}");
        //spawnPosList.Clear();


        //float spawnXPos = Random.Range(-9.0f, 9.0f);
        //spawnXPos = RandomXPosGenerator(previousXPos);
        //spawnZPos = RandomZPosGenerator(spawnXPos, previousZPos);

        // Vector3 spawnPos = new Vector3(spawnXPos, 3.77f, 120.0f);
        //Instantiate(vehiclePrefab[vehicleIndex], spawnPos, vehiclePrefab[vehicleIndex].transform.rotation);

        //Instantiate(vehiclePrefab[vehicleIndex], new Vector3(9.0f, 3.77f, 160.0f), vehiclePrefab[vehicleIndex].transform.rotation);

        /*float[] xPosition = { Random.Range(-9.0f, -4.5f), Random.Range(-4.0f, -0.5f), Random.Range(0, 4.0f), Random.Range(4.5f, 9.0f) };
        float[] zPosition = { 120.0f, 130.0f, 140.0f, 150.0f };

        List<Vector3> spawnPos = new List<Vector3>();

        List<float> tempX = new List<float>();
        List<float> tempZ = new List<float>();
               
        foreach (float numberX in xPosition)
        {
            if (!tempX.Contains(numberX))
            {
                tempX.Add(Random.Range(xPosition[0], xPosition[xPosition.Length-1]));
            }                
        }

        foreach (float numberZ in zPosition)
        {
            if (!tempZ.Contains(numberZ))
            {
                tempZ.Add(Random.Range(zPosition[0], zPosition[zPosition.Length-1]));
            }
        }

        for (int i = 0; i < 4; i++)
        {
            spawnPos.Add(new Vector3(tempX[i], 3.77f, tempZ[i]));
        }

        foreach (Vector3 position in spawnPos)
        {
            Instantiate(vehiclePrefab[vehicleIndex], position, vehiclePrefab[vehicleIndex].transform.rotation);
        }*/



    }

    public void SpawnBuilding()
    {
        Instantiate(buildingPrefab[0], new Vector3(0, 0, 120), buildingPrefab[0].transform.rotation);
    }


    

    /*float RandomXPosGenerator(float firstSpawn)
    {
        //float firstSpawn = Random.Range(-9.0f, 9.0f);
        //float secondSpawn = 0;

        if (firstSpawn < -4.5f)
        {
            firstSpawn = Random.Range(4.5f, 9.0f);
        } 
        else if (firstSpawn >= -4.5f && firstSpawn < 0)
        {
            firstSpawn = Random.Range(0.0f, 4.5f);
        } 
        else if (firstSpawn >= 0 && firstSpawn <= 4.5f)
        {
            firstSpawn = Random.Range(-9.0f, -4.5f);
        }
        else if (firstSpawn > 4.5f)
        {
            firstSpawn = Random.Range(-4.5f, 0.0f);
        }

        previousXPos = firstSpawn;

        return previousXPos;
    }*/

    /*float RandomZPosGenerator(float firstXSpawn, float firstZSpawn)
    {
        if (firstXSpawn < 0 && firstZSpawn == 120.0f || firstXSpawn >= 0 && firstZSpawn == 120.0f)
        {
            firstZSpawn = 150.0f;
        }
        else if (firstXSpawn < 0 && firstZSpawn == 150.0f || firstXSpawn >= 0 && firstZSpawn == 150.0f)
        {
            firstZSpawn = 120.0f;
        }

        previousZPos = firstZSpawn;

        return previousZPos;

    }*/


}
