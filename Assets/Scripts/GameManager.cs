using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public struct pair {
    public int f,s;
}

public struct leveldata {
    public bool isSpecialLevel;
    public int levelIndex,spawn,interactibleIndex;
    public string curObjective;
    public AudioClip audio;
}

public class GameManager : MonoBehaviour {

    int curIndex = -1;
    public pair[] progression;
    public GameObject[] levels;
    Dictionary<pair,leveldata> dict;
    public GameObject dialogBox, dialog, spaceBar, Player, HUD;
    public Text day,time,objective;
    public AudioClip[] audioclips;
    public Image blacked;
    AudioSource auso;
    Transform instPos;

    void Start() {
        instPos = transform;
        auso = GetComponent<AudioSource>();
        blacked.GetComponent<Image>().color = new Color32(0,0,0,0);
        Cursor.visible = false;
        progression = new pair[51];
        dict = new Dictionary<pair,leveldata>();
        //levels = new GameObject[5];
        LoadData();
    }

    IEnumerator blackFadeOut() {
        leveldata levelToLoad = dict[progression[curIndex]];
        if(levelToLoad.isSpecialLevel) {
            Player.GetComponent<playerMovement>().enabled = true;
            GameObject curlevel = Instantiate(levels[levelToLoad.levelIndex], instPos);
            blacked.GetComponent<Image>().color = new Color32(0,0,0,0);
            yield return null;
        }
        else {
            byte alpha = 255;
            while(alpha > 0) {
                blacked.GetComponent<Image>().color = new Color32(0,0,0,alpha);
                alpha -= 1;
                yield return new WaitForSeconds(0.005f);
            }
            Player.GetComponent<playerMovement>().enabled = true;
        }
    }

    IEnumerator blackFadeIn() {
        if(curIndex > -1) {
            //blacked.GetComponent<Image>().color = new Color32(0,0,0,0);
            Player.GetComponent<playerMovement>().enabled = false;
            Player.GetComponent<Animator>().SetFloat("Speed",0);
            byte alpha = 0;
            while(alpha < 255) {
                blacked.GetComponent<Image>().color = new Color32(0,0,0,alpha);
                alpha += 1;
                yield return new WaitForSeconds(0.005f);
            }
        }
        else {
            blacked.GetComponent<Image>().color = new Color32(0,0,0,255);
        }
        GameObject prev = GameObject.FindWithTag("level");
        if(prev != null) Destroy(prev);
        curIndex++;
        if(curIndex==51) {
            SceneManager.LoadScene(2);
        }
        leveldata levelToLoad = dict[progression[curIndex]];
        if(!levelToLoad.isSpecialLevel) {
            GameObject curlevel = Instantiate(levels[levelToLoad.levelIndex], instPos);
            LevelScript lvlsc = curlevel.GetComponent<LevelScript>();
            Player.transform.position = lvlsc.spawns[levelToLoad.spawn].position;
            lvlsc.interactibles[levelToLoad.interactibleIndex].GetComponent<InteractibleObject>().interactible = true;
        }
        day.text = "DAY "+progression[curIndex].f;
        time.text = progression[curIndex].s+":00";
        objective.text = levelToLoad.curObjective;

        yield return new WaitForSeconds(0.5f);

        auso.clip = levelToLoad.audio;
        auso.Play();
        yield return new WaitForSeconds(levelToLoad.audio.length);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(blackFadeOut());
    }

    public void LoadStage() {
        StartCoroutine(blackFadeIn());
    }

    void LoadData() {
        leveldata lvl = new leveldata();
        //---------------- PROGRESSION DATA ----------------
            progression[0].f = 1; progression[0].s = 6;
            progression[1].f = 1; progression[1].s = 7;
            progression[2].f = 1; progression[2].s = 8;
            progression[3].f = 1; progression[3].s = 9;
            progression[4].f = 1; progression[4].s = 10;
            progression[5].f = 1; progression[5].s = 11;
            progression[6].f = 1; progression[6].s = 12;
            progression[7].f = 1; progression[7].s = 13;
            progression[8].f = 1; progression[8].s = 14;
            progression[9].f = 1; progression[9].s = 15;
            progression[10].f = 1; progression[10].s = 16;
            progression[11].f = 1; progression[11].s = 17;
            progression[12].f = 1; progression[12].s = 18;
            progression[13].f = 1; progression[13].s = 19;
            progression[14].f = 1; progression[14].s = 20;
            progression[15].f = 1; progression[15].s = 21;
            progression[16].f = 1; progression[16].s = 22;

            progression[17].f = 2; progression[17].s = 6;
            progression[18].f = 2; progression[18].s = 7;
            progression[19].f = 2; progression[19].s = 8;
            progression[20].f = 2; progression[20].s = 9;
            progression[21].f = 2; progression[21].s = 10;
            progression[22].f = 2; progression[22].s = 11;
            progression[23].f = 2; progression[23].s = 12;
            progression[24].f = 2; progression[24].s = 13;
            progression[25].f = 2; progression[25].s = 14;
            progression[26].f = 2; progression[26].s = 15;
            progression[27].f = 2; progression[27].s = 16;
            progression[28].f = 2; progression[28].s = 17;
            progression[29].f = 2; progression[29].s = 18;
            progression[30].f = 2; progression[30].s = 19;
            progression[31].f = 2; progression[31].s = 20;
            progression[32].f = 2; progression[32].s = 21;
            progression[33].f = 2; progression[33].s = 22;

            progression[34].f = 3; progression[34].s = 6;
            progression[35].f = 3; progression[35].s = 7;
            progression[36].f = 3; progression[36].s = 8;
            progression[37].f = 3; progression[37].s = 9;
            progression[38].f = 3; progression[38].s = 10;
            progression[39].f = 3; progression[39].s = 11;
            progression[40].f = 3; progression[40].s = 12;
            progression[41].f = 3; progression[41].s = 13;
            progression[42].f = 3; progression[42].s = 14;
            progression[43].f = 3; progression[43].s = 15;
            progression[44].f = 3; progression[44].s = 16;
            progression[45].f = 3; progression[45].s = 17;
            progression[46].f = 3; progression[46].s = 18;
            progression[47].f = 3; progression[47].s = 19;
            progression[48].f = 3; progression[48].s = 20;
            progression[49].f = 3; progression[49].s = 21;
            progression[50].f = 3; progression[50].s = 22;
        //--------------------------------------------------

        //-------------------------------------- LEVEL DATA ----------------------------------------------
            //0
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 0; lvl.interactibleIndex = 6; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[0];
            dict.Add(progression[0],lvl);
            //1
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 0; lvl.interactibleIndex = 1; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[1];
            dict.Add(progression[1],lvl);
            //2
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 0; lvl.interactibleIndex = 1; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[2];
            dict.Add(progression[2],lvl);
            //3
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 1; lvl.interactibleIndex = 0; lvl.curObjective = "Take a Bath"; lvl.audio = audioclips[3];
            dict.Add(progression[3],lvl);
            //4
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 1; lvl.interactibleIndex = 0; lvl.curObjective = "Take a Bath"; lvl.audio = audioclips[2];
            dict.Add(progression[4],lvl);
            //5
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 6; lvl.interactibleIndex = 0;  lvl.curObjective = "Take a bath"; lvl.audio = audioclips[1];
            dict.Add(progression[5],lvl);
            //6
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 2; lvl.interactibleIndex = 2;  lvl.curObjective = "Eat something"; lvl.audio = audioclips[4];
            dict.Add(progression[6],lvl);
            //7
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 1; lvl.interactibleIndex = 3;  lvl.curObjective = "Watch TV"; lvl.audio = audioclips[8];
            dict.Add(progression[7],lvl);
            //8
            lvl.isSpecialLevel = true; lvl.levelIndex = 3; lvl.curObjective = ""; lvl.audio = audioclips[5];
            dict.Add(progression[8],lvl);
            //9
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 7; lvl.interactibleIndex = 6;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[6];
            dict.Add(progression[9],lvl);
            //10
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 0; lvl.interactibleIndex = 1;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[1];
            dict.Add(progression[10],lvl);
            //11
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 0; lvl.interactibleIndex = 2;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[2];
            dict.Add(progression[11],lvl);
            //12
            lvl.isSpecialLevel = false; lvl.levelIndex = 4; lvl.spawn = 0; lvl.interactibleIndex = 1;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[2];
            dict.Add(progression[12],lvl);
            //13
            lvl.isSpecialLevel = false; lvl.levelIndex = 4; lvl.spawn = 1; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[9];
            dict.Add(progression[13],lvl);
            //14
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 2; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[2];
            dict.Add(progression[14],lvl);
            //15
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 1; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[2];
            dict.Add(progression[15],lvl);
            //16
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 6; lvl.interactibleIndex = 7;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[1];
            dict.Add(progression[16],lvl);


            //0
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 0; lvl.interactibleIndex = 6; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[0];
            dict.Add(progression[17],lvl);
            //1
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 0; lvl.interactibleIndex = 1; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[1];
            dict.Add(progression[18],lvl);
            //2
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 0; lvl.interactibleIndex = 1; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[2];
            dict.Add(progression[19],lvl);
            //3
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 1; lvl.interactibleIndex = 0; lvl.curObjective = "Take a Bath"; lvl.audio = audioclips[3];
            dict.Add(progression[20],lvl);
            //4
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 1; lvl.interactibleIndex = 0; lvl.curObjective = "Take a Bath"; lvl.audio = audioclips[2];
            dict.Add(progression[21],lvl);
            //5
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 6; lvl.interactibleIndex = 0;  lvl.curObjective = "Take a bath"; lvl.audio = audioclips[1];
            dict.Add(progression[22],lvl);
            //6
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 2; lvl.interactibleIndex = 2;  lvl.curObjective = "Eat something"; lvl.audio = audioclips[4];
            dict.Add(progression[23],lvl);
            //7
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 1; lvl.interactibleIndex = 4;  lvl.curObjective = "Read a book"; lvl.audio = audioclips[8];
            dict.Add(progression[24],lvl);
            //8
            lvl.isSpecialLevel = true; lvl.levelIndex = 5; lvl.curObjective = ""; lvl.audio = audioclips[10];
            dict.Add(progression[25],lvl);
            //9
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 4; lvl.interactibleIndex = 6;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[6];
            dict.Add(progression[26],lvl);
            //10
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 0; lvl.interactibleIndex = 1;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[1];
            dict.Add(progression[27],lvl);
            //11
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 0; lvl.interactibleIndex = 2;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[2];
            dict.Add(progression[28],lvl);
            //12
            lvl.isSpecialLevel = false; lvl.levelIndex = 4; lvl.spawn = 0; lvl.interactibleIndex = 1;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[2];
            dict.Add(progression[29],lvl);
            //13
            lvl.isSpecialLevel = false; lvl.levelIndex = 4; lvl.spawn = 1; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[9];
            dict.Add(progression[30],lvl);
            //14
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 2; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[2];
            dict.Add(progression[31],lvl);
            //15
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 1; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[2];
            dict.Add(progression[32],lvl);
            //16
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 6; lvl.interactibleIndex = 7;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[1];
            dict.Add(progression[33],lvl);

            //0
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 0; lvl.interactibleIndex = 6; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[0];
            dict.Add(progression[34],lvl);
            //1
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 0; lvl.interactibleIndex = 1; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[1];
            dict.Add(progression[35],lvl);
            //2
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 0; lvl.interactibleIndex = 1; lvl.curObjective = "Hit the Gym"; lvl.audio = audioclips[2];
            dict.Add(progression[36],lvl);
            //3
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 1; lvl.interactibleIndex = 0; lvl.curObjective = "Take a Bath"; lvl.audio = audioclips[3];
            dict.Add(progression[37],lvl);
            //4
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 1; lvl.interactibleIndex = 0; lvl.curObjective = "Take a Bath"; lvl.audio = audioclips[2];
            dict.Add(progression[38],lvl);
            //5
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 6; lvl.interactibleIndex = 0;  lvl.curObjective = "Take a bath"; lvl.audio = audioclips[1];
            dict.Add(progression[39],lvl);
            //6
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 2; lvl.interactibleIndex = 2;  lvl.curObjective = "Eat something"; lvl.audio = audioclips[4];
            dict.Add(progression[40],lvl);
            //7
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 1; lvl.interactibleIndex = 5;  lvl.curObjective = "Browse the internet"; lvl.audio = audioclips[8];
            dict.Add(progression[41],lvl);
            //8
            lvl.isSpecialLevel = true; lvl.levelIndex = 6; lvl.curObjective = ""; lvl.audio = audioclips[5];
            dict.Add(progression[42],lvl);
            //9
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 3; lvl.interactibleIndex = 6;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[6];
            dict.Add(progression[43],lvl);
            //10
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 0; lvl.interactibleIndex = 1;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[1];
            dict.Add(progression[44],lvl);
            //11
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 0; lvl.interactibleIndex = 2;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[2];
            dict.Add(progression[45],lvl);
            //12
            lvl.isSpecialLevel = false; lvl.levelIndex = 4; lvl.spawn = 0; lvl.interactibleIndex = 1;  lvl.curObjective = "Get some food from the store"; lvl.audio = audioclips[2];
            dict.Add(progression[46],lvl);
            //13
            lvl.isSpecialLevel = false; lvl.levelIndex = 4; lvl.spawn = 1; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[9];
            dict.Add(progression[47],lvl);
            //14
            lvl.isSpecialLevel = false; lvl.levelIndex = 2; lvl.spawn = 2; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[2];
            dict.Add(progression[48],lvl);
            //15
            lvl.isSpecialLevel = false; lvl.levelIndex = 1; lvl.spawn = 1; lvl.interactibleIndex = 0;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[2];
            dict.Add(progression[49],lvl);
            //16
            lvl.isSpecialLevel = false; lvl.levelIndex = 0; lvl.spawn = 6; lvl.interactibleIndex = 7;  lvl.curObjective = "Go to bed"; lvl.audio = audioclips[1];
            dict.Add(progression[50],lvl);
        //------------------------------------------------------------------------------------------------

        LoadStage();
    }

}