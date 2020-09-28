using UnityEngine;
using UnityEngine.SceneManagement;

// Affiche et change la scène en cas de victoire / défaite
public class WinAndLose : MonoBehaviour
{
	[SerializeField] private GameObject _winContainer = null;           // Message à afficher en cas de victoire
	[SerializeField] private GameObject _loseContainer = null;          // Message à afficher en cas de défaite

	private void Start()
	{
		_winContainer.SetActive(false);
		_loseContainer.SetActive(false);
	}

	public void Win()
	{
		_loseContainer.SetActive(false);
		_winContainer.SetActive(true);

		Pause();
	}
	public void Lose()
	{
		_winContainer.SetActive(false);
		_loseContainer.SetActive(true);

		Pause();
	}

	// Rejoue la scène
	public void Replay()
	{
		Destroy(AudioManager.instance.gameObject);
		Resume();
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	private void Pause() => Time.timeScale = 0f;
	private void Resume() => Time.timeScale = 1f;
}
