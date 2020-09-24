using UnityEngine;

// État de mouvement pour suivre un objet
public class FollowState : State
{
	[SerializeField] private bool _blockPlayer = false;						// Si le NPC doit bloquer le joueur
	[SerializeField] private CardinalDirections _blockPlayerDirection =
		CardinalDirections.CARDINAL_E;                                      // Direction dans lequelle le NPC doit être bloquer

	private Transform _objectToFollow = null;								// Permet d'obtenir la position de l'objet à suivre
	private PlayerBehavior _player = null;									// Script du joueur

	public override void Enter()
	{
		_agent.stoppingDistance = _stoppingDistance;
		_objectToFollow = _fieldOfView.VisibleTarget;

		// S'il s'agit du joueur, on le stocke
		if (_objectToFollow && _objectToFollow.GetComponent<PlayerBehavior>())
		{
			_player = _objectToFollow.GetComponent<PlayerBehavior>();
		}
	}

	public override void Execute()
	{
		if (!_fieldOfView)
			return;

		//Si l'ennemi ne voit plus le joueur, on change d'état
		if (!_fieldOfView.VisibleTarget)
		{
			StateMachine.ChangeState(_nextState);
		}

		if (!_objectToFollow)
			return;

		// Bloque le joueur quand le NPC le suit
		if (_player)
		{
			_player.BlockByNPC = _blockPlayer;
			_player.BlockDirection = _blockPlayerDirection;
		}
		_agent.SetDestination(_objectToFollow.position);
	}

	public override void Exit()
	{
		_player = null;
	}
}