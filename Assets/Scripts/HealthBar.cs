using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    private SpriteRenderer sr;
    private int currentLife;
    private float sizeChange;
    private float moveChange;
	
	void Start () {
        sr = GetComponent<SpriteRenderer>();
        currentLife = Player.life;
        sizeChange = sr.size.x/currentLife;
        moveChange = 0.29f;
	}


    void Update() {
        if (Player.life != currentLife) UpdateHealthBar();
    }

    void UpdateHealthBar () {
        if (Player.life > 0) {
            Vector3 temp = sr.size;
            temp.x -= sizeChange;
            sr.size = temp;
            temp = transform.position;
            temp.x -= moveChange;
            transform.position = temp;
            currentLife = Player.life;
        } else {
            sr.size = Vector3.zero;
        }
    }
}
