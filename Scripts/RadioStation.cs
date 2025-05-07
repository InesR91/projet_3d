using UnityEngine;
using UnityEngine.UI;

public class RadioStation : MonoBehaviour
{
    public GameObject radioButtonUI;
    public AudioSource staticAudio;
    public AudioSource musicAudio;
    public Transform playerTransform;

    public float maxVolume = 1f;
    public float minVolume = 0.1f;
    public float detectionRange = 10f;

    private bool isStationChanged = false;
    private bool isPlayerInZone = false;

    void Start()
    {
        if (staticAudio != null)
        {
            staticAudio.volume = minVolume;
            staticAudio.loop = true;
            staticAudio.Play();
        }

        if (musicAudio != null)
        {
            musicAudio.playOnAwake = false;
            musicAudio.loop = true;
        }

        if (radioButtonUI != null)
        {
            radioButtonUI.SetActive(false);
        }
    }

    void Update()
    {
        if (isStationChanged || playerTransform == null || !isPlayerInZone)
            return;

        float distance = Vector3.Distance(transform.position, playerTransform.position);
        float t = 1 - Mathf.Clamp01(distance / detectionRange);
        staticAudio.volume = Mathf.Lerp(minVolume, maxVolume, t);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isStationChanged) return;

        if (other.CompareTag("Player"))
        {
            isPlayerInZone = true;
            if (radioButtonUI != null)
                radioButtonUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (isStationChanged) return;

        if (other.CompareTag("Player"))
        {
            isPlayerInZone = false;
            if (radioButtonUI != null)
                radioButtonUI.SetActive(false);

            staticAudio.volume = minVolume;
        }
    }

    public void ChangeStation()
    {
        if (isStationChanged) return;

        isStationChanged = true;

        if (staticAudio != null)
            staticAudio.Stop();

        if (musicAudio != null)
            musicAudio.Play();

        if (radioButtonUI != null)
            radioButtonUI.SetActive(false);
    }
}
