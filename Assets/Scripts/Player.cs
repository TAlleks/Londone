using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float HP = 100f;
    //[SerializeField] private Vector3 defaultSpawnPoint;

    private void Start()
    {
        // Используем статический класс вместо PlayerPrefs
        //if (SceneDataHolder.SpawnPosition.HasValue)
        //{
        //    transform.position = SceneDataHolder.SpawnPosition.Value;
        //    SceneDataHolder.Clear();
        //}
        //else
        //{
        //    transform.position = defaultSpawnPoint;
        //}
    }
}