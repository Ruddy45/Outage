using UnityEngine;

[ExecuteInEditMode]
public class ScaleCamera : MonoBehaviour
{
	[SerializeField] private Camera _camera = null;
	[SerializeField] private int _targetWidth = 640;
	[SerializeField] private float _pixelsToUnits = 3;

	private void Update()
	{
		int height = Mathf.RoundToInt(_targetWidth / (float)Screen.width * Screen.height);

		_camera.orthographicSize = height / _pixelsToUnits / 2;
	}
}
