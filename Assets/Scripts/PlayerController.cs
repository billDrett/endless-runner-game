using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] ParticleSystem explosionParticle;
    [SerializeField] ParticleSystem runningParticle;

    [SerializeField] float jumpForce = 10;
    [SerializeField] float gravityModifier = 1;

    [SerializeField] AudioClip crashSound;
    [SerializeField] AudioClip jumpSound;

    bool isOnGround = true;
   public bool isGameover = false;

    Rigidbody plRigidbody;
    Animator animator;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Update values for gravity");
        plRigidbody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        Physics.gravity *= gravityModifier;
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameover) return;
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            plRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            animator.SetTrigger("Jump_trig");
            runningParticle.Stop();
            audioSource.PlayOneShot(jumpSound, 0.8f);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            runningParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("GameOVer!");

            isGameover = true;

            animator.SetBool("Death_b", true);
            animator.SetInteger("DeathType_int", 1);

            runningParticle.Stop();
            explosionParticle.Play();

            audioSource.PlayOneShot(crashSound, 0.8f);
        }
    }

}
