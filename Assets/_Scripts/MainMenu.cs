using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour {

	// Do not set these via Editor, use methods below
	public GameObject curPanel;
	public GameObject prevPanel;

	// Use this for initialization
	void Start () {
		// Play background video/scene
		// Play animations
		// Play music
		//GameObject.Find("PanelSMBattles").SetActive(false);
		//GameObject.Find("PanelSMOptions").SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void openPanel(GameObject p) {
		if (curPanel != null) curPanel.SetActive (false);
		prevPanel = curPanel;
		curPanel = p;
		curPanel.SetActive (true);
	}

	public void closeCurrentPanel() {
		if (curPanel != null) curPanel.SetActive (false);
	}

	public void returnPrevPanel() {
		if (curPanel != null) curPanel.SetActive (false);
		if (prevPanel != null) {
			curPanel = prevPanel;
			curPanel.SetActive (true);
		}
	}

	public void QuitGame () {
		// Stop background video/scene
		// Stop animations
		// Stop music
	#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
	#else
			Application.Quit();
	#endif
	}
}
