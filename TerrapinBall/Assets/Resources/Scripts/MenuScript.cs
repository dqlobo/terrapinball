﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {

	public void playGame () {
		SceneManager.LoadScene ("MainScene");
	}
	public void mainMenu () {
		SceneManager.LoadScene ("MenuScene");
	}
}
