using UnityEngine;

//start up objects that we can specify if we want it to destroy on next scene or not
//(this is where we start up all important objects that can't be destroyed)
public class objectStartUps : MonoBehaviour
{
    [SerializeField] private SPOT.objectStartup[] objectStartupList;

    private void Awake()
    {
        foreach (SPOT.objectStartup s in objectStartupList)
        {
            GameObject currentGameObject = Instantiate(s.startupObject);

            if (s.noDestroyOnLoad)
            {
                GameObject.DontDestroyOnLoad(currentGameObject);
            }
        }
    }
}
