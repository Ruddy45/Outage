/* Author : Lucas - 2020, for MIAMI project (IUT Tarbes)*/

using UnityEngine;

public class interact : MonoBehaviour
{

	public GameObject on = null;

	public GameObject off = null;

	public void tilesexchanger()
	{
		Debug.Log("interact");
		on.SetActive(false);
		off.SetActive(true);
	}
}
