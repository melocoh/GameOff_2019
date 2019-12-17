using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTransport : MonoBehaviour
{
    
    public string sceneName;
    void OnTriggerEnter2D(Collider2D col)
    {
        //SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}