using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneChanger : MonoBehaviour
{

    public void startGameScene()
    {
        Debug.Log("start button was pushed down");
        SceneManager.LoadScene(SPOT.MAIN_GAME_SCENE);
    }

    public void stopGameScene() 
    {
        Debug.Log("end button was pushed");
        Application.Quit();
    }
}
