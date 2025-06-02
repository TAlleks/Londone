using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerForChangeScene : MonoBehaviour
{
    [Header("Настройки")]
    public string targetSceneName;
    public Transform exitPoint;
    public bool saveReturnPosition = true;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Hands"))
        {
            // Сохраняем позицию в статическом классе
            //SceneDataHolder.SpawnPosition = exitPoint.position;

            //// Опционально: сохраняем позицию для возврата
            //if (saveReturnPosition)
            //{
            //    PlayerPrefs.SetFloat("ReturnPosX", other.transform.position.x);
            //    PlayerPrefs.SetFloat("ReturnPosY", other.transform.position.y);
            //    PlayerPrefs.SetFloat("ReturnPosZ", other.transform.position.z);
            //}

            SceneManager.LoadScene(targetSceneName);
        }
    }
}



//using UnityEngine;
//using UnityEngine.SceneManagement;

//public class TriggerForChangeScene : MonoBehaviour
//{
//    [SerializeField] private string sceneNameToLoad;
//    public GameObject player;
//    int k = 0;

//    private void Start()
//    {
//        if (sceneNameToLoad == "Church")
//        {
//            player.transform.position = new Vector3(-62.5f, 2.06f, -249f);
//        }
//        //PlayerPrefs.SetInt("inchurch", 0);
//    }

//    private void OnTriggerEnter(Collider other)
//    {

//        if (other.CompareTag("Hands"))
//        {
//            PlayerPrefs.SetInt("inchurch", 1);

//            SceneManager.LoadScene(sceneNameToLoad);
//        }



//    }
//}
