using UnityEngine;
using UnityEngine.SceneManagement;

public class WinningScript : MonoBehaviour
{
    public HPbar bar;

    // Update is called once per frame
    void Update()
    {
        if (bar.HP <= 0)
        {
            SceneManager.LoadScene("Finish");
        }
    }
}
