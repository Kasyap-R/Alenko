using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private Rigidbody rb;

    public float turningRate = 0f;
    public float m_Speed = 0f;

    private AudioSource audioSource;

    // Sound effects
    public AudioClip robotStart;
    public AudioClip robotMove;
    public AudioClip robotStop;

    private bool isMoving = false;
    private bool stopSoundPlayed = false;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = new Vector3(0, -1f, 0);
        audioSource = GetComponentInChildren<AudioSource>();
    }

    private void FixedUpdate()
    {
        float moveInput = Input.GetAxis("Vertical");
        float turnInput = Input.GetAxis("Horizontal");

        Vector3 movement = transform.forward * moveInput * Time.deltaTime * m_Speed;
        rb.MovePosition(transform.position + movement);

        Quaternion turn = Quaternion.Euler(0f, turnInput * turningRate * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turn);

        // Determine the state of movement
        if (Mathf.Abs(moveInput) > 0 || Mathf.Abs(turnInput) > 0)
        {
            if (!isMoving)
            {
                // Robot starts moving
                stopSoundPlayed = false;
                audioSource.clip = robotStart;
                audioSource.Play();
                audioSource.loop = false; // Start sound should not loop
            }
            else if (audioSource.clip != robotMove && !audioSource.isPlaying)
            {
                // Switch to moving sound after start sound has finished
                audioSource.clip = robotMove;
                audioSource.Play();
                audioSource.loop = true; // Move sound should loop
            }
            isMoving = true;
        }
        else if (isMoving)
        {
            isMoving = false;
            audioSource.loop = false; // Stop Looping
        }
    }

    private void Update()
    {
        // Check if the robot has stopped moving and the move sound has finished playing
        if (!isMoving && !audioSource.isPlaying && !stopSoundPlayed)
        {
            audioSource.clip = robotStop;
            audioSource.Play();
            audioSource.loop = false;
            stopSoundPlayed = true;
        }
    }

}
