using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraScript : MonoBehaviour {

    int dzR = 2, dzL = -2, dzU = 2, dzD = -2;
    public GameObject player;
    Vector2 playerPos;
    playerMovement pm;

    void Start() {
        pm = player.GetComponent<playerMovement>();
    }

    void Update() {
        playerPos = player.transform.position;
        if(playerPos.x-transform.position.x > dzR)
            transform.Translate(pm.speed * Time.deltaTime * 1.01f, 0, 0);
        if(playerPos.x-transform.position.x < dzL)
            transform.Translate(-pm.speed * Time.deltaTime * 1.01f, 0, 0);
        if(playerPos.y-transform.position.y > dzU)
            transform.Translate(0 , pm.speed * Time.deltaTime * 1.01f, 0);
        if(playerPos.y-transform.position.y < dzD)
            transform.Translate(0 , -pm.speed * Time.deltaTime * 1.01f, 0);
    }

}
