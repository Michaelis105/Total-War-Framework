using UnityEngine;

/**
 * RTS Style Camera Controller
 * Adapted from Denis Sylkin's RTS Camera
 * https://www.assetstore.unity3d.com/en/#!/content/43321
 **/
public class CameraController : MonoBehaviour {

	// Average terrain elevation at 600 meters.
	// Camera maximum height should be 700 meters.
	// Camera minimum height should be 2 meters.

	public float panSensitivity = 20f;
	public float mousePanSensitivity = 20f;
	public float rotationalSensitivity = 20f;
	public float mouseRotationalSensitivity = 60f;
	public float scrollSensitivity = 200f;
	public float mouseScrollSensitivity = 100f;

	public float mousePanBorderThickness = 10f;
	public float cameraPanBorderThickness = 10f;

	public float minXBound = 0;
	public float maxXBound = 4000;

	public float minYBound = 0;
	public float maxYBound = 4000;

	public float minHeight = 2f;
	public float maxHeight = 300f;

	public bool invertScroll = false;

	private int RotationDirection {
		get {
			bool rotateRight = Input.GetKey(KeyCode.E);
			bool rotateLeft = Input.GetKey(KeyCode.Q);
			if (rotateLeft && !rotateRight) return -1;
			else if (!rotateLeft && rotateRight) return 1;
			else return 0;
		}
	}

	private int ZoomDirection {
		get {
			bool zoomIn = Input.GetKey (KeyCode.C);
			bool zoomOut = Input.GetKey (KeyCode.X);
			if (zoomIn && !zoomOut) return -1;
			else if (!zoomIn && zoomOut) return 1;
			else return 0;
		}
	}

	private Vector2 KeyboardInput {
		get { return new Vector2 (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical")); }
	}

	private Vector2 MouseAxis {
		get { return new Vector2 (Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y")); }
	}

	private float ScrollWheel {
		get { return Input.GetAxis ("Mouse ScrollWheel"); }
	}
		
	// Update called once per frame
	void Update () {

		if (Input.GetKey (KeyCode.LeftShift)) {
			//panSensitivity = 40f;
		}

		// Panning
		// TODO: Reduce keyboard panning sensitivity the closer camera is to ground.
		Vector3 newPos = new Vector3(KeyboardInput.x, 0, KeyboardInput.y);
		newPos = Quaternion.Euler(new Vector3(0f, transform.eulerAngles.y, 0f)) * newPos * panSensitivity * Time.deltaTime;
		newPos = transform.InverseTransformDirection (newPos);
		transform.Translate (newPos, Space.Self);

		// TODO: Implement panning via middle mouse button
		if (Input.GetKey(KeyCode.Mouse2)) {
			
		}

		// Rotation
		transform.Rotate(Vector3.up, RotationDirection * Time.deltaTime * rotationalSensitivity, Space.World);

		// TODO: Add rotate up-down. Mouse rotation restricted to left-right currently
		if (Input.GetKey(KeyCode.Mouse1)) {
			transform.Rotate (Vector3.up, -MouseAxis.x * Time.deltaTime * mouseRotationalSensitivity, Space.World);
		}

		// Zoom
		if (ZoomDirection != 0 || ScrollWheel != 0) {
			float distToGround = 0f;
			Ray ray = new Ray(transform.position, Vector3.down);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit, -1)) distToGround = (hit.point - transform.position).magnitude;

			float zoomPos = Time.deltaTime * scrollSensitivity;
			if (ScrollWheel != 0) zoomPos *= ScrollWheel;
			else if (ZoomDirection != 0) zoomPos *= ZoomDirection;

			zoomPos = Mathf.Clamp01 (zoomPos);
			float targetHeight = Mathf.Lerp (minHeight, maxHeight, zoomPos);
			float difference = 0;

			if (distToGround != targetHeight) difference = targetHeight - distToGround;

			transform.position = Vector3.Lerp(transform.position, 
				new Vector3 (transform.position.x, targetHeight+difference, transform.position.z), Time.deltaTime);
		}
				
		// Limit
		transform.position = new Vector3 (Mathf.Clamp (transform.position.x, minXBound, maxXBound),
			transform.position.y, Mathf.Clamp (transform.position.z, minYBound, maxYBound));
	}
}
