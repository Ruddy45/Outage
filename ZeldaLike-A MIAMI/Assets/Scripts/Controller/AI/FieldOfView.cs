using System.Collections;
using UnityEngine;

// Champs de vue d'une unité
public class FieldOfView : MonoBehaviour
{
	[SerializeField, Range(0f, 70f)] private float _viewRadius = 40f;		// Périmètre de vue
	[SerializeField, Range(0f, 360f)] private float _viewAngle = 70f;		// FOV du joueur
	[SerializeField] private LayerMask _targetMask = new LayerMask();		// Layer des cibles / Celles que l'on voit
	[SerializeField] private LayerMask _obstacleMask = new LayerMask();     // Layer des obstacles / Qui bloquent la vision
	[SerializeField] private float _delay = 0.2f;							// Delay entre chaque recherche

	public float ViewRadius => _viewRadius;
	public float ViewAngle => _viewAngle;
	public Transform VisibleTarget { get; private set; }					// Joueur visible ou non

	private void Start() => StartCoroutine(FindTargetsWithDelay(_delay));

	// Cherche les cibles dans un intervalle de temps afin de ne pas le faire àa chaque frame
	private IEnumerator FindTargetsWithDelay(float delay)
	{
		while(true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTarget();
		}
	}

	// Cherche les cibles
	private void FindVisibleTarget()
	{
		VisibleTarget = null;

		// Récupère tout les collider dans un périmetre précis correspondant au layer du target
		Collider2D[] targetsInRadius = Physics2D.OverlapCircleAll(transform.position, _viewRadius, _targetMask);

		for (int i = 0; i < targetsInRadius.Length; i++)
		{
			Transform currentTarget = targetsInRadius[i].transform;
			Vector3 dirToTarget = (currentTarget.position - transform.position).normalized;
			// Vérification si l'unité est dans le champ de vision
			if (Vector3.Angle(-transform.up, dirToTarget) < _viewAngle / 2)
			{
				float dstToTarget = Vector3.Distance(transform.position, currentTarget.position);

				// S'il n'y a pas d'obstacles qui bloque la vision du joueur
				if (!Physics2D.Raycast(transform.position, dirToTarget, dstToTarget, _obstacleMask))
				{
					VisibleTarget = currentTarget;
				}
			}
		}
	}

	// Permet d'avoir une visualisation dans l'éditeur
	public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
	{
		if (!angleIsGlobal)
		{
			angleInDegrees += transform.eulerAngles.y;
		}
		return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad), 0);
	}
}
