using UnityEngine;

public class CameraMovement : MonoBehaviour {

	public GameObject birdGameObject;

	private Transform birdTransform;
	private Vector3 cameraOffset;

	void Awake() {
		birdTransform = birdGameObject.GetComponent<Transform>();
	}

	void Start() {
		cameraOffset = new Vector3(birdTransform.position.x, 0) - new Vector3(transform.position.x, transform.position.y);
	}

	void Update () {
		transform.position = new Vector3 (birdTransform.position.x, 0, transform.position.z) - cameraOffset;
	}

	public void UpdateTarget(GameObject gameObject) {
		birdTransform = gameObject.transform;
	}
}
