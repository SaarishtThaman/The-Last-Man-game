using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

    public Transform[] spawns;
    public GameObject[] interactibles;
    public AudioClip ambient;
    AudioSource ausr;
    public bool isSpecial, isTextBased;
    public string[] sequence;
    GameObject gm;
    GameManager gms;
    public GameObject dialogbox, dialogGO, spaceBar;
    Text dialog;
    int seqIndex = 0;

    void Start() {
        gm = GameObject.FindWithTag("GameManager");
        gms = gm.GetComponent<GameManager>();
        ausr = GetComponent<AudioSource>();
        ausr.clip = ambient;
        ausr.Play();
        dialogbox = gms.dialogBox;
        dialogGO = gms.dialog;
        spaceBar = gms.spaceBar;
        dialog = dialogGO.GetComponent<Text>();
        if(isTextBased) {
            dialog.fontSize = 15;
            dialogbox.SetActive(true);
            spaceBar.SetActive(true);
        }
    }

    void Update() {
        if(isSpecial && !ausr.isPlaying && !isTextBased) {
            gms.LoadStage();
            Destroy(gameObject);
        }
        if(isTextBased && seqIndex>=sequence.Length) {
            dialogbox.SetActive(false);
            dialog.fontSize = 18;
            spaceBar.SetActive(false);
            gms.LoadStage();
            Destroy(gameObject);
        }
        if(isTextBased && Input.GetKeyDown(KeyCode.Space)) {
            seqIndex++;
        }
        if(isSpecial && isTextBased && seqIndex < sequence.Length) {
            dialog.text = sequence[seqIndex];
        }
    }

}