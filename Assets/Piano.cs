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

    List<PressButton> keyboard = new List<PressButton>();

    public Button donote ;
    public Button re ;
    public Button mi ;
    public Button fa ;    
    public Button sol ;
    public Button la ;
    public Button si ;

    List<Button> Notes = new List<Button>();

    public Text text;

    bool play = false;

    public AudioClip Do;

    void Start()
    {
        Notes.Add(donote); keyboard.Add(Dokey);
        Notes.Add(re);     keyboard.Add(Rekey);
        Notes.Add(mi);     keyboard.Add(Mikey);
        Notes.Add(fa);     keyboard.Add(Fakey);
        Notes.Add(sol);    keyboard.Add(Solkey);
        Notes.Add(la);     keyboard.Add(Lakey);
        Notes.Add(si);     keyboard.Add(Sikey);
       
    }

    void Update()
    {
        pressKeys();
       // releaseKeys();
        /*
        donote.GetComponent<Image>().color = Color.black;
        re.GetComponent<Image>().color = Color.black;
        mi.GetComponent<Image>().color = Color.black;
        fa.GetComponent<Image>().color = Color.black;
        sol.GetComponent<Image>().color = Color.black;
        la.GetComponent<Image>().color = Color.black;
        si.GetComponent<Image>().color = Color.black;
        */
        /*
        if (Dokey.PublicIsPressed())
        {
            donote.GetComponent<Image>().color = Color.green;
            text.text = "Note : DO";

            if (!play)
            {
                AudioSource audioSource = Dokey.GetComponent<AudioSource>();
                //audioSource.PlayOneShot(Do, 0.7F);
                audioSource.Play();
                play = true;
            }
        }

       else if (Rekey.PublicIsPressed())
        {
            re.GetComponent<Image>().color = Color.green;
            text.text = "Note : RE";
        }

        else if (Mikey.PublicIsPressed())
        {
            mi.GetComponent<Image>().color = Color.green;
            text.text = "Note : MI";
        }

        else if (Fakey.PublicIsPressed())
        {
            fa.GetComponent<Image>().color = Color.green;
            text.text = "Note : FA";
        }

        else if (Solkey.PublicIsPressed())
        {
            sol.GetComponent<Image>().color = Color.green;
            text.text = "Note : SOL";
        }

       else  if (Lakey.PublicIsPressed())
        {
            la.GetComponent<Image>().color = Color.green;
            text.text = "Note : LA";
        }

       else if (Sikey.PublicIsPressed())
        {
            si.GetComponent<Image>().color = Color.green;
            text.text = "Note : SI";
        }
        else
        {
            text.text = "Note :";
        }*/

    }

    public void pressKeys()
    {
        for (int i = 0; i < keyboard.Count; i++)
        {
            if (keyboard[i].PublicIsPressed())
            {
                Notes[i].GetComponent<Image>().color = Color.green;
                text.text = "Note : " + keyboard[i].name;

                if (!play)
                {
                    AudioSource audioSource = keyboard[i].GetComponent<AudioSource>();
                    //audioSource.PlayOneShot(Do, 0.7F);
                    audioSource.Play();
                    play = true;
                }
            }

        }
    }


    public void PressDo()
    {
        Debug.Log("Do");
        donote.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressRe()
    {
        Debug.Log("Re");
        re.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressMi()
    {
        Debug.Log("Mi");
        mi.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressFa()
    {
        Debug.Log("Fa");
        fa.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressSol()
    {
        Debug.Log("Sol");
        sol.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressLa()
    {
        Debug.Log("La");
        la.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressSi()
    {
        Debug.Log("Si");
        si.GetComponent<Image>().color = Color.black;
        play = false;
    }
    public void PressB1()
    {
        Debug.Log("B1");
    }
    public void PressB2()
    {
        Debug.Log("B2");
    }
    public void PressB3()
    {
        Debug.Log("B3");
    }
    public void PressB4()
    {
        Debug.Log("B4");
    }
    public void PressB5()
    {
        Debug.Log("B5");
    }
}
