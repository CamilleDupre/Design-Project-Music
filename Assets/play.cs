using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class play : MonoBehaviour
{
    public Transform do1;
    public Transform do2;
    public Transform do3;
    public Transform re1;
    public Transform mi1;
    public Transform re2;
    public Transform do4;
    public Transform mi2;
    public Transform re3;
    public Transform re4;
    public Transform do5;


    public PressButton Dokey;
    public PressButton Rekey;
    public PressButton Mikey;
    public PressButton Fakey;
    public PressButton Solkey;
    public PressButton Lakey;
    public PressButton Sikey;
    public PressButton Dokey2;

    List<Transform> Notes = new List<Transform>();
    List<string> NotesNames = new List<string>();
    List<PressButton> keyboard = new List<PressButton>();
    List<bool> keyboard2 = new List<bool>();
    public Transform line;
    public Transform line2;

    public Transform lineBegin;


    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    string playedNote = "";
    float speed = 7f;
    bool playNote = false;


    int nbErrors = 0;
    int nbGoodNotes = 0;
    int nbMissNotes = 0;

    public GameObject musicsheet;
    public GameObject piano;
    public GameObject score;


    public GameObject good;
    public GameObject bad;
    public GameObject miss;



    // public Transform score as RectTransform;
    // Start is called before the first frame update
    void Start()
    {
        Notes.Add(do1); NotesNames.Add("Do");
        Notes.Add(do2); NotesNames.Add("Do");
        Notes.Add(do3); NotesNames.Add("Do");
        Notes.Add(re1); NotesNames.Add("Re");
        Notes.Add(mi1); NotesNames.Add("Mi");
        Notes.Add(re2); NotesNames.Add("Re");
        Notes.Add(do4); NotesNames.Add("Do");
        Notes.Add(mi2); NotesNames.Add("Mi");
        Notes.Add(re3); NotesNames.Add("Re");
        Notes.Add(re4); NotesNames.Add("Re");
        Notes.Add(do5); NotesNames.Add("Do");

        keyboard.Add(Dokey);
        keyboard.Add(Rekey);
        keyboard.Add(Mikey);
        keyboard.Add(Fakey);
        keyboard.Add(Solkey);
        keyboard.Add(Lakey);
        keyboard.Add(Sikey);
        keyboard.Add(Dokey2);

        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);
        keyboard2.Add(false);

        float volume = GameObject.Find("Data").GetComponent<DataScript>().volume;
        for (int i = 0; i < keyboard.Count; i++)
        {
            keyboard[i].GetComponent<AudioSource>().volume = volume;
        }

        speed = GameObject.Find("Data").GetComponent<DataScript>().speed;

    }

    void Update()
    {
        if (Notes.Count != 0)
        {
            moveMusicSheet();
            cheekNotes();
            playedNotePiano();
            pressKeys();
        }
      else
        {
            piano.SetActive(false);
            musicsheet.SetActive(false);
            score.SetActive(true);
        }
    }

    public void pressKeys()
    {
        for (int i = 0; i < keyboard.Count; i++)
        {
            if ( keyboard2[i])
            {

                if (NotesNames[0] == playedNote)
                {
                    keyboard[i].GetComponent<Image>().color = Color.green;
                }
                else
                {
                    keyboard[i].GetComponent<Image>().color = Color.red;
                    // green for the good one 

                }
              
                if (!playNote)
                {
                    AudioSource audioSource = keyboard[i].GetComponent<AudioSource>();
                    audioSource.Play();
                    playNote = true;
                }
            }
            else
            {
                keyboard[i].GetComponent<Image>().color = Color.white;
            }

        }
    }

    

    void moveMusicSheet()
    {
       // Debug.Log(line.position.x);
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;
            // execute block of code here


            if (Notes.Count != 0 && Notes[0].position.x < line.position.x)
            {
                if (Notes[0].GetComponent<Image>().color == Color.red)
                {
                    nbErrors++;
                    bad.GetComponent<TMPro.TextMeshProUGUI>().text = "Errors : " + nbErrors;
                }

                else if (Notes[0].GetComponent<Image>().color == Color.green)
                {
                    nbGoodNotes++;
                    // score.gameObject.Width += 10;
                    // score.rect.width = 60f;
                    good.GetComponent<TMPro.TextMeshProUGUI>().text = "Good : " + nbGoodNotes;
                }

                else if (Notes[0].GetComponent<Image>().color == Color.black)
                {
                    nbMissNotes++;
                    miss.GetComponent<TMPro.TextMeshProUGUI>().text = "Miss : " + nbMissNotes;
                }
                Notes[0].gameObject.SetActive(false);
                Notes.RemoveAt(0);
                NotesNames.RemoveAt(0);

                //Debug.Log("nbErrors " + nbErrors + " nbGoodNotes " + nbGoodNotes + " nbMissNotes " + nbMissNotes);

            }


            for (int i = 0; i < Notes.Count; i++)
            {

                Vector3 pos = Notes[i].position;
                pos.x -= speed;
                Notes[i].transform.position = pos;

                if (Notes[i].position.x > lineBegin.position.x)
                {
                    Notes[i].gameObject.SetActive(false);
                }
                else
                {
                    Notes[i].gameObject.SetActive(true);

                }

            }


        }
    }

    void cheekNotes()
    {

        if (Notes.Count > 0) {
            if (Notes[0].position.x > line.position.x && Notes[0].position.x < line2.position.x)
            {
                //Debug.Log("Click");
                if(NotesNames[0] == playedNote)
                {
                    Notes[0].GetComponent<Image>().color = Color.green;
                }
                else if(playedNote != "")
                {
                    Notes[0].GetComponent<Image>().color = Color.red;
                }
            }
        }
       
       
    }

    void playedNotePiano()
    {
        if (Dokey.PublicIsPressed() || (Input.GetKey("d")))
        {
            playedNote = "Do";
            keyboard2[0] = true;

        }

        else if (Rekey.PublicIsPressed() || (Input.GetKey("f")))
        {
            playedNote = "Re";
            keyboard2[1] = true;
        }

        else if (Mikey.PublicIsPressed() || (Input.GetKey("g")))
        {
            playedNote = "Mi";
            keyboard2[2] = true;
        }

        else if (Fakey.PublicIsPressed() || (Input.GetKey("h")))
        {
            playedNote = "Fa";
            keyboard2[3] = true;
        }

        else if (Solkey.PublicIsPressed() || (Input.GetKey("j")))
        {
            playedNote = "Sol";
            keyboard2[4] = true;
        }

        else if (Lakey.PublicIsPressed() || (Input.GetKey("k")))
        {
            playedNote = "La";
            keyboard2[5] = true;
        }

        else if (Sikey.PublicIsPressed() || (Input.GetKey("l")))
        {
            playedNote = "Si";
            keyboard2[6] = true;
        }

        else if (Dokey2.PublicIsPressed() || (Input.GetKey("m")))
        {
            playedNote = "Do2";
            keyboard2[7] = true;
        }
        else if (Dokey2.PublicIsPressed() || (Input.GetKey("r")))
        {
            playedNote = "Do#";
            keyboard2[8] = true;
        }
        else if (Dokey2.PublicIsPressed() || (Input.GetKey("t")))
        {
            playedNote = "Re#";
            keyboard2[9] = true;
        }
        else if (Dokey2.PublicIsPressed() || (Input.GetKey("i")))
        {
            playedNote = "Fa#";
            keyboard2[10] = true;
        }
        else if (Dokey2.PublicIsPressed() || (Input.GetKey("o")))
        {
            playedNote = "Sol#";
            keyboard2[11] = true;
        }
        else if (Dokey2.PublicIsPressed() || (Input.GetKey("p")))
        {
            playedNote = "La#";
            keyboard2[12] = true;
        }
        else
        {
            playedNote = "";
            playNote = false;
            for (int i = 0; i < keyboard2.Count; i++)
            {
                keyboard2[i] = false;
            }
        }
    }
}
