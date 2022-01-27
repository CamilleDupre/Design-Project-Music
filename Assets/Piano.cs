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
        Notes.Add(donote2); keyboard.Add(Dokey2);

        Notes.Add(donote); keyboard.Add(Dodkey);
        Notes.Add(re); keyboard.Add(Redkey);
        Notes.Add(fa); keyboard.Add(Fadkey);
        Notes.Add(sol); keyboard.Add(Solskey);
        Notes.Add(la); keyboard.Add(Ladkey);

    }

    void Update()
    {
        pressKeys();
    }

    public void pressKeys()
    {
        bool nothingPress = true;
        for (int i = 0; i < keyboard.Count; i++)
        {
            if (keyboard[i].PublicIsPressed())
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

}
