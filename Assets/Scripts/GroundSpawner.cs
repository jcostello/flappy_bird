using UnityEngine;

public class GroundSpawner : MonoBehaviour {

	public GameObject groundPrefab;

	private SpriteRenderer prefabRenderer;
	private const int screenOffset = 1;

	void Start () {
		prefabRenderer = groundPrefab.GetComponent<SpriteRenderer> ();
		transform.position = GetCameraLeftBottomPosition ();
	}

	void Update () {
		if (CameraIsClose()) 
			InstanciateGround ();
	}

	void InstanciateGround() {		
		Vector3 position = transform.position + new Vector3(prefabRenderer.size.x, 0, 0) / 2f;

		Instantiate (groundPrefab, position, Quaternion.identity);

		transform.position = position + new Vector3 (prefabRenderer.size.x, 0, 0) / 2f;
	}

	bool CameraIsClose() {
		Vector3 cameraRightBottom = GetCameraRightBottomPosition ();

		return transform.position.x - cameraRightBottom.x < screenOffset;
	}

	Vector3 GetCameraLeftBottomPosition() {
		return Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, Camera.main.nearClipPlane));
	}

	Vector3 GetCameraRightBottomPosition() {
		return Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, Camera.main.nearClipPlane));
	}
}
