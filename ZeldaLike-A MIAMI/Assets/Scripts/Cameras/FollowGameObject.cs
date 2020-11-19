/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using UnityEngine;

// Permet à la camera de suivre le joueur
public class FollowGameObject : MonoBehaviour
{
	public GameObject objectToFollow;                                  // Objet à suivre, ici le joueur

	// A chaque frame, la camera se place sur le joueur en x et y
	// le z reste celui définie sur la camera
	private void Update()
	{
		transform.position = new Vector3(objectToFollow.transform.position.x,
											  objectToFollow.transform.position.y,
											  transform.position.z);
	}
}
