using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{
	[SerializeField] private Transform _target = null;
	[SerializeField] private float _smoothSpeed = 0.125f;

	private void FixedUpdate()
	{
		Vector3 desiredPosition = new Vector3(
			_target.position.x,
			_target.position.y,
			transform.position.z);

		Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, _smoothSpeed);
		transform.position = smoothedPosition;
	}
}
