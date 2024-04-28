using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private float tiltAngle = 15.0f;
    private float steerForce = 50.0f;
    private float tiltAroundZ;
    private float smooth = 5.0f;
    private Vector3 movement;
    public AudioClip overtakeSound;
    public AudioClip crashSound;
    private AudioSource playerAudio;
    //private TrafficCar traffic;
    //private SpawnManager spawn;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        //traffic = GameObject.FindGameObjectWithTag("Sensor").GetComponent<TrafficCar>();
        //spawn = GetComponent<SpawnManager>();
    }

    private void FixedUpdate()
    {
        MovePlayer(movement);
    }

    // Update is called once per frame
    void Update()
    {
        tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        movement = new Vector3(tiltAroundZ, 0);

        /*if (tiltAroundZ < -10.0f || tiltAroundZ > 10.0f)
        {
            //Debug.Log("Wiaw!!");
        }*/
        /*if (transform.position.z < -30.0f)
        {
            Destroy(gameObject);
        }*/

    }


    void MovePlayer(Vector3 movement)
    {
        // Move player
        playerRb.AddForce(movement / steerForce, ForceMode.Impulse);

        // Rotate the cube by converting the angles into a quaternion.
        Quaternion target = Quaternion.Euler(0, 0, -tiltAroundZ);

        // Dampen towards the target rotation // Player rotate back to the center
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sensor") && gameManager.isGameStart == true)
        {
            Debug.Log($"Sensed !! at {gameManager.time}");
            playerAudio.PlayOneShot(overtakeSound, 0.5f);
            gameManager.score++;
            gameManager.scoreText.text = $"{gameManager.score}";
            gameManager.currentScore.text = gameManager.scoreText.text;
            Debug.Log($"The score is: {gameManager.score}");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Traffic"))
        {
            Debug.Log("Kebabom !");
            playerAudio.PlayOneShot(crashSound, 0.4f);
            gameManager.isGameActive = false;
            StartCoroutine(WaitBeforeDestroy());
            playerRb.AddForce(Vector3.back * 50.0f * Time.deltaTime);
        }
    }

    IEnumerator WaitBeforeDestroy()
    {
        yield return new WaitForSeconds(7);
        Destroy(gameObject);
    }


}
