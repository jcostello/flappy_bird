using UnityEngine;

public class BirdHealth : MonoBehaviour {

	private bool alive = true;
	private BirdMovement birdMovement;

	void Awake() {
		birdMovement = GetComponent<BirdMovement> ();
	}

	void OnBecameInvisible () {
		Fall ();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		IBirdCollisionable colliderBehavior = coll.collider.GetComponent<IBirdCollisionable> ();

		colliderBehavior.BirdCollision (this);
	}

	void OnTriggerEnter2D(Collider2D coll) {
		GameManager.instance.AddScore ();
	}

	public void Fall() {
		birdMovement.Stop ();

		alive = false;
	}

	public void Die() {
		Fall ();

		GameManager.instance.GameOver ();

		enabled = false;
	}

	public bool IsAlive() {
		return alive;
	}
}
