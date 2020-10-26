
using UnityEngine;


public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float updateSetup = 0.1f;
    public int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;
    public float clipLoudness;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void PlayMusic()
    {
        audioSource.Play();
    }
}
