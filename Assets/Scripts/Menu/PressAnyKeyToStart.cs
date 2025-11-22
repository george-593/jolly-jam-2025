using UnityEngine;
using UnityEngine.SceneManagement;

public class PressAnyKeyToStart : MonoBehaviour
{
    public string sceneToLoad = "GameScene";

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}