using UnityEngine;

[ExecuteInEditMode]
public class PixelPerfectCamera : MonoBehaviour
{
	[SerializeField] private Camera _camera = null;
	[SerializeField] private float _pixelsToUnits = 3;

	private void Update() => _camera.orthographicSize = Screen.height / _pixelsToUnits / 2;
}
