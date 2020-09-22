using UnityEngine;

// Oblige d'avoir un component input controller sur le gameObject
[RequireComponent(typeof(InputController))]
// S'occupe de la gestion des états
public class StateMachine : MonoBehaviour
{
	[SerializeField] private State[] _states = new State[1];        // Tableau des diffèrents états disponibles

	private State _currentState = null;                             // État actuellement utilisé
	private int _currentIndex = 0;									// Index de l'état utilisé
	private InputController _inputs = null;                         // Récupère les inputs du NPC

	// Charge automatiquement les états présent sur le gameObject
	private void OnValidate() => _states = GetComponents<State>();

	private void Awake()
	{
		foreach (var state in _states)
		{
			state.StateMachine = this;
		}

		// Récupère les inputs
		_inputs = GetComponent<InputController>();
		// État initial
		SwitchState(0);
	}

	// Exécute l'état actuel
	private void Update() => _currentState?.Execute();

	// Permet à un état de changer d'état
	public void ChangeState(State nextState)
	{
		_currentState?.Exit();
		_currentState = nextState;
		_currentState?.Enter();
	}

	#region SwitchStateDebug
	// Change d'état dans le sens de la liste pour revenir au début
	private void SwitchNextState()
	{
		int tryIndex = _currentIndex + 1;
		if (_states.Length <= tryIndex)
		{
			tryIndex = 0;
		}

		SwitchState(tryIndex);
	}

	// Change l'état
	private void SwitchState(int tryIndex)
	{
		// Si l'index donné n'est pas bon, on envoie un message d'erreur
		if (tryIndex < 0 || _states.Length <= tryIndex)
		{
			Debug.LogError($"{tryIndex} est en dehors du tableau de taille : {_states.Length}");
			return;
		}

		// Initialise l'état utilisé
		_currentIndex = tryIndex;
		_currentState = _states[_currentIndex];

		Debug.Log($"Switch State to : {_currentState.GetType()}");
	}
	#endregion
}
