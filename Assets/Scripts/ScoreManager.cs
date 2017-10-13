using UnityEngine;

public class ScoreManager : MonoBehaviour {

	public static ScoreManager instance = null;
	private int score = 0;
	private int hiScore = 0;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(gameObject); return;
		}

		instance = this;

		DontDestroyOnLoad(gameObject);
	}
	
	// Update is called once per frame
	public void AddScore() {
		score += 1;	
	}

	public void ResetScore() {
		score = 0;
	}

	public int GetScore() {
		return score;
	}

	public bool NewHiScore() {
		return score > hiScore;
	}

	public int GetHiScore() {
		if (NewHiScore())
			hiScore = score;

		return hiScore;
	}
}
