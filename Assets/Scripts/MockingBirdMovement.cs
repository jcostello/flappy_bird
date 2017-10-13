using UnityEngine;

public class MockingBirdMovement : MonoBehaviour {

	private Rigidbody2D rigidbody;
	private const float moveSpeed = 2.5f;

	void Awake () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}

	void Start () {
		rigidbody.velocity = new Vector2 (1, 0) * moveSpeed;
	}
}
