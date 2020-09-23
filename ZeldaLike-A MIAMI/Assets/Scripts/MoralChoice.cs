using UnityEngine;

// Affiche et gére les choix moraux de fins
public class MoralChoice : MonoBehaviour
{
	[SerializeField] private GameObject _uiContainer = null;        // Contient l'ui du moral choice
	[SerializeField] private string _playerTag = "Player";          // Tag permettant d'identifier un joueur
	[SerializeField] private DialogManager _dialogManager = null;   // Permet d'afficher le texte de fin
	[SerializeField] private Dialog _outageDialog = null;			// Dialogue de coupure de courant
	[SerializeField] private Dialog _quitJobDialog = null;          // Dialogue où il démissionne

	private void Start() => _uiContainer.SetActive(false);

	// Affiche les choix moraux
	private void OnTriggerEnter2D(Collider2D col)
	{
		if (col.CompareTag(_playerTag))
		{
			Pause();
			_uiContainer.SetActive(true);
			AudioManager.instance.StopMusic();
		}
	}

	// Coupe le courant et garde son job
	public void Outage()
	{
		_uiContainer.SetActive(false);
		_dialogManager.SetDialog(_outageDialog.GetDialog());
	}

	// Quitte son job, mais laisse le courant
	public void QuitJob()
	{
		_uiContainer.SetActive(false);
		_dialogManager.SetDialog(_quitJobDialog.GetDialog());
	}

	private void Pause() => Time.timeScale = 0f;
}
