using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	//konsep singleton
	//Hanya ada satu instance (jika lebih dari satu , hapus yang lainnya)
	//bisa di akses di mana saja
	public static AudioManager instance = null;
	public AudioSource sfxplayer;

	private void Awake()
	{
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy(gameObject);

		DontDestroyOnLoad(gameObject);
	}

	public void playsfx(AudioClip sfx)
	{
		sfxplayer.clip = sfx;
		sfxplayer.Play();
	}
}
