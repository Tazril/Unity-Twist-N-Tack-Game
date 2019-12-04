using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BallController : MonoBehaviour
{
    public GameObject particle;
    public GameObject particle1;
    public GameObject particle2;
    public AudioSource fxdiamond;
    public AudioClip fxwall;
    public AudioClip fxRed;


    [SerializeField]
    public float speed;
    
    bool started;
    bool gameOver;
    bool On;

    public Rigidbody rb;

    void Awake()
    {
      
        rb = GetComponent<Rigidbody>();
        
    }

   
    void Start()
    {
        started = false;
        gameOver = false;
        fxdiamond = GetComponent<AudioSource>();
        On = true;
       

    }

    void Update()
    {

        if ( rb.transform.position.y<0)
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -25f, 0);
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().gameOver = true;
            GameManager.instance.GameOver();
        }
        

        if (Physics.Raycast(transform.position, Vector3.down, 0.1f))
        {
            On = true;
        }

        speed += 0.04f * Time.deltaTime;
    }

    public void Run()
    {
    if (!started)
    {
        rb.velocity = new Vector3(speed, 0, 0);
        started = true;
        GameManager.instance.StartGame();
        UiManager.instance.AboutButton.SetActive(false);
        UiManager.instance.HelpButton.SetActive(false);
        UiManager.instance.JumpButton.SetActive(true);
    }

    else if (started && !gameOver)
    {
        SwitchDirection();
    }

    }


    public void JumpUp()
    {
        
        if (On)
        {
            Vector3 movement = new Vector3(0, 200, 0);
            rb.AddForce(movement * 100);
            On = false;
        }
                        
    }

   

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            
            rb.velocity = new Vector3(speed, 0, 0);            
        }
        else if (rb.velocity.x > 0)
        {

            
            rb.velocity = new Vector3(0, 0, speed);
               
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            ScoreManager.instance.IncrementScore();
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
            fxdiamond.Play();
        }

        else if (col.gameObject.tag == "Red")
        {
            for(int i = 0; i < 3; i++)
            {
                ScoreManager.instance.IncrementScore();
            }         
            GameObject part = Instantiate(particle1, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(fxRed);
        }
        else if (col.gameObject.tag == "wall")
        {
            for (int i = 0; i < 3; i++)
            {
                ScoreManager.instance.DecrementScore();
            }
            GameObject part = Instantiate(particle2, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
            AudioSource audio = GetComponent<AudioSource>();
            audio.PlayOneShot(fxwall);
        }
     

    }


 
}