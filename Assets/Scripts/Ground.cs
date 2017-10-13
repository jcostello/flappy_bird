using UnityEngine;

public class Ground : MonoBehaviour, IBirdCollisionable {

	public void BirdCollision(BirdHealth birdHealth) {
		SoundManager.instance.PlayHitSound();

		birdHealth.Die ();
	}
}