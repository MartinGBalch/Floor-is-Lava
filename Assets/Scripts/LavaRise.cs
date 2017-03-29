using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaRise : MonoBehaviour {
    public float rise;

	// Use this for initialization
	void Start ()
    {
        rise = .5f;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
       
        transform.localScale += new Vector3(0, rise * Time.deltaTime, 0);
	}
}
