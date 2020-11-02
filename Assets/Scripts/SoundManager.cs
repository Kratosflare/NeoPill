
using UnityEngine;
using UnityEngine.Video;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audioSource;
    public AudioClip audioClip;
    public float updateStep = 0.1f;
    public int sampleDataLength = 1024;
    private float currentUpdateTime = 0f;
    public float clipLoudness;
    private float [] clipSampleData;
    public GameObject beats;
    public GameObject beats1;
    public GameObject beats2;
    public GameObject beats3;
    public GameObject beats4;
    public GameObject beats5;
    public float sizeFactor = 1;
    public float minSize = 0;
    public float maxSize = 50;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlayMusic()
    {
        audioSource.Play();
    }
    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];

    }



    /*
            // If these were all in an array rather than individually you 
            // could this
            ;
            foreach (GameObject go in allBeats)
                go.transform.localScale = clipVec;
*/
    private void Update()
    {
        GameObject[] allBeats = { beats, beats1, beats2, beats3, beats4, beats5 };

        Vector3 clipVec = new Vector3(clipLoudness, clipLoudness, clipLoudness);

        foreach (GameObject go in allBeats)
            go.transform.localScale = clipVec;

        PlayMusic();





        currentUpdateTime += Time.deltaTime;
        if (currentUpdateTime>= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData,audioSource.timeSamples);
            clipLoudness = 0f;
            foreach( var sample in clipSampleData)
            {
                clipLoudness += Mathf.Abs(sample);
            }
            clipLoudness /= sampleDataLength;

            clipLoudness *= sizeFactor;
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);
        }
    }
}
