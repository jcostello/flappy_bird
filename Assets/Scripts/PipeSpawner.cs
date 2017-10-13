using UnityEngine;

public class PipeSpawner : MonoBehaviour {

	public GameObject pipesPrefab;

	private const int screenOffset = 1;
	private const int pipesXDistance = 4;
	private const float pipesYOffset = 2.8f;

	void Awake() {
		Vector3 cameraRightBottom = GetCameraRightBottomPosition ();
		transform.position = new Vector3(cameraRightBottom.x + pipesXDistance * 1.5f, transform.position.y);
	}

	void Update () {
		if (CameraIsClose()) 
			InstanciatePipes ();	
	}

	bool CameraIsClose() {
		Vector3 cameraRightBottom = GetCameraRightBottomPosition ();
		
		return transform.position.x - cameraRightBottom.x < screenOffset;
	}

	Vector3 GetCameraRightBottomPosition() {
		return Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, Camera.main.nearClipPlane));
	}

	void InstanciatePipes() {		
		Instantiate (pipesPrefab, transform.position, Quaternion.identity);

		float randomYOffset = Random.Range (-pipesYOffset, pipesYOffset);
	
		transform.position = new Vector3 (transform.position.x + pipesXDistance, randomYOffset, 0);
	}
}
