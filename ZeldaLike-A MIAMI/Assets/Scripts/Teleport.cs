/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using UnityEngine;

// Cette classe téléporte le joueur d'un scène à une autre
// Si la scène est diffèrente de la précédente, l'ancienne 
// scène est désactivé et la nouvelle activée.
public class Teleport : MonoBehaviour
{
	public GameObject teleportTo = null;                                // Destination de téléportation

	private GameObject player = null;                                   // Joueur

	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Si le joueur entre dans la zone, il est téléporté
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			TeleportPlayer();
		}
	}

	// Change la position du joueur
	private void TeleportPlayer()
	{
		if (teleportTo != null)
		{
			if (transform.parent != null)
			{
				transform.parent.gameObject.SetActive(false);
				teleportTo.transform.parent.gameObject.SetActive(true);

				player.transform.position = teleportTo.transform.position;
			}
		}
	}
}
