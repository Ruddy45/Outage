using System.Collections;
using UnityEngine;

public class FadeScreen : MonoBehaviour
{
	[SerializeField] private DialogManager _dialogManager = null;
	[SerializeField] private Animation _animation = null;

	private void Awake() => _dialogManager.OnEndDialogue += Fade;

	private void Fade()
	{
		_animation.Play();
		StartCoroutine(Destroy(_animation.clip.length));
	}

	public IEnumerator Destroy(float length)
	{
		yield return new WaitForSecondsRealtime(length);
		_dialogManager.OnEndDialogue -= Fade;
		Destroy(gameObject);
	}
}
