using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public float speed = 1f;
    public bool onUse;

    private Rigidbody2D rb;
    private Vector3 initialPos;

	void Awake () {
        initialPos = transform.position;
        rb = GetComponent<Rigidbody2D>();
	}
	
	void Update () {
		
	}

    void FixedUpdate() {
        if (onUse) rb.velocity = Vector3.right * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Vis_Obstacle")) {
            other.GetComponent<VisualObstacle>().Damage();
            transform.position = initialPos;
            onUse = false;
        }
        if (other.CompareTag("Stalker")) {
            Destroy(other.gameObject);
            transform.position = initialPos;
            onUse = false;
        }
        if (other.CompareTag("Blackhole")) {
            other.GetComponent<Blackhole>().Damage();
            transform.position = initialPos;
            onUse = false;
        }
    }
    void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.CompareTag("Limit")) {
            transform.position = initialPos;
            onUse = false;
        }
    }
}
