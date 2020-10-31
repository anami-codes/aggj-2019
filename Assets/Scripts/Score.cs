using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public static int score;
    public Text scoreText;
    public Text endText;

    private bool showingWin;
    private float timer;
    private float winTimer;
    
	public void Initialize () {
        score = 0;
        WriteScore();
        timer = Time.time + 1f;
        showingWin = false;
	}
	
	void Update () {
		if ((timer <= Time.time) && (Player.canMove)) {
            score += 1;
            WriteScore();
            timer = Time.time + 1f;
        }
        if ((Player.life <= 0) && (!showingWin)) WriteEndScreen();
        if ((winTimer <= Time.time) && (showingWin)) {
            endText.text = "";
            SceneManager.LoadScene(1);
        }
	}

    void WriteScore () {
        scoreText.text = score.ToString();
    }

    void WriteEndScreen () {
        showingWin = true;
        scoreText.text = "";
        endText.text = "GAME OVER\nINVADISTE " + score + " ARCHIVOS";
        winTimer = Time.time + 3f;
    }
}
