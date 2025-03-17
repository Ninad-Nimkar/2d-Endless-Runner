using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRB;
    public float jumpforce = 10;
    public float gravitymodifier;
    public bool isonground = true;
    public bool gameover;
    private Animator playeranim;
    public ParticleSystem explosionparticle;
    public ParticleSystem dirtsplatter;
    public AudioClip jumpsfx;
    public AudioClip crashsfx;
    private AudioSource playeraudio;

    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();

        playeraudio = GetComponent<AudioSource>(); 

        Physics.gravity *= gravitymodifier;

        playeranim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isonground && !gameover)
        {
           playerRB.AddForce(Vector2.up * jumpforce, ForceMode.Impulse);
            isonground = false;

            playeranim.SetTrigger("Jump_trig");
            dirtsplatter.Stop();
            playeraudio.PlayOneShot(jumpsfx, 1.0f);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isonground = true;
            dirtsplatter.Play();

        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {

            Debug.Log("Game Over");
            gameover = true;

            playeranim.SetBool("Death_b", true);
            playeranim.SetInteger("DeathType_int", 1);
            explosionparticle.Play();
            dirtsplatter.Stop();
            playeraudio.PlayOneShot(crashsfx, 1.0f);
        
        
        
        }


        
       
       
    }
}
