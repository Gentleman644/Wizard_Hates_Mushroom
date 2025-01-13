using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class audioManagerScript : MonoBehaviour
{
    [SerializeField] private AudioMixer audioManagerMixer;
    [SerializeField]private SPOT.sound[] soundArray;
    private Dictionary<string, SPOT.sound> soundArrayDictionary = new Dictionary<string, SPOT.sound>();

    //there's a problem here with outputAudioMixerGroup as we need the whole path to the parent
    //would need to write edge cases and such
    private void Awake(){
        foreach(SPOT.sound s in soundArray)
        {
            AudioSource currentAudioSource = gameObject.AddComponent<AudioSource>();
            currentAudioSource.outputAudioMixerGroup = audioManagerMixer.FindMatchingGroups(s.audioOutputGroup)[0];
            currentAudioSource.loop = s.loop;
            currentAudioSource.clip = s.clip;
            currentAudioSource.volume = s.volume;
            currentAudioSource.pitch = s.pitch;
            s.putSource(currentAudioSource);
            soundArrayDictionary.Add(s.name, s);
        }
    }

    public void changeVolume(string groupName, float newVolume){
        audioManagerMixer.SetFloat(groupName, newVolume);
    }

    public void playAudio(string audioName){
        soundArrayDictionary[audioName].source.Play();
    }
}