using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stalker : MonoBehaviour {

    public float speed;

    private Vector3 direction;

	void Update () {

        direction = Player.player.position - transform.position;
        direction.Normalize();

        float rot_z = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
