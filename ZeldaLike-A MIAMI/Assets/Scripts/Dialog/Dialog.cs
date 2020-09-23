/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */


using System.Collections.Generic;
using UnityEngine;

// Dialogue
public class Dialog : MonoBehaviour
{
	public List<DialogPage> dialogWithPlayer;                          // Liste des dialogues avec le joueur

	// Permet à un autre composant de récupérer la liste
	public List<DialogPage> GetDialog()
	{
		return dialogWithPlayer;
	}
}
