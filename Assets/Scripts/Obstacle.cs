using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

    public float speed = 1f;
    public Vector3 direction;

    public enum MovementType {
        Right,
        Left,
        Up,
        Down,
        UpLeft,
        DownLeft,
        UpRight,
        DownRight,
    }
    public MovementType movementType;
    public bool reverse;

    private bool canMove;

    public void SetEnemyBehaviour(string name_) {
        char[] dir = name_.ToCharArray();

        List<MovementType> options = new List<MovementType>();

        if ((dir[1] == 'W') && (dir[2] == 'U')) {
            options.Add(MovementType.Down);
        } else if ((dir[1] == 'W') && (dir[2] == 'D')) {
            options.Add(MovementType.Up);
        }

        if ((dir[1] == 'H') && (dir[0] == 'R')) {
            options.Add(MovementType.Left);
        } else if ((dir[1] == 'H') && (dir[0] == 'L')) {
            options.Add(MovementType.Right);
        }

        if ((dir[0] == 'L') && (dir[2] == 'U')) {
            options.Add(MovementType.DownRight);
        } else if ((dir[1] == 'L') && (dir[2] == 'D')) {
            options.Add(MovementType.UpRight);
        } else if ((dir[1] == 'R') && (dir[2] == 'U')) {
            options.Add(MovementType.DownLeft);
        } else if ((dir[1] == 'R') && (dir[2] == 'D')) {
            options.Add(MovementType.UpLeft);
        }

        int o = Random.Range(0, options.Count);
        movementType = options[o];

        Initiate();
    }

    void Initiate () {
		switch (movementType) {
            case MovementType.Left:
                direction = Vector3.left;
                break;
            case MovementType.Right:
                direction = Vector3.right;
                break;
            case MovementType.Up:
                direction = Vector3.up;
                break;
            case MovementType.Down:
                direction = Vector3.down;
                break;
            case MovementType.UpLeft:
                direction = new Vector3(-1, 1, 0);
                break;
            case MovementType.DownLeft:
                direction = new Vector3(-1, -1, 0);
                break;
            case MovementType.UpRight:
                direction = new Vector3(1, 1, 0);
                break;
            case MovementType.DownRight:
                direction = new Vector3(1, -1, 0);
                break;
        }

        canMove = true;

        Destroy(gameObject, 10f);
	}
	
	void Update () {
        if (canMove) transform.Translate(direction * speed * Time.deltaTime);
	}
}
