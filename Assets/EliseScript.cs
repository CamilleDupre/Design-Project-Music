using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EliseScript : MonoBehaviour
{
    float timeSpend = 0.0f;
    int nbErrors = 0;
    public TextMeshProUGUI time;
    public TextMeshProUGUI errors;

    bool timing = false;


    void Update()
    {
        if (timing) {
            timeSpend += Time.deltaTime;
        }
        time.text = "Time : " + timeSpend;
    }

    public void Startsound()
    {
        timeSpend = 0.0f;
        nbErrors = 0;
        timing = true;
        time.text = "Time : ";
        errors.text = "Errors : 0";
    }

    public void PressPiano()
    {
        //Debug.Log("WIN !!!");
        timing = false;
    }

    public void incErrors()
    {
        nbErrors= nbErrors + 1;
        errors.text = "Errors : " + nbErrors;
    }
}
