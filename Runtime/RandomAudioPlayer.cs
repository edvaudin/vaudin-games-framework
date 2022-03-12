using UnityEngine;

namespace VaudinGames.Audio
{
    public class RandomAudioPlayer : MonoBehaviour
    {
        [SerializeField] AudioClipLibrary[] audioClipLibraries;
        private AudioSource audioSource;

        [System.Serializable]
        public struct AudioClipLibrary
        {
            public string libraryName;
            public AudioClip[] clips;
        }

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Play(string soundType)
        {
            foreach (AudioClipLibrary library in audioClipLibraries)
            {
                if (library.libraryName == soundType)
                {
                    AudioClip clip = GetRandomClip(library.clips);
                    audioSource.PlayOneShot(clip);
                }
            }
        }

        private AudioClip GetRandomClip(AudioClip[] clips) => clips[Random.Range(0, clips.Length)];

    }
}

