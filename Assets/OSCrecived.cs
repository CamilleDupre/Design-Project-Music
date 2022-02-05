using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OSCrecived : MonoBehaviour
{

    public OSC osc;
    // Start is called before the first frame update
    void Start()
    {
        osc.SetAddressHandler("/note", OnReceiveXYZ);
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(osc.messagesReceived);
    }
    void OnReceiveXYZ(OscMessage message)
    {
        Debug.Log( message.GetFloat(0));

    }
}
