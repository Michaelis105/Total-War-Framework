using UnityEngine;

public class CameraController : MonoBehaviour {

	// Average terrain elevation at 600 meters.
	// Camera maximum height should be 700 meters.
	// Camera minimum height should be 2 meters.

	public float panSensitivity = 20f;
	public float rotationalSensitivity = 20f;
	public float scrollSensitivity = 200f;

	public float mousePanBorderThickness = 10f;
	public float cameraPanBorderThickness = 10f;

	public float minXBound;
	public float maxXBound;

	public float minYBound;
	public float maxYBound;

	public float minHeight = 2f;
	public float maxHeight = 300f;

	public bool invertScroll = false;
		
	// Update is called once per frame
	void Update () {

		Vector3 pos = transform.position;
		Vector3 rot = transform.rotation.eulerAngles;

		/**
		if (Input.GetKey (KeyCode.LeftShift)) {
			panSensitivity = 40f;
		}**/

		if (Input.GetKey (KeyCode.W)) {
			pos.z += panSensitivity * Time.deltaTime + Input.GetAxis("Horizontal");
			//Debug.Log (Input.GetAxis("Horizontal"));
			//pos.z += panSensitivity * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.A)) {
			pos.x -= panSensitivity * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.S)) {
			pos.z -= panSensitivity * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.D)) {
			pos.x += panSensitivity * Time.deltaTime;
		}
			
		if (Input.GetKey (KeyCode.Q) || Input.mousePosition.x <= mousePanBorderThickness) {
			rot.y -= rotationalSensitivity * Time.deltaTime;
			//pos.x += rotationalSensitivity * Time.deltaTime;
			//pos.z += rotationalSensitivity * Time.deltaTime;
		}

		if (Input.GetKey (KeyCode.E) || Input.mousePosition.x >= Screen.width - mousePanBorderThickness) {
			rot.y += rotationalSensitivity * Time.deltaTime;
		}
			
		float scroll = Input.GetAxis ("Mouse ScrollWheel");
		pos.y += ((invertScroll) ? 1:-1) * scroll * scrollSensitivity * Time.deltaTime;
				
		pos.x = Mathf.Clamp (pos.x, minXBound+cameraPanBorderThickness, maxXBound-cameraPanBorderThickness); 
		pos.y = Mathf.Clamp (pos.y, minHeight, maxHeight);
		pos.z = Mathf.Clamp (pos.z, minYBound+cameraPanBorderThickness, maxYBound-cameraPanBorderThickness); 

		transform.position = pos;
		transform.rotation = Quaternion.Euler(rot.x, rot.y, rot.z);

		/**
		if (Input.GetKey (KeyCode.LeftShift)) {
			panSensitivity = 20f;
		}**/

	}
}
