using UnityEngine;
using UnityEngine.AI;

// Définie un état
public abstract class State : MonoBehaviour
{
	[SerializeField] protected NavMeshAgent _agent = null;                // Permet d'utiliser le pathfinding

	// Récupère le composant par défaut
	protected virtual void OnValidate() => _agent = GetComponent<NavMeshAgent>();

	protected virtual void Start()
	{
		// Bloquer la rotation qui cacherais le joueur sur la camera
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;
	}

	// Execute une état
	public abstract void Execute();
}
