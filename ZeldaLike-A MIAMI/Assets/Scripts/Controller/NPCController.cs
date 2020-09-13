using UnityEngine;
using UnityEngine.AI;

// Oblige d'avoir un component input controller sur le gameObject
[RequireComponent(typeof(InputController))]
// Controlle le déplacement du NPC
public class NPCController : MonoBehaviour
{
	[SerializeField] private NavMeshAgent _agent = null;                // Permet d'utiliser le pathfinding
	[SerializeField] private PlayerBehavior _player = null;             // Permet d'obtenir la position du joueur
	[SerializeField] private Camera _camera = null;                     // Main camera afin de convertir la position de la souris au monde du jeu
	[Header("Déplace à la souris ou suit le joueur")]
	[SerializeField] private bool _moveWithMouse = false;               // Déplacement à la souris ou suit le joueur

	private InputController _inputs = null;                             // Récupère les inputs du NPc
	private Ray _ray = new Ray();                                       // Ray permettant de savoir si on touche quelquechose ou non
	private RaycastHit _hit = new RaycastHit();                         // Informations sur ce que l'on a touché

	private void Awake()
	{
		// Bloquer la rotation qui cacherais le joueur sur la camera
		_agent.updateRotation = false;
		_agent.updateUpAxis = false;

		_inputs = GetComponent<InputController>();

		if (!_camera)
		{
			Debug.LogError("Camera est null.");
			return;
		}
	}

	private void Update()
	{
		// Change le mode de déplacement
		if (_inputs.ChangeNPCMoveMode)
		{
			_moveWithMouse = !_moveWithMouse;
		}

		MouseMovement();

		// Pour ne pas faire le reste du Update avec ce mode
		if (_moveWithMouse)
			return;

		FollowMovement();
	}

	// Déplacement selon les mouvements de la souris
	private void MouseMovement()
	{
		// Déplacement souris et si un changement de destination à été fait
		if (_moveWithMouse && _inputs.ChangeDestination)
		{
			// Rayon pour toucher sur la position de la souris
			_ray = _camera.ScreenPointToRay(_inputs.MousePosition);

			// Si on touche quelque chose, alors il devient la destination
			if (Physics.Raycast(_ray, out _hit))
			{
				_agent.SetDestination(_hit.point);
			}
		}
	}

	// Mouvement pour suivre un objet
	private void FollowMovement() => _agent.SetDestination(_player.transform.position);
}