using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour {

	public bool moveLeft;
	public bool moveRight;
	public bool swapCharacters;
	public HeroManager heroes;
	public Movement player;
	Hero tutorialHero;
	public Text tutorialTextBox;

	// Use this for initialization
	void Start () {
		tutorialTextBox.text = "Move left by pressing and holding on the left half of the screen.";
	}
	
	// Update is called once per frame
	void Update () {
		if (player.tf.position.x <= -10) {
			moveLeft = true;
			tutorialTextBox.text = "Move right by pressing and holding on the right half of the screen.";
		}
		if (moveLeft && player.tf.position.x >= 10 && !moveRight) {
			moveRight = true;
			tutorialHero = heroes.currentHero;
			tutorialTextBox.text = "Change heroes by clicking on your hero then choosing a new one from the menu.";
		}
		if (moveRight && heroes.currentHero != tutorialHero && !swapCharacters) {
			tutorialTextBox.text = "Tutorial Complete!";
			Destroy (tutorialTextBox, 5);
			Destroy (this.gameObject);
		}
	}
}
