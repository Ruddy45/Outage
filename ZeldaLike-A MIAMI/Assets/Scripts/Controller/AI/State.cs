using UnityEngine;
using UnityEngine.AI;

// Définie un état
public abstract class State : MonoBehaviour
{
	[SerializeField] protected NavMeshAgent _agent = null;                  // Permet d'utiliser le pathfinding
	[SerializeField] protected FieldOfView _fieldOfView = null;             // Permet de détecter le joueur ou non
	[SerializeField] protected State _nextState = null;                     // Prochain état à exécuter
	[SerializeField, Range(0f, 30f)] protected float _stoppingDistance = 0f;// Distance d'arrêt du NPC

	public StateMachine StateMachine { get; set; } = null;					// Permet de changer d'état

	protected virtual void Start()
	{
		// Bloquer la rotation qui cacherais le joueur sur la camera
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;
	}

	// Entre l'état
	public abstract void Enter();
	// Execute une état
	public abstract void Execute();
	// Quitte l'état
	public abstract void Exit();
}
