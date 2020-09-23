using UnityEngine;

// Donne les différents inputs
public class InputController : MonoBehaviour
{
	public bool ChangeNPCMoveMode => Input.GetKeyDown(KeyCode.F1);      // Changement de mode de navigation du NPC (suit le joueur ou se déplace avec la souris)	
	public bool ChangeDestination => Input.GetMouseButton(0);           // Change la destination voulue du NPC
	public Vector2 MousePosition => Input.mousePosition;                // Position souhaité en debug pour le NPC
}
