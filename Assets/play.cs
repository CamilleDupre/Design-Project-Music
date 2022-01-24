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

    List<Transform> Notes = new List<Transform>();
    List<string> NotesNames = new List<string>();

    public Transform line;

    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    string playedNote = "";
    float speed = 7f;
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
    }

    void Update()
    {
        moveMusicSheet();
        cheekNotes();
        playedNotePiano();
        speed =  GameObject.Find("Data").GetComponent<DataScript>().speed;
    }

    void moveMusicSheet()
    {
       // Debug.Log(line.position.x);
        time += Time.deltaTime;

        if (time >= interpolationPeriod)
        {
            time = time - interpolationPeriod;
            // execute block of code here

            for (int i = 0; i < Notes.Count; i++)
            {

                Vector3 pos = Notes[i].position;
                pos.x -= speed;
                Notes[i].transform.position = pos;

                if (Notes[i].position.x < 192)
                {
                    Notes[i].gameObject.SetActive(false);
                    Notes.RemoveAt(i);
                    NotesNames.RemoveAt(i);
                    i--;

                }
                else if (Notes[i].position.x > 593)
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
            if (Notes[0].position.x > 192 && Notes[0].position.x < 215)
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
        if (Dokey.PublicIsPressed())
        {
            playedNote = "Do";
        }

        else if (Rekey.PublicIsPressed())
        {
            playedNote = "Re";
        }

        else if (Mikey.PublicIsPressed())
        {
            playedNote = "Mi";
        }

        else if (Fakey.PublicIsPressed())
        {
            playedNote = "Fa";
        }

        else if (Solkey.PublicIsPressed())
        {
            playedNote = "Sol";
        }

        else if (Lakey.PublicIsPressed())
        {
            playedNote = "La";
        }

        else if (Sikey.PublicIsPressed())
        {
            playedNote = "Si";
        }
        else
        {
            playedNote = "";
        }
    }
}
