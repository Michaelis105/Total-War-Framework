using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadingScreen : MonoBehaviour {

	public GameObject loadingScreenObj;
	public Slider loadingBar;

	AsyncOperation async;

	public void LoadScene(int sceneIndex) {
		StartCoroutine (LoadScreen (sceneIndex));
	}

	IEnumerator LoadScreen(int sceneIndex) {
		loadingScreenObj.SetActive(true);
		async = SceneManager.LoadSceneAsync(sceneIndex);
		while (!async.isDone) {
			loadingBar.value = async.progress;
			if (loadingBar.value == 0.9f) {
				loadingBar.value = 1f;
			}
			yield return null;
		}

	}

	/*
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	*/
}
