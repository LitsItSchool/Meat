using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var x = Physics2D.OverlapCircleAll(transform.position, 5);
            for (int i = 0; i < x.Length; i++)
            {
                if (x[i].tag == "Finish")
                {
                   x[i].GetComponent<Rigidbody2D>().AddForce((x[i].transform.position - transform.position)*1000);
                    x[i].GetComponent<Rigidbody2D>().AddTorque(180f);

                }
            }
            
        }
	}
}
