using UnityEngine;

// État de patrouille
public class PatrolState : State
{
	[SerializeField] private Transform[] _waypoints = new Transform[0];     // Waypoints que doit suivre l'ennemi

	private int _currentIndex = 0;                                          // Index de l'état utilisé

	// Initiliase le déplacement au premier waypoint
	public override void Enter()
	{
		_agent.stoppingDistance = _stoppingDistance;
		SwitchWaypoint(_currentIndex);
	}

	public override void Execute()
	{
		// Si on voit le joueur, on change d'état
		if (_fieldOfView.VisibleTarget)
		{
			StateMachine.ChangeState(_nextState);
		}

		// Si on est arrivé, on lance une nouvelle destination
		if (_agent.remainingDistance <= _agent.stoppingDistance)
		{
			NextWaypoint();
		}
	}

	public override void Exit() { }

	#region SwitchWaypoint
	// Change d'état dans le sens de la liste pour revenir au début
	private void NextWaypoint()
	{
		int tryIndex = _currentIndex + 1;
		if (_waypoints.Length <= tryIndex)
		{
			tryIndex = 0;
		}

		SwitchWaypoint(tryIndex);
	}

	// Change le Waypoint
	private void SwitchWaypoint(int tryIndex)
	{
		// Si l'index donné n'est pas bon, on envoie un message d'erreur
		if (tryIndex < 0 || _waypoints.Length <= tryIndex)
		{
			Debug.LogError($"{tryIndex} est en dehors du tableau de taille : {_waypoints.Length}");
			return;
		}

		// Initialise l'état utilisé
		_currentIndex = tryIndex;
		// Déplace l'agent
		_agent.SetDestination(_waypoints[_currentIndex].position);
		Debug.Log($"Switch Index to : {_currentIndex}");
	}
	#endregion

	// Ajoute le focus sur un des objets d'interaction
	public void AddObjectPatrol(Transform objectPatrol)
	{
		_waypoints = new Transform[1];
		_waypoints.SetValue(objectPatrol, 0);
	}
}