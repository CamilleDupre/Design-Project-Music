using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCrecived : MonoBehaviour
{

    public OSC osc;
    public float Note;
    public float Veloc;
    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/note", OnReceiveNote);
        osc.SetAddressHandler("/veloc", OnReceiveVeloc);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(osc.messagesReceived);
    }
    void OnReceiveNote(OscMessage message)
    {
        //Debug.Log( message.GetFloat(0));
        Note = message.GetFloat(0);

    }

    void OnReceiveVeloc(OscMessage message)
    {
        //Debug.Log(message.GetFloat(0));
        Veloc = message.GetFloat(0);

    }
}
