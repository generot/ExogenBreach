using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamMovement : MonoBehaviour
{
    public Transform player;

    //float speed = .3f;

    void Update()
    {
        Vector3 prevPos = transform.position,
        playerPos = new Vector3(player.position.x + 2f, player.position.y, prevPos.z),
        velocity = GetComponent<Camera>().velocity;
        
        //transform.position = Vector3.Lerp(prevPos, playerPos, Time.deltaTime * speed);
        //transform.position = Vector3.SmoothDamp(prevPos, playerPos, ref velocity, speed);

        //I tried smoothing it, but it gets sharper than a fcking needle
        Vector3 pos = new Vector3(playerPos.x, playerPos.y, transform.position.z);
        transform.position = pos;
    }
}
