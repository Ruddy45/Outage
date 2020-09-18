using UnityEngine;

// Oblige d'avoir un component input controller sur le gameObject
[RequireComponent(typeof(InputController))]
// État de mouvement selon les mouvements de la souris
// Permet d'avoir les limites du nav mesh
// et de voir de potentielles bugs
public class DebugMovementState : State
{
	[SerializeField] private Camera _camera = null;                     // Main camera afin de convertir la position de la souris au monde du jeu

	private InputController _inputs = null;                             // Récupère les inputs du NPC
	private Ray _ray = new Ray();                                       // Ray permettant de savoir si on touche quelquechose ou non
	private RaycastHit _hit = new RaycastHit();                         // Informations sur ce que l'on a touché

	// Initialise l'agent avec le parent : State
	// Initialise la camera en la cherchant dans la scene
	protected override void OnValidate()
	{
		base.OnValidate();
		_camera = Camera.main;
	}

	// Récupère l'input controller sur le gameObject
	protected override void Start()
	{
		base.Start();

		_inputs = GetComponent<InputController>();

		if (!_camera)
		{
			Debug.LogError("Camera est null.");
			return;
		}
	}

	// Exécuter le mouvement de la souris
	public override void Execute()
	{
		// Déplacement souris et si un changement de destination à été fait
		if (_inputs.ChangeDestination)
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
}
