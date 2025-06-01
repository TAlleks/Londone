using UnityEngine;
using System.Collections.Generic;


public class BackgroundMusic : MonoBehaviour
{
    [SerializeField] private List<AudioClip> musicTracks; // Список аудиотреков
    [SerializeField] private float volume = 1f; // Громкость музыки
    [SerializeField] private bool shuffle = true; // Включить случайный порядок
    [SerializeField] private bool fadeBetweenTracks = true; // Плавное переключение
    [SerializeField] private float fadeDuration = 1f; // Длительность перехода

    private AudioSource audioSource;
    private List<AudioClip> playlist;
    private int currentTrackIndex = 0;
    private bool isFading = false;

    private void Awake()
    {
        // Создаем и настраиваем AudioSource
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = 0; // Начинаем с 0, если будет fade-in
        audioSource.loop = false;
    }

    private void Start()
    {
        if (musicTracks.Count == 0)
        {
            Debug.LogWarning("No music tracks assigned!");
            return;
        }

        CreatePlaylist();
        PlayNextTrack();
    }

    private void Update()
    {
        if (!isFading && !audioSource.isPlaying && playlist.Count > 0)
        {
            PlayNextTrack();
        }
    }

    private void CreatePlaylist()
    {
        playlist = new List<AudioClip>(musicTracks);

        if (shuffle)
        {
            // Перемешиваем треки используя алгоритм Fisher-Yates
            for (int i = playlist.Count - 1; i > 0; i--)
            {
                int j = Random.Range(0, i + 1);
                (playlist[i], playlist[j]) = (playlist[j], playlist[i]);
            }
        }
    }

    private void PlayNextTrack()
    {
        if (playlist.Count == 0)
        {
            CreatePlaylist(); // Пересоздаем плейлист если треки закончились
        }

        if (fadeBetweenTracks && audioSource.isPlaying)
        {
            StartCoroutine(FadeOutAndPlayNext());
        }
        else
        {
            StartTrack();

            if (fadeBetweenTracks)
            {
                StartCoroutine(FadeIn());
            }
            else
            {
                audioSource.volume = volume;
            }
        }
    }

    private void StartTrack()
    {
        audioSource.clip = playlist[currentTrackIndex];
        audioSource.Play();

        currentTrackIndex = (currentTrackIndex + 1) % playlist.Count;
    }

    private System.Collections.IEnumerator FadeOutAndPlayNext()
    {
        isFading = true;

        // Fade out текущего трека
        float startVolume = audioSource.volume;
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
            yield return null;
        }

        audioSource.Stop();
        StartTrack();

        // Fade in нового трека
        yield return FadeIn();

        isFading = false;
    }

    private System.Collections.IEnumerator FadeIn()
    {
        float timer = 0f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(0f, volume, timer / fadeDuration);
            yield return null;
        }

        audioSource.volume = volume;
    }

    // Метод для изменения громкости
    public void SetVolume(float newVolume)
    {
        volume = Mathf.Clamp01(newVolume);
        if (!isFading)
        {
            audioSource.volume = volume;
        }
    }

    // Метод для переключения режима случайного порядка
    public void SetShuffle(bool enableShuffle)
    {
        shuffle = enableShuffle;
        CreatePlaylist(); // Пересоздаем плейлист при изменении режима
    }
}