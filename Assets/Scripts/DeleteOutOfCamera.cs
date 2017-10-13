using UnityEngine;

public class DeleteOutOfCamera : MonoBehaviour {

	private const int screenOffset = -1;
	private SpriteRenderer spriteRenderer;

	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer> ();
	}

	public void Update() {		
		if (IsOutOfScreen())
			Destroy (gameObject);
	}

	bool IsOutOfScreen() {
		Vector3 cameraLeftBottom = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.nearClipPlane));

		return (transform.position.x - cameraLeftBottom.x + spriteRenderer.size.x / 2 < screenOffset);
	}
}

