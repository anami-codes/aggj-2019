using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Avasta : MonoBehaviour {

    static public bool bh;

    public GameObject blackhole;
    public float searchTime = 1f;
    public bool isActive;

    private Animator anim;
    private float searchTimer;

    public void Start() {
        anim = GetComponent<Animator>();
    }

    public void Initilize () {
        anim.SetBool("open", true);
        isActive = true;
        searchTimer = Time.time + searchTime;
	}
	
	void Update () {
        if ((searchTimer <= Time.time) && (isActive)) EndSearch();
        if (bh) ActivateBlackhole();
	}

    public static void BlackHole () {
        bh = true;
    }

    void ActivateBlackhole () {
        if (!blackhole.activeSelf) {
            blackhole.SetActive(true);
            blackhole.GetComponent<Blackhole>().life = 5;
        }
        bh = false;
    }

    void EndSearch () {
        isActive = false;
        anim.SetBool("close", true);
    }

    public void BothAreFalse () {
        anim.SetBool("open", false);
        anim.SetBool("close", false);
    }
}
