using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public static GameManager instance = null;
	public GameObject birdPrefab;
	public GameObject mokingBird;
	public GameObject textScoreObject;
	public GameObject textActualScoreObject;
	public GameObject textHiScoreObject;
	public GameObject newHiScoreImageObject;
	public GameObject scorePanel;
	public GameObject instructionPanel;

	public GameObject pipeSpawner;

	private bool playing = false;

	private CameraMovement cameraMovement;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(gameObject); return;
		}

		instance = this;

		cameraMovement = Camera.main.GetComponent<CameraMovement>();
	}

	void Update() {
		if (Input.GetButtonDown("Fire1") && !playing) Play();
	}

	public void AddScore() {
		ScoreManager.instance.AddScore();

		Text scoreText = textScoreObject.GetComponent<Text>();
		scoreText.text = ScoreManager.instance.GetScore().ToString();

		SoundManager.instance.PlayPointSound();
	}

	public void GameOver() {
		Text actualScoreText = textActualScoreObject.GetComponent<Text>();
		Text hiScoreText = textHiScoreObject.GetComponent<Text>();
	
		if (ScoreManager.instance.NewHiScore())
			newHiScoreImageObject.SetActive (true);

		actualScoreText.text = ScoreManager.instance.GetScore().ToString();
		hiScoreText.text = ScoreManager.instance.GetHiScore().ToString();

		scorePanel.SetActive(true);
	}

	public void Play() {
		playing = true;

		pipeSpawner.SetActive(true);

		GameObject instance = Instantiate(birdPrefab, mokingBird.transform.position, mokingBird.transform.rotation) as GameObject;
		cameraMovement.UpdateTarget(instance);
		instructionPanel.SetActive(false);

		Destroy(mokingBird);
	}

	public void RePlay() {
		playing = false;

		Physics2D.IgnoreLayerCollision(9, 10, false);

		ScoreManager.instance.ResetScore();

		Application.LoadLevel(Application.loadedLevel);
	}

}
