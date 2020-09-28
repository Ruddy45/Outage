/* Author : Lucas - 2020, for MIAMI project (IUT Tarbes)*/

using UnityEngine;

public class interact : MonoBehaviour
{
	public GameObject on = null;

	public GameObject off = null;
	[SerializeField] private PatrolState _ia = null;		// IA qui patrouille

	public void tilesexchanger()
	{
		_ia?.AddObjectPatrol(transform);
		on.SetActive(false);
		off.SetActive(true);
	}
}
