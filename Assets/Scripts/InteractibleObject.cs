using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InteractibleObject : MonoBehaviour {

    public bool playerInRange = false;
    public bool interactible = false;
    public GameObject dialogbox, dialogGO, spaceBar;
    public string s;
    GameObject gm;
    GameManager gms;
    Text dialog;
    public AudioClip dialogBoxWoosh;
    AudioSource auso;

    void Start() {
        gm = GameObject.FindWithTag("GameManager");
        gms = gm.GetComponent<GameManager>();
        dialogbox = gms.dialogBox;
        dialogGO = gms.dialog;
        spaceBar = gms.spaceBar;
        dialog = dialogGO.GetComponent<Text>();
        auso = GetComponent<AudioSource>();
        auso.clip = dialogBoxWoosh;
    }

    void Update() {
        if(playerInRange && !interactible) {
            spaceBar.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                if(dialogbox.activeInHierarchy) {
                    dialogbox.SetActive(false);
                    auso.Play();
                }
                else {
                    dialog.text = s;
                    dialogbox.SetActive(true);
                    auso.Play();
                }
            }
        }
        if(playerInRange && interactible) {
            spaceBar.SetActive(true);
            if(Input.GetKeyDown(KeyCode.Space)) {
                gms.LoadStage();
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.name == "Player") playerInRange = true;
    }

    void OnTriggerExit2D(Collider2D other) {
        if(other.gameObject.name == "Player") playerInRange = false;
        if(dialogbox.activeInHierarchy) auso.Play();
        dialogbox.SetActive(false);
        spaceBar.SetActive(false);
    }

}