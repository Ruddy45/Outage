using UnityEngine;
using UnityEditor;

// Dessine le field of view dans l'éditeur pour que ce soit plus facile à représenter
[CustomEditor(typeof(FieldOfView))]
public class FieldOfViewEditor : Editor
{
	private void OnSceneGUI()
	{
		FieldOfView fow = (FieldOfView)target;
		Vector3 fowPos = fow.transform.position;

		DrawAngleRadius(fow, fowPos);
		DrawViewAngle(fow, fowPos);
		DrawVisibleTarget(fow, fowPos);
	}

	// Dessin du cercle/radius sur la vue disponible
	private void DrawAngleRadius(FieldOfView fow, Vector3 fowPos)
	{
		Handles.color = Color.white;
		Handles.DrawWireArc(fowPos, Vector3.forward, Vector3.left, 360, fow.ViewRadius);
	}

	// Dessin des traits montrant le fov
	private void DrawViewAngle(FieldOfView fow, Vector3 fowPos)
	{
		Vector3 viewAngleA = fow.DirFromAngle(-fow.ViewAngle / 2, false);
		Vector3 viewAngleB = fow.DirFromAngle(fow.ViewAngle / 2, false);
		Handles.DrawLine(fowPos, fowPos + viewAngleA * fow.ViewRadius * -1);
		Handles.DrawLine(fowPos, fowPos + viewAngleB * fow.ViewRadius * -1);
	}

	// Raycast quand une cible est dans le périmètre
	private void DrawVisibleTarget(FieldOfView fow, Vector3 fowPos)
	{
		Handles.color = Color.red;
		
		if (fow.VisibleTarget)
		{
			Handles.DrawLine(fowPos, fow.VisibleTarget.position);
		}
	}
}
