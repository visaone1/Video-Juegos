using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }

    public AudioSource sfxSource;

    [Header("Clips de Sonido")]
    public AudioClip sonidoSalto;
    public AudioClip sonidoMoneda;
    public AudioClip sonidoMuerte;
    // CRÍTICO: Este nombre debe ser EXACTO al que busca el GameManager
    public AudioClip sonido1Up; 

    private void Awake()
    {
        if (Instance == null) {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } else {
            Destroy(gameObject);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null && sfxSource != null) {
            sfxSource.PlayOneShot(clip);
        }
    }
}