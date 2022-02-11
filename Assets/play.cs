using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public PressButton Dodkey;
    public PressButton Redkey;
    public PressButton Fadkey;
    public PressButton Solskey;
    public PressButton Ladkey;

    public Slider progress;

    List<Transform> Notes = new List<Transform>();
    List<string> NotesNames = new List<string>();
    List<PressButton> keyboard = new List<PressButton>();
    List<bool> keyboard2 = new List<bool>();
    public Transform lineLate;
    public Transform lineGood1;
    public Transform lineGood2;
    public Transform lineEarly;

    public Transform lineBegin;
    public OSC osc;
    float note;
    float veloc;

    private float time = 0.0f;
    public float interpolationPeriod = 0.1f;
    string playedNote = "";
    float speed = 7f;
    bool easy;
    bool playNote = false;


    int nbErrors = 0;
    int nbGoodNotes = 0;
    int nbMissNotes = 0;
    int nbWrongTempo = 0;

    public GameObject musicsheet;
    public GameObject piano;
    public GameObject score;


    public GameObject good;
    public GameObject bad;
    public GameObject miss;
    public GameObject WrongTempo;

    public GameObject scoreNumber;

    public GameObject FeedBack;
    bool feedBackBool;
    int feedBackCombo = 0;

    int nbNotesSong;

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

        keyboard.Add(Dodkey);
        keyboard.Add(Redkey);
        keyboard.Add(Fadkey);
        keyboard.Add(Solskey);
        keyboard.Add(Ladkey);

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

        nbNotesSong = Notes.Count;

        float volume = GameObject.Find("Data").GetComponent<DataScript>().volume;
        for (int i = 0; i < keyboard.Count; i++)
        {
            keyboard[i].GetComponent<AudioSource>().volume = volume;
        }

        speed = GameObject.Find("Data").GetComponent<DataScript>().speed;
        easy = GameObject.Find("Data").GetComponent<DataScript>().easy;

    }

    void Update()
    {
        Debug.Log(feedBackCombo);
        if (Notes.Count != 0)
        {
            moveMusicSheet();
            cheekNotes();
            playedNotePiano();
            pressKeys();
            note = osc.GetComponent<OSCrecived>().Note;
            veloc = osc.GetComponent<OSCrecived>().Veloc;
        }
      else
        {
            piano.SetActive(false);
            musicsheet.SetActive(false);
            score.SetActive(true);
            progress.gameObject.SetActive(false);
            int s = nbGoodNotes * 100 + nbMissNotes * 0 + nbErrors * (-50) + nbWrongTempo * 50;
            if (s <= 0)
            {
                s = 0;
            }
            scoreNumber.GetComponent<TMPro.TextMeshProUGUI>().text = "Score : " + s;
            
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
            if (Notes.Count != 0 && Notes[0].position.x < lineLate.position.x)
            {
                if (Notes[0].GetComponent<Image>().color == Color.red)
                {
                    nbErrors++;
                    bad.GetComponent<TMPro.TextMeshProUGUI>().text = "Errors : " + nbErrors;
                }

                else if (Notes[0].GetComponent<Image>().color == Color.green)
                {
                    nbGoodNotes++;
                    good.GetComponent<TMPro.TextMeshProUGUI>().text = "Good : " + nbGoodNotes;
                    feedBackCombo++;
                }
                else if (Notes[0].GetComponent<Image>().color == Color.yellow)
                {
                    nbWrongTempo++;
                    WrongTempo.GetComponent<TMPro.TextMeshProUGUI>().text = "Wrong tempo : " + nbWrongTempo;
                }

                else if (Notes[0].GetComponent<Image>().color == Color.black)
                {
                    nbMissNotes++;
                    miss.GetComponent<TMPro.TextMeshProUGUI>().text = "Miss : " + nbMissNotes;
                    FeedBack.GetComponent<TMPro.TextMeshProUGUI>().text = "Miss";
                    if (!feedBackBool)
                    {
                        StartCoroutine(feedBack("Miss"));
                        feedBackBool = true;
                        feedBackCombo = 0;
                    }
                    
                }
                Notes[0].gameObject.SetActive(false);
                Notes.RemoveAt(0);
                NotesNames.RemoveAt(0);
                progress.value += 1f/ nbNotesSong;

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
                    if (easy)
                    {
                        Notes[i].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }
    }

    void cheekNotes()
    {

        if (Notes.Count > 0) {

            if (Notes[0].position.x > lineLate.position.x && Notes[0].position.x < lineGood2.position.x)
            {
                Debug.Log("Late");
                if (NotesNames[0] == playedNote)
                {
                    Notes[0].GetComponent<Image>().color = Color.yellow;
                    Notes[0].transform.Find("line").GetComponent<Image>().color = Color.yellow;
                    if (!feedBackBool)
                    {
                        feedBackBool = true;
                        StartCoroutine(feedBack("Late"));
                        feedBackCombo = 0;

                    }
                }
                else if (playedNote != "")
                {
                    Notes[0].GetComponent<Image>().color = Color.red;
                    Notes[0].transform.Find("line").GetComponent<Image>().color = Color.red;
                    if (!feedBackBool)
                    {
                        StartCoroutine(feedBack("Wrong"));
                        feedBackBool = true;
                        feedBackCombo = 0;
                    }
                }
            }
            if (Notes[0].position.x > lineGood2.position.x && Notes[0].position.x < lineGood1.position.x)
            {
                //Debug.Log("Click");
                if(NotesNames[0] == playedNote)
                {
                    Notes[0].GetComponent<Image>().color = Color.green;
                    Notes[0].transform.Find("line").GetComponent<Image>().color = Color.green;
                    if (!feedBackBool)
                    {
                        feedBackBool = true;
                        if (feedBackCombo >= 3)
                        {
                          StartCoroutine(feedBack("Combo X" + feedBackCombo));
                        }
                        else
                        {
                          StartCoroutine(feedBack("Good"));
                        }
                    }
                }
                else if(playedNote != "")
                {
                    Notes[0].GetComponent<Image>().color = Color.red;
                    Notes[0].transform.Find("line").GetComponent<Image>().color = Color.red;
                    if (!feedBackBool)
                    {
                        StartCoroutine(feedBack("Wrong"));
                        feedBackBool = true;
                        feedBackCombo = 0;
                    }
                }
            }

            if (Notes[0].position.x > lineGood1.position.x && Notes[0].position.x < lineEarly.position.x)
            {
                Debug.Log("Early");
                if (NotesNames[0] == playedNote)
                {
                    Notes[0].GetComponent<Image>().color = Color.yellow;
                    Notes[0].transform.Find("line").GetComponent<Image>().color = Color.yellow;
                    if (!feedBackBool)
                    {
                        feedBackBool = true;
                        StartCoroutine(feedBack("Early"));
                        feedBackCombo = 0;

                    }
                }
                else if (playedNote != "")
                {
                    Notes[0].GetComponent<Image>().color = Color.red;
                    Notes[0].transform.Find("line").GetComponent<Image>().color = Color.red;
                    if (!feedBackBool)
                    {
                        StartCoroutine(feedBack("Wrong"));
                        feedBackBool = true;
                        feedBackCombo = 0;
                    }
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
            playNote = false;
            for (int i = 0; i < keyboard2.Count; i++)
            {
                keyboard2[i] = false;
            }
        }
    }

   public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator feedBack(string fb)
    {
        FeedBack.GetComponent<TMPro.TextMeshProUGUI>().text = fb;
        yield return new WaitForSeconds(0.5f);
        FeedBack.GetComponent<TMPro.TextMeshProUGUI>().text = "";
        feedBackBool = false;

    }
}

