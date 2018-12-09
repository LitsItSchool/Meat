using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderScr : MonoBehaviour {

    public SliderJoint2D slider;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.localPosition.y > 3)
        {
            var motor = slider.motor;
            motor.motorSpeed = 1;
            slider.motor = motor;
        }
        else if (transform.localPosition.y < 0.4)
        {
            var motor = slider.motor;
            motor.motorSpeed = -1;
            slider.motor = motor;
        }


	}
}
