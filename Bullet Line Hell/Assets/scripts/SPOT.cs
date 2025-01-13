using System;
using UnityEngine;
using UnityEngine.Audio;
/*
 * Single Point Of Truth File
 */
public class SPOT
{
    public static readonly int MAIN_GAME_SCENE = 1;
    public static readonly int X_POSITION_VALUE = 0;
    public static readonly int Y_POSITION_VALUE = 1;

    [System.Serializable]
    public struct sound{
        public string name;
        public AudioClip clip;

        [Range(0.0f,1.0f)]
        public float volume;
        [Range(0.0f, 1.0f)]
        public float pitch;
        public bool loop;
        public string audioOutputGroup;

        [HideInInspector]
        public AudioSource source;

        public void putSource(AudioSource newSource)
        {
            source = newSource;
        }
    }

    [System.Serializable]
    public struct objectStartup{
        public GameObject startupObject;
        public bool noDestroyOnLoad;
    }
}
