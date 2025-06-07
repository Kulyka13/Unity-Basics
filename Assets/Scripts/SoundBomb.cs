using UnityEngine;

public class SoundBomb : MonoBehaviour
{
	public AudioClip boomSound;
	private AudioSource audioSource;

	private void Start()
	{
		audioSource = GetComponent<AudioSource>();
	}

	private void OnTriggerEnter(Collider other)
	{
		audioSource.clip = boomSound;
		audioSource.Play();
	}
}
