using System.Collections.Generic;
using UnityEngine;

public class AttrapePlayer : MonoBehaviour
{
	public List<GameObject> ObjetDialog;
	[SerializeField] private string _playerTag = "Player";			// Tag permettant d'identifier un joueur
	[SerializeField] private AudioGroup _hitSound;					// Son à jouer en colision avec un obstacle

	private void OnTriggerEnter2D(Collider2D collision)
	{
		//tant qu'il reste un élement on créer un dialogue sinon on a perdus.
		if (ObjetDialog.Count > 0)
		{
			if (collision.tag == _playerTag)
			{
				//On créer le gameobject qu'il y a dans l'emplacement 0 de la liste ObjetDialog.
				Instantiate(ObjetDialog[0], new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
				//On supprime l'emplacement 0 ensuite et l'emplacement 1 devient le 0 et ainsi de suite.
				ObjetDialog.RemoveAt(0);
			}
		}
		else
		{
			Debug.Log("perdu");
		}
	}

	// Joue le son de collision
	private void OnCollisionEnter2D(Collision2D col)
	{
		// Si c'est le joueur
		if (col.gameObject.CompareTag(_playerTag))
		{
			AudioManager.instance.PlaySound(_hitSound);
		}
	}
}
