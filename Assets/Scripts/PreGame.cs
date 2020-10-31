using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PreGame : MonoBehaviour {

    private bool passing;

    void Update() {
        if (Input.GetButton("Jump")) {
            GetComponent<Animator>().SetBool("pass", true);
            passing = true;
        }
    }

    public void NextLevel () {
        SceneManager.LoadScene(1);
    }

}
