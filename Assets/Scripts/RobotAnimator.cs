using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotAnimator : MonoBehaviour
{
    public Animator wheelAnimator;
    public ParticleSystem particleEffect;
    public AudioSource smokeAudioSource;
    public AudioSource wheelAudioSource;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) // Replace with your input condition
        {
            // Play the animation
            animator.ResetTrigger("returnToIdle");
            wheelAnimator.ResetTrigger("returnToIdle");
            animator.SetTrigger("Raising_Arm_Animation");
            wheelAnimator.SetTrigger("StartTwisting");
        }
    }

    void OnStartTwisting()
    {
        animator.ResetTrigger("Raising_Arm_Animation");
        wheelAnimator.ResetTrigger("StartTwisting");
        wheelAudioSource.Play();
    }

    void OnTwistFinish()
    {
        // Stop the particle effect
        if (particleEffect.isPlaying)
            particleEffect.Stop();

        // Stop the audio source
        if (smokeAudioSource.isPlaying)
            smokeAudioSource.Stop();

        // Return this animator to the idle state
        animator.SetTrigger("returnToIdle");

        // Return the other animator to the idle state
        wheelAnimator.SetTrigger("returnToIdle");
    }
}
