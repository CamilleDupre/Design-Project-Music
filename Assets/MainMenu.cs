using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public Slider sliderval;
    public GameObject data;


    public void Start()
    {
        data.GetComponent<DataScript>().ChangeVolume(sliderval.value);
        data.GetComponent<DataScript>().NormalSpeed();
    }

    void Update()
    {
        data = GameObject.Find("Data");
        foreach (KeyCode vKey in System.Enum.GetValues(typeof(KeyCode)))
        {
            if (Input.GetKey(vKey))
            {
                //your code here
               // Debug.Log("vKey : " + vKey);

            }
        }
    }

    public void OnValueChanged(float newValue)
    {
        data.GetComponent<DataScript>().ChangeVolume(sliderval.value);
    }

    public void NormalMode()
    {
        data.GetComponent<DataScript>().NormalSpeed();
    }

    public void SlowMode()
    {
        data.GetComponent<DataScript>().SlowSpeed();
    }

    public void EasyMode()
    {
        data.GetComponent<DataScript>().EasyMode();
    }

    public void HardSpeed()
    {
        data.GetComponent<DataScript>().HardSpeed();
    }

    public void PlayGame()
    {
       // SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(2);
    }

    public void PracticeGame()
    {
        SceneManager.LoadScene(3);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
