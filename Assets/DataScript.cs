using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataScript : MonoBehaviour
{

    public float volume;
    public float speed;
    bool alreadyCreated = false;
    // Start is called before the first frame update

    private static DataScript instance = null;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
            return;
        }
        Destroy(this.gameObject);
    }
    void Start()
    {
        if (!alreadyCreated) {
            DontDestroyOnLoad(this.gameObject);
            alreadyCreated = true;
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeVolume(float newVolume)
    {
        volume = newVolume;
    }

    public void NormalSpeed()
    {
        speed = 7f;
    }

    public void SlowSpeed()
    {
        speed = 3f;
    }
}
