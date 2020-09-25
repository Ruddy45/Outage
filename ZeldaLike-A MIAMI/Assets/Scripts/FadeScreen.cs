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
		_dialogManager.OnEndDialogue -= Fade;
		StartCoroutine(Destroy());
	}

	private IEnumerator Destroy()
	{
		yield return new WaitForSecondsRealtime(_animation.clip.length);
		Destroy(gameObject);
	}
}
