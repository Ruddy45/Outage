using UnityEngine;

// Delete fade screen and intro dialog if it was display in other session
public class VerifyAlreadyPlayed : MonoBehaviour
{
	[SerializeField] private FadeScreen _fadeScreen = null;
	[SerializeField] private Dialog _introDialog = null;

	private void Awake()
	{
		// Already Played
		if (PlayerPrefs.HasKey(PlayerPrefsConst.ALREADY_PLAYED))
		{
			Destroy(_introDialog.gameObject);
			StartCoroutine(_fadeScreen.Destroy(0f));
		}
		// Play for the first time
		else
		{
			PlayerPrefs.SetInt(PlayerPrefsConst.ALREADY_PLAYED, 0);
		}
	}

	private void Update()
	{
		// Reset intro dialogue 
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			PlayerPrefs.DeleteKey(PlayerPrefsConst.ALREADY_PLAYED);
		}
	}
}
