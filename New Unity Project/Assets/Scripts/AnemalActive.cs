using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnemalActive : MonoBehaviour {


    int FingerCount = 0;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                FingerCount++;
            if (FingerCount >= 0)
                print("User has"+FingerCount+"fingers touching the screen");
        }
    }

    void OnGUI()
    {

        GUI.Box(new Rect(400, 5, 200, 50), "show me" + FingerCount);
    }
}
