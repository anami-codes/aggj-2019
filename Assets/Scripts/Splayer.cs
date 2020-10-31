using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splayer : MonoBehaviour {

    public Animator splasher;
    public GameObject controls;

    float timer;
    bool check;

	void Start () {
        timer = Time.time + 2f;
	}
	
	void Update () {
		if ((timer <= Time.time) && (!check)) {
            splasher.enabled = true;
            check = true;
        }
	}

    public void ActivateControls () {
        controls.SetActive(true);
    }
}
