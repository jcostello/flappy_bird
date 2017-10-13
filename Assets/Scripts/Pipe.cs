using UnityEngine;

public class Pipe : MonoBehaviour, IBirdCollisionable {

	public void BirdCollision(BirdHealth birdHealth) {
		Physics2D.IgnoreLayerCollision (9, 10, true);

		SoundManager.instance.PlayHitSound();
		Invoke ("PlayFallSound", .5f);

		birdHealth.Fall ();
	}

	void PlayFallSound() {
		SoundManager.instance.PlayFallSound ();
	}
}
