using UnityEngine;
using System.Collections;

public class BigBenSound : MonoBehaviour
{
    [Header("Настройки музыки")]
    public AudioClip specialMusic; // Особый трек, который будет включаться
    public AudioSource[] allMusicSources; // Все источники музыки в сцене
    public float switchInterval = 120f; // Интервал переключения в секундах
    public float specialMusicDuration = 60f; // Длительность особого трека

    private AudioSource specialMusicSource; // Источник для особого трека
    private Coroutine musicSwitchCoroutine;

    void Start()
    {
        // Создаем отдельный источник для особого трека
        specialMusicSource = gameObject.AddComponent<AudioSource>();
        specialMusicSource.clip = specialMusic;
        specialMusicSource.loop = false;

        // Находим все источники музыки, если они не назначены вручную
        if (allMusicSources == null || allMusicSources.Length == 0)
        {
            allMusicSources = FindObjectsOfType<AudioSource>();
        }

        // Запускаем корутину переключения музыки
        musicSwitchCoroutine = StartCoroutine(MusicSwitchRoutine());
    }

    IEnumerator MusicSwitchRoutine()
    {
        while (true)
        {
            // Ждем указанный интервал
            yield return new WaitForSeconds(switchInterval);

            // Выключаем всю другую музыку
            foreach (var source in allMusicSources)
            {
                if (source != specialMusicSource)
                {
                    source.Pause();
                }
            }

            // Включаем особый трек
            specialMusicSource.Play();

            // Ждем пока трек проиграется
            yield return new WaitForSeconds(specialMusicDuration);

            // Выключаем особый трек
            specialMusicSource.Stop();

            // Включаем всю другую музыку обратно
            foreach (var source in allMusicSources)
            {
                if (source != specialMusicSource && source.clip != null)
                {
                    source.Play();
                }
            }
        }
    }

    void OnDestroy()
    {
        // Останавливаем корутину при уничтожении объекта
        if (musicSwitchCoroutine != null)
        {
            StopCoroutine(musicSwitchCoroutine);
        }
    }
}