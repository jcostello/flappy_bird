using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource audioSource;

	public AudioClip flapSound;
	public AudioClip pointSound;
	public AudioClip hitSound;
	public AudioClip fallSound;

	public static SoundManager instance = null;

	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject); return;
		}

		instance = this;

		DontDestroyOnLoad(this.gameObject);

		audioSource = GetComponent<AudioSource> ();
	}

	public void PlayPointSound() {
		audioSource.PlayOneShot (pointSound);
	}

	public void PlayFlapSound() {
		audioSource.PlayOneShot (flapSound);
	}

	public void PlayHitSound() {
		audioSource.PlayOneShot (hitSound);
	}

	public void PlayFallSound() {
		audioSource.PlayOneShot (fallSound);
	}
}
