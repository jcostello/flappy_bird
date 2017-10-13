using UnityEngine;

public class BirdMovement : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private Animator animator;
	private BirdHealth birdHealth;
	private const int maxAngle = 290;
	private const int minAngle = 30;
	private const int jumpVelocity = 6;
	private const int rotateSpeed = -150;
	private const float moveSpeed = 2.5f;

	void Awake () 	{
		rigidbody = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();
		birdHealth = GetComponent<BirdHealth> ();
	}

	void Update () {				
		Rotate();
		Flap();
	}

	void Start() {
		rigidbody.velocity = new Vector2 (1, 0) * moveSpeed;
	}

	void Rotate() {
		if (CanRotate ()) {
			transform.Rotate (Vector3.forward * rotateSpeed * Time.deltaTime);
		}
	}

	void Flap() {
		if (Input.GetButtonDown("Fire1") && birdHealth.IsAlive()) {
			animator.SetTrigger ("Flap");
			SoundManager.instance.PlayFlapSound();

			rigidbody.velocity = new Vector2 (rigidbody.velocity.x, jumpVelocity);
			transform.eulerAngles = new Vector3 (0, 0, minAngle);
		}
	}

	public void Stop() {
		rigidbody.velocity = Vector2.zero;
		rigidbody.angularVelocity = 0;
	}

	bool CanRotate() {
		int zAngle = (int) transform.eulerAngles.z;
		return (rigidbody.velocity.y < 0 && (zAngle >= maxAngle || zAngle <= minAngle));
	}
}
