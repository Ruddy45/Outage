/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using UnityEngine;

// Cette classe est utilisé pour être sûre qu'un sprite de NPC va apparaître derrière le joueur
// quand le joueur est devant lui, et appaître devant quand le joueur est derrière lui
public class PositionRegardingPlayer : MonoBehaviour
{
	SpriteRenderer npcRenderer;                                          // Sprite du NPC

	void Start()
	{
		// Récupére le composant sur le gameObject
		npcRenderer = GetComponent<SpriteRenderer>();
	}

	void Update()
	{
		// Charche le joueur
		GameObject player = GameObject.FindGameObjectWithTag("Player");

		// Si un joueur existe
		if (player != null)
		{
			// Récupèrer son sprite renderer et déterminer sa position par rapport au NPC
			SpriteRenderer playerRenderer = player.GetComponent<SpriteRenderer>();

			if (playerRenderer != null)
			{
				if (transform.position.y < player.transform.position.y)
				{
					npcRenderer.sortingOrder = playerRenderer.sortingOrder + 1;
				}
				else
				{
					npcRenderer.sortingOrder = playerRenderer.sortingOrder - 1;
				}
			}
		}
	}
}
