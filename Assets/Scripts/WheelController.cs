using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    private Rigidbody rb;

    public float turningRate = 0f;
    public float m_Speed = 0f;
    private AudioSource audioSource;

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

        Quaternion turnTorque = Quaternion.Euler(0f, turnInput * turningRate * Time.fixedDeltaTime, 0f);
        rb.MoveRotation(rb.rotation * turnTorque);


        // Check if there's significant input to play the sound
        if ((Mathf.Abs(moveInput) > 0 || Mathf.Abs(turnInput) > 0) && !audioSource.isPlaying)
        {
            audioSource.Play();
            audioSource.loop = true;
        }
        else if (Mathf.Abs(moveInput) == 0 && Mathf.Abs(turnInput) == 0 && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
