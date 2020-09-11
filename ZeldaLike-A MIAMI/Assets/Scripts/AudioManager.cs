/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using UnityEngine;

// S'occupe de la gestion des sons et musiques
public class AudioManager : MonoBehaviour
{
	public static AudioManager instance = null;                         // Singleton / Permet de l'appeller dans d'autre script sans avoir de référence par l'éditeur

	public AudioSource soundStream;                                   // Source pour le son
	public AudioSource musicStream;                                   // Source pour la musique

	void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
		{
			Debug.LogError($"Deux singletons du type {typeof(AudioManager)} dans la scène.");
			Destroy(gameObject);
		}
	}

	// Joue un son
	public void PlaySound(AudioClip soundClipToPlay, float volume = 1.0f, float pitch = 1.0f)
	{
		soundStream.pitch = pitch;
		soundStream.volume = volume;
		soundStream.clip = soundClipToPlay;
		soundStream.Play();
	}

	// Arrête un son
	public void StopSound()
	{
		soundStream.Stop();
	}

	// Joue une musique
	public void PlayMusic(AudioClip musicClipToPlay, bool mustLoop, float volume = 1.0f, float pitch = 1.0f)
	{
		musicStream.pitch = pitch;
		musicStream.volume = volume;
		musicStream.loop = mustLoop;
		musicStream.clip = musicClipToPlay;
		musicStream.Play();
	}

	// Arrête la musique
	public void StopMusic()
	{
		musicStream.Stop();
	}
}
