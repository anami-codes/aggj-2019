using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour {

    public GameObject mainMenu;

    public void Close () {
        mainMenu.SetActive(true);
        mainMenu.GetComponent<MenuManager>().Start();
        gameObject.SetActive(false);
    }
}
