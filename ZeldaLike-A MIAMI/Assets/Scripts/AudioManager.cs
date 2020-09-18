/* Author : Raphaël Marczak - 2018/2020, for MIAMI Teaching (IUT Tarbes)
 * 
 * This work is licensed under the CC0 License. 
 * 
 */

using UnityEngine;

// Définie un audio clip avec ses paramètres, permet de le modifier depuis l'inspecteurs
[System.Serializable]
public struct AudioGroup
{
	[SerializeField] private AudioClip _clip;						// Audio Clip à jouer
	[SerializeField, Range(0f, 2f)] private float _volume;			// Volume de l'audio clip
	[SerializeField, Range(0f, 2f)] private float _pitch;			// Pitch

	public AudioClip Clip => _clip;
	public float Volume => _volume;
	public float Pitch => _pitch;

	// Constructeurs de la Struct
	public AudioGroup(AudioClip clipToPlay, float volume = 1.0f, float pitch = 1.0f)
	{
		_clip = clipToPlay;
		_volume = volume;
		_pitch = pitch;
	}
}

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

	// Joue un son d'audio group
	public void PlaySound(AudioGroup soundToPlay)
	{
		soundStream.pitch = soundToPlay.Pitch;
		soundStream.volume = soundToPlay.Volume;
		soundStream.clip = soundToPlay.Clip;
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

	// Joue une musique d'audio group
	public void PlayMusic(AudioGroup musicToPlay)
	{
		musicStream.pitch = musicToPlay.Pitch;
		musicStream.volume = musicToPlay.Volume;
		musicStream.clip = musicToPlay.Clip;
		musicStream.Play();
	}

	// Arrête la musique
	public void StopMusic()
	{
		musicStream.Stop();
	}
}
