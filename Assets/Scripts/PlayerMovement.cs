using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour {

    public float speed = 5;

    public AudioSource death;
    public AudioSource Win;

    public float killYLevel = -100;

    public bool Winbool = false;

    private bool jump;
    private float doubleJump;

    float lavaTimer = 0;
    public float lavaDeathTime = .25f;

    GameObject Dead;
    public bool paused;
    public float killTime = 1;

    public float winTime = .5f;
    // private Animator anim;

    private Vector3 startpoint;
	// Use this for initialization
	void Start ()
    {
        startpoint = transform.position;
        jump = true;
        doubleJump = 2;

        paused = false;
        Dead = GameObject.Find("Game Over");

        Cursor.visible = false;


        //  anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        death.GetComponent<AudioSource>();
        lavaTimer -= Time.deltaTime;
        killTime -= Time.deltaTime;
        if (lavaTimer/4 > lavaDeathTime)
        {
           
            killTime = 2;
            if (killTime < 0)
            {
                paused = true;
                Cursor.visible = true;
            }
           
        }

        if (Winbool == true)
        {
            winTime -= Time.deltaTime;
        }
        if (winTime <= 0)
        {
            SceneManager.LoadScene("WinLevel");
        }

        if (transform.position.y < killYLevel)
        {
            Respawn();
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(speed * horizontal * Time.deltaTime, 0f, speed * vertical * Time.deltaTime);
        

        Rigidbody rbody = GetComponent<Rigidbody>();


        if (jump)
        {
            
            if (Input.GetButtonDown("Jump") && (doubleJump >= 1))
            {
                doubleJump--;
                rbody.AddForce(Vector3.up * 7, ForceMode.Impulse);
            }
            if (doubleJump <= 0)
            {
                jump = false;
            }
        }
        if (paused)
        {
            Dead.SetActive(true);
            Time.timeScale = 0;
        }
        else if(!paused)
        {
            Dead.SetActive(false);
            Time.timeScale = 1;
        }
       
        
	}

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Lava"))
        {
            death.Play();
            lavaTimer += Time.fixedDeltaTime * 5;
            
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            jump = true;
            doubleJump = 2;
            //anim.SetBool("Jump", jump);
        }
        if(other.gameObject.CompareTag("Lava"))
        {
            death.Play();
            paused = true;
            Cursor.visible = true;
        }
        if (other.gameObject.CompareTag("Win"))
        {
            Winbool = true;
            Win.Play();
           
        }
    }

    public void Respawn()
    {
        transform.position = startpoint;
    }

    public void setRespawnPoint(Vector3 respawmLocation)
    {
        startpoint = respawmLocation;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level");
    }
    public void End()
    {
        Application.Quit();
    }
}
