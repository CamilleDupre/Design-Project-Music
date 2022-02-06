using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Piano : MonoBehaviour
{
    public PressButton Dokey;
    public PressButton Rekey;
    public PressButton Mikey;
    public PressButton Fakey;
    public PressButton Solkey;
    public PressButton Lakey;
    public PressButton Sikey;
    public PressButton Dokey2;

    public PressButton Dodkey;
    public PressButton Redkey;
    public PressButton Fadkey;
    public PressButton Solskey;
    public PressButton Ladkey;

    List<PressButton> keyboard = new List<PressButton>();

    public Button donote ;
    public Button re ;
    public Button mi ;
    public Button fa ;    
    public Button sol ;
    public Button la ;
    public Button si ;
    public Button donote2;

    string playedNote = "";

    public OSC osc;
    float note;
    float veloc;

    List<Button> Notes = new List<Button>();
    List<bool> keyboard2 = new List<bool>();

    public Text text;

    bool play = false;

    public AudioClip Do;

    void Start()
    {
        Notes.Add(donote); keyboard.Add(Dokey);
        Notes.Add(re); keyboard.Add(Rekey);
        Notes.Add(mi); keyboard.Add(Mikey);
        Notes.Add(fa); keyboard.Add(Fakey);
        Notes.Add(sol); keyboard.Add(Solkey);
        Notes.Add(la); keyboard.Add(Lakey);
        Notes.Add(si); keyboard.Add(Sikey);
        Notes.Add(donote2); keyboard.Add(Dokey2);

        Notes.Add(donote); keyboard.Add(Dodkey);
        Notes.Add(re); keyboard.Add(Redkey);
        Notes.Add(fa); keyboard.Add(Fadkey);
        Notes.Add(sol); keyboard.Add(Solskey);
        Notes.Add(la); keyboard.Add(Ladkey);

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
    }

    void Update()
    {
        pressKeys();
        playedNotePiano();
        note = osc.GetComponent<OSCrecived>().Note;
        veloc = osc.GetComponent<OSCrecived>().Veloc;
    }

    public void pressKeys()
    {
        bool nothingPress = true;
        for (int i = 0; i < keyboard.Count; i++)
        {
            if (keyboard2[i])
            {
                nothingPress = false;
                Notes[i].GetComponent<Image>().color = Color.green;
                text.text = "Note : " + keyboard[i].name;

                if (i > 7)
                {
                    Notes[i].transform.GetChild(0).gameObject.SetActive(true);   
                }

                if (!play)
                {
                    AudioSource audioSource = keyboard[i].GetComponent<AudioSource>();
                    //audioSource.PlayOneShot(Do, 0.7F);
                    audioSource.Play();
                    play = true;
                }
            }

        }
        if (nothingPress)
        {
            for (int i = 0; i < keyboard.Count; i++)
            {
                Notes[i].GetComponent<Image>().color = Color.black;
                play = false;
                if (i > 7)
                {
                    Notes[i].transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            
        }
    }

    void playedNotePiano()
    {
        if (Dokey.PublicIsPressed() || (Input.GetKey("d")) || note == 48 & veloc != 0)
        {
            playedNote = "Do";
            keyboard2[0] = true;

        }

        else if (Rekey.PublicIsPressed() || (Input.GetKey("f")) || note == 50 & veloc != 0)
        {
            playedNote = "Re";
            keyboard2[1] = true;
        }

        else if (Mikey.PublicIsPressed() || (Input.GetKey("g")) || note == 52 & veloc != 0)
        {
            playedNote = "Mi";
            keyboard2[2] = true;
        }

        else if (Fakey.PublicIsPressed() || (Input.GetKey("h")) || note == 53 & veloc != 0)
        {
            playedNote = "Fa";
            keyboard2[3] = true;
        }

        else if (Solkey.PublicIsPressed() || (Input.GetKey("j")) || note == 55 & veloc != 0)
        {
            playedNote = "Sol";
            keyboard2[4] = true;
        }

        else if (Lakey.PublicIsPressed() || (Input.GetKey("k")) || note == 57 & veloc != 0)
        {
            playedNote = "La";
            keyboard2[5] = true;
        }

        else if (Sikey.PublicIsPressed() || (Input.GetKey("l")) || note == 59 & veloc != 0)
        {
            playedNote = "Si";
            keyboard2[6] = true;
        }

        else if (Dokey2.PublicIsPressed() || (Input.GetKey("m")) || note == 60 & veloc != 0)
        {
            playedNote = "Do2";
            keyboard2[7] = true;
        }
        else if (Dodkey.PublicIsPressed() || (Input.GetKey("r")) || note == 49 & veloc != 0)
        {
            playedNote = "Do#";
            keyboard2[8] = true;
        }
        else if (Redkey.PublicIsPressed() || (Input.GetKey("t")) || note == 51 & veloc != 0)
        {
            playedNote = "Re#";
            keyboard2[9] = true;
        }
        else if (Fadkey.PublicIsPressed() || (Input.GetKey("i")) || note == 54 & veloc != 0)
        {
            playedNote = "Fa#";
            keyboard2[10] = true;
        }
        else if (Solskey.PublicIsPressed() || (Input.GetKey("o")) || note == 56 & veloc != 0)
        {
            playedNote = "Sol#";
            keyboard2[11] = true;
        }
        else if (Ladkey.PublicIsPressed() || (Input.GetKey("p")) || note == 58 & veloc != 0)
        {
            playedNote = "La#";
            keyboard2[12] = true;
        }
        else
        {
            playedNote = "";
            play = false;
            for (int i = 0; i < keyboard2.Count; i++)
            {
                keyboard2[i] = false;
            }
        }
    }

    }
