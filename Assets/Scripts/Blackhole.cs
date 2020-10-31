using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour {

    public int life = 5;

    private Animator anim;

    void Start() {
        anim = GetComponent<Animator>();
    }

    public void Damage() {
        life--;
        if (life <= 0) anim.SetBool("active", false);
    }

    public void TurnOff() {
        gameObject.SetActive(false);
    }
}
