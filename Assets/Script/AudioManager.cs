using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    Dictionary<AudioSource, bool> pauseStates = new Dictionary<AudioSource, bool>();

    void Awake() {
        AudioSource[] sources = GameObject.FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        print(sources.Length);
        foreach(AudioSource audio in sources)
            pauseStates.Add(audio.GetComponent<AudioSource>(), false);
    }

    public void pauseAll() {
        foreach (AudioSource source in pauseStates.Keys)
        {
            pauseStates[source] = source.isPlaying;
            source.Pause();
        }
    }

    public void resumeAll() {
        foreach (AudioSource source in pauseStates.Keys) {
            if (pauseStates[source])
                source.Play();
            pauseStates[source] = false;
        }
    }

    public void stopAll() {
        foreach (AudioSource source in pauseStates.Keys)
            source.Stop();
    }
}
