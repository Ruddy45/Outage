using UnityEngine;
using UnityEngine.AI;

// Animation d'un NPC
public class NPCAnimation : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent = null;            // Agent et valeur de déplacement
	[SerializeField] private Transform _agentView = null;           // Vue de l'agent sur laquelle on effectue une rotation
	[SerializeField] private Animator _animator = null;             // Animation du personnage
	[SerializeField] private DirectionAndAngle[] _directionAndAngle = // Donne l'angle à prendre pour l'agent view selon la direction
		new DirectionAndAngle[4];

	private CardinalDirections _direction;                          // Actuel direction du joueur

	[System.Serializable]
	private struct DirectionAndAngle
	{
		[SerializeField] private CardinalDirections _direction;
		[SerializeField] private float _angle;

		public DirectionAndAngle(float angle, CardinalDirections direction)
		{
			_angle = angle;
			_direction = direction;
		}

		public CardinalDirections Direction => _direction;
		public float Angle => _angle;
	}

	private void Update()
	{
		DefineDirection();
		ChangeAnimationToMatchDirection();
		ChangeAgentViewToMatchDirection();
	}

	private void DefineDirection()
	{
		// Donne la direction principal du joueur
		Vector2 dir = _agent.desiredVelocity;

		if (Mathf.Abs(dir.x) > Mathf.Abs(dir.y))
		{
			_animator.SetBool("marche", true);
			if (dir.x > 0)
			{
				_direction = CardinalDirections.CARDINAL_E;
			}
			else
			{
				_direction = CardinalDirections.CARDINAL_W;
			}
		}
		else if (Mathf.Abs(dir.x) < Mathf.Abs(dir.y))
		{
			_animator.SetBool("marche", true);
			if (dir.y > 0)
			{
				_direction = CardinalDirections.CARDINAL_N;
			}
			else
			{
				_direction = CardinalDirections.CARDINAL_S;
			}
		}
		else if (0 < Mathf.Abs(dir.x) && (Mathf.Abs(dir.x) == Mathf.Abs(dir.y)))
		{
			_animator.SetBool("marche", true);
		}
		else if(_agent.desiredVelocity == Vector3.zero)
		{
			_animator.SetBool("marche", false);
		}
	}

	private void ChangeAnimationToMatchDirection() => _animator.SetInteger("direction_animation", (int)_direction);

	// On récupèrer l'angle que l'on a utilisé
	private void ChangeAgentViewToMatchDirection()
	{
		foreach (var oneDirectionAndAngle in _directionAndAngle)
		{
			if (oneDirectionAndAngle.Direction == _direction)
			{
				_agentView.localEulerAngles = new Vector3(0f,
												_directionAndAngle[(int)_direction].Angle,
												0f);

				break;
			}
		}
	}

	// Passe d'un Vecteur 3 à 2
	private Vector2 CastVector3To2(Vector3 toCast) => new Vector2(toCast.x, toCast.y);
}
