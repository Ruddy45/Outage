using UnityEngine;

// État de mouvement pour suivre un objet
public class FollowState : State
{
	[SerializeField] private Transform _objectToFollow = null;				// Permet d'obtenir la position de l'objet à suivre
	[SerializeField] private bool _blockPlayer = false;						// Si le NPC doit bloquer le joueur

	private PlayerBehavior _player = null;									// Script du joueur

	protected override void Start()
	{
		base.Start();

		if (!_objectToFollow)
		{
			Debug.LogError("ObjectToFollow est null.");
			return;
		}

		// S'il s'agit du joueur, on le stocke
		if (_objectToFollow.GetComponent<PlayerBehavior>())
		{
			_player = _objectToFollow.GetComponent<PlayerBehavior>();
		}
	}

	public override void Execute()
	{
		if (!_objectToFollow)
			return;

		// Bloque le joueur quand le NPC le suit
		if (_player)
		{
			_player.BlockByNPC = _blockPlayer;
		}
		_agent.SetDestination(_objectToFollow.position);
	}
}