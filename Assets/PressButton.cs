using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PressButton : Button
 {
        public bool PublicIsPressed()
        {
            return base.IsPressed();
        }

    void Update()
    {
    }
}
    
