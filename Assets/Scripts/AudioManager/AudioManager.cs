using UnityEngine.Audio;
using System;
using UnityEngine;


public class AudioManager : MonoBehaviour
{
   // public GameObject SfxOn;
   // public GameObject SfxOff;

	public static AudioManager instance;

	public AudioMixerGroup mixerGroup;

	public Sound[] sounds;

    public AudioSource[] allAudioSources;

    AudioListener al;

    

	void Awake()
	{
        //AudioListener.pause = false;

		if (instance != null)
		{
			Destroy(gameObject);
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}

		foreach (Sound s in sounds)
		{
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip;
			s.source.loop = s.loop;

			s.source.outputAudioMixerGroup = mixerGroup;
		}
	}

    void Start()
    {
       
        AudioListener al = GetComponent<AudioListener>();
        AudioSource[] allAudioSources = UnityEngine.Object.FindObjectsOfType<AudioSource>();
      //  Play("Theme");
    }

    void Update()
    {
      
    }

	public void Play(string sound)
	{
		Sound s = Array.Find(sounds, item => item.name == sound);
		if (s == null)
		{
			Debug.LogWarning("Sound: " + name + " not found!");
			return;
		}

		s.source.volume = s.volume * (1f );//+ UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f);//+ UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));

		s.source.Play();
	}

    public void Stop(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        s.source.Pause();
        //s.source.Stop();
    }

    public void Stop2(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        //s.source.Pause();
        s.source.Stop();
    }


    public void VolumeDown(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        s.volume = 0.1f;

    }

    public void VolumeUp(string sound)
    {
        Sound s = Array.Find(sounds, item => item.name == sound);

        s.volume = 0.75f;

    }
  

}
