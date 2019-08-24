using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    //LateUpdate works better with cameras, called after update() is called
    void LateUpdate()
    {//this line is saying move camera's position to player's position, at Time.deltaTime * 100
     //  gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, player.transform.position, Time.deltaTime * 100);
        gameObject.transform.position = Vector3.Lerp(gameObject.transform.position, new Vector3(0, gameObject.transform.position.y, player.gameObject.transform.position.z - 10), Time.deltaTime * 100);
    }//gameObject.transform.position is talkingabout the position of MainCamera under the Transform window on the right side in Unity
}//Lerp is just smooth transition from one position to another
