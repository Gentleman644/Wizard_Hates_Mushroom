using UnityEngine;

public class audioManagerScript : MonoBehaviour
{
    public SPOT.sound[] soundArray;

    private void Awake(){
        foreach(SPOT.sound s in soundArray)
        {
            AudioSource currentAudioSource = gameObject.AddComponent<AudioSource>();
            currentAudioSource.clip = s.clip;

            //
            currentAudioSource.volume = s.volume;
            currentAudioSource.pitch = s.pitch;
        }
    }
}