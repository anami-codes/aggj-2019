using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    static public Transform player;
    static public int life = 10;

    public Transform cannon;
    public Bullet[] bullets;
    public Animator anim;

    public float speed = 1f;
    public float invTime = 1f;
    public float fireTime = 1f;

    private Rigidbody2D rb;
    private Vector3 direction;

    private float x;
    private float y;
    private float invTimer = 1f;
    private float fireTimer = 1f;
    public static bool canMove;
    private bool inv;

    void Start() {
        life = 10;
    }

    public void Initialize () {
        anim = GetComponent<Animator>();
        player = transform;
        rb = GetComponent<Rigidbody2D>();
        transform.position = new Vector3(-3, 1, 0);
        canMove = true;
    }
	

	void Update () {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        direction = new Vector3(x, y, 0);

        if ((inv) && (invTimer <= Time.time)) {
            inv = false;
            anim.SetBool("inv", false);
        }

        if ((Input.GetButtonDown("Jump")) && (fireTimer <= Time.time) && (canMove)) anim.SetBool("shoot", true);
    }

    void FixedUpdate() {
        if (canMove) rb.velocity = direction * speed;
    }

    void OnTriggerEnter2D(Collider2D other) {
        if ((other.CompareTag("Phy_Obstacle")) && (!inv)) {
            life -= 1;
            if (life <= 0) {
                canMove = false;
                anim.SetBool("dead", true);
                rb.velocity = Vector3.zero;
            }
            inv = true;
            anim.SetBool("inv", true);
            invTimer = Time.time + invTime;
        } else if (other.CompareTag("Stalker")) {
            if (!inv) Avasta.BlackHole();
            Destroy(other.gameObject);
        } else if ((other.CompareTag("Blackhole")) && (!inv)) {
            life -= 1;
            if (life <= 0) {
                canMove = false;
                anim.SetBool("dead", true);
                rb.velocity = Vector3.zero;
            }
            inv = true;;
        }
    }

    void OnTriggerStay2D(Collider2D other) {
        if ((other.CompareTag("Phy_Obstacle")) && (!inv)) {
            life -= 1;
            if (life <= 0) {
                canMove = false;
                anim.SetBool("dead", true);
                rb.velocity = Vector3.zero;
            }
            inv = true;
            anim.SetBool("inv", true);
            invTimer = Time.time + invTime;
        }
    }

    public void Shoot () {
        for (int i = 0; i < bullets.Length; i++) {
            if (!bullets[i].onUse) {
                bullets[i].transform.position = cannon.position;
                bullets[i].transform.rotation = cannon.rotation;
                bullets[i].onUse = true;
                fireTime = Time.time + fireTimer;
                anim.SetBool("shoot", false);
                return;
            }
        }
    }


}
