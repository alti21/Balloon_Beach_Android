using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject sceneManager;
    public float playerSpeed = 500;
    public float directionalSpeed = 20;//moving left/right speed
    public AudioClip scoreUp;
    public AudioClip damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerSpeed < 11900 && Input.touchCount > 0)
            playerSpeed = playerSpeed + 1;
//#if UNITY_EDITION || UNITY_STANDALONE || UNITY_WEBPLAYER
        float moveHorizontal = Input.GetAxis("Horizontal");//pressing right arrow results in value of 1, left -1, Input gets input from keyboard, move object let and right
        transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(Mathf.Clamp(gameObject.transform.position.x + moveHorizontal, -2.1f, 2.1f), gameObject.transform.position.y, gameObject.transform.position.z), directionalSpeed * Time.deltaTime);
        //lerp means to move smoothly from one position to another
        //first position it moves from is the current position, gameObject.transform.position
        //move to a new position, new Vector3(x position is clamped btwn -2.5 and 2.5, y position is gameObject.transform.position.y, z position is gameObject.transform.position.z)
        //this is then multiplied by directionalSpeed * Time.deltaTime
//#endif
        GetComponent<Rigidbody>().velocity = Vector3.forward * playerSpeed * Time.deltaTime;
        //Vector3.forward is a direction, 1000 is the speed, time.deltaTime is the time passed since the last frame, use this if you want object 
        //to move at constant velocity, for consistent results
        transform.Rotate(Vector3.right * GetComponent<Rigidbody>().velocity.z / 3);
        //mobile controls
        Vector2 touch = Camera.main.ScreenToWorldPoint(Input.mousePosition + new Vector3(0, 0, 10f));
        //above gets where we touch on the screen
        if (Input.touchCount > 0)//if there is a touch on the screen
        {
            transform.position = new Vector3(touch.x, transform.position.y, transform.position.z);//we only need to move the ball left and right
        }//so only change x position, y and z dont need to change
    }


    void OnTriggerEnter(Collider other)
    {
     
        if (other.gameObject.tag == "scoreup")//gaps are tagged with "scoreup" in Unity
        {
          //  GetComponent<AudioSource>().PlayOneShot(scoreUp, 1.0f);
        }
        if (other.gameObject.tag == "traingle")
        {
           // GetComponent<AudioSource>().PlayOneShot(damage, 1.0f);
            sceneManager.GetComponent<App_Initialize>().GameOver();

        }
    }
}
