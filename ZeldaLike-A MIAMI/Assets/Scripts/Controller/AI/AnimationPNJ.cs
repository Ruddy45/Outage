using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AnimationPNJ : MonoBehaviour
{
	// Start is called before the first frame update
	public NavMeshAgent direction;
	private Transform positionPNJ;
	Animator animationPNJ;
	private float directionAngle;

	void Start()
	{
		positionPNJ = GetComponent<Transform>();
		Debug.Log("Nique toi la " + direction.desiredVelocity.x);
	}

	// Update is called once per frame
	void Update()
	{
		directionAngle = (float) Vector2.Angle(new Vector2(positionPNJ.position.x, positionPNJ.position.y), new Vector2(direction.desiredVelocity.x, direction.desiredVelocity.y));
		Debug.Log("Angle de direction du PNJ " + directionAngle);

		animationPNJ.SetFloat("directionPNJ", directionAngle);

		if (direction.desiredVelocity == Vector3.zero)
		{
			animationPNJ.SetBool("marchePNJ", false);
			Debug.Log("il reste de Marbre");
		} else {
			animationPNJ.SetBool("marchePNJ", true);
			Debug.Log("il marche putain");
		}
		/*
		if (directionAngle >= 315 || directionAngle <= 45)
		{
			Debug.Log(" il va en Haut ");
		} else if (directionAngle >= 45 && directionAngle <= 135)
		{
			Debug.Log(" il va a Droite ");
		} else if (directionAngle >= 135 && directionAngle <= 225)
		{
			Debug.Log(" il va en Bas ");
		} else if (directionAngle >= 225 && directionAngle <= 315)
		{
			Debug.Log(" il va à Droite ");
		}*/
	}
}
