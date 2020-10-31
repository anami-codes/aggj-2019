using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

    public Image[] images;
    public Color[] colors;

    public Spawner spawner;
    public Player player;
    public GameObject healthBar;
    public GameObject credits;
    public Score score;
    public AudioSource music;

    private int currentIndex;
    private float v;
    private float timer;

	public void Start () {
        music.pitch = 1f;
        currentIndex = 0;
        ChangeOption(0);
	}
	
	void Update () {
        v = Input.GetAxisRaw("Vertical");

        if ((v == -1) && (timer <= Time.time)) {
            ChangeOption(1);
            timer = Time.time + 0.25f;
        } else if ((v == 1) && (timer <= Time.time)) {
            timer = Time.time + 0.25f;
            ChangeOption(-1);
        }

        if (Input.GetButtonDown("Jump")) SelectOption();

	}

    void ChangeOption (int next) {
        if (currentIndex + next < 0)
            currentIndex = 0;
        else if (currentIndex + next >= images.Length)
            currentIndex = images.Length - 1;
        else
            currentIndex += next;

        for (int i = 0; i < images.Length; i++) {
            if (i == currentIndex)
                images[i].color = colors[1];
            else
                images[i].color = colors[0];
        }

    }

    void SelectOption() {
        images[currentIndex].color = colors[2];

        switch (images[currentIndex].name) {
            case "Play":
                spawner.Initialize();
                player.Initialize();
                score.Initialize();
                healthBar.SetActive(true);
                music.pitch = 1.5f;
                gameObject.SetActive(false);
                break;
            case "Credits":
                credits.SetActive(true);
                gameObject.SetActive(false);
                break;
            case "Exit":
                Application.Quit();
                break;
        }
    }
}
