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
<<<<<<< Updated upstream
	public List<DialogPage> dialogWithPlayer;                          // Liste des dialogues avec le joueur
=======
	public List<DialogPage> dialogWithPlayer;      // Liste des dialogues avec le joueur
>>>>>>> Stashed changes

	// Permet à un autre composant de récupérer la liste
	public List<DialogPage> GetDialog()
	{
		return dialogWithPlayer;
	}
}
