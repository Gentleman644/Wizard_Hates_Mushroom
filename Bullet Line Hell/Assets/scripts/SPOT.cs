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
    public struct sound
    {
        public AudioClip clip;

        [Range(0.0f,1.0f)]
        public float volume;
        [Range(0.0f, 1.0f)]
        public float pitch;

        public AudioSource source;
    }
}
