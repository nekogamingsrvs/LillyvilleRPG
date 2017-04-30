using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadingZone : MonoBehaviour
{
    public int zoneSize = 5;
    public GameObject    player;
    public Vector2       playerExit;
    public string jumpToScene;
    public string jumpToLoadingZone;
    public string zoneName = "LoadingZone";
    public static string loadingZoneName;

	void Start ()
    {
	    if(loadingZoneName == zoneName)
        {
            player.transform.position = new Vector3(transform.position.x + playerExit.x, transform.position.y + playerExit.y, 0);
        }
	}
	
	void Update ()
    {
        Vector3 pos = player.transform.position;
        Vector3 tPos = transform.position;

        if(pos.x > tPos.x - zoneSize && pos.x < tPos.x + zoneSize && pos.y > tPos.y - zoneSize && pos.y < tPos.y + zoneSize)
        {
            TransitionScene();
        }
	}

    void TransitionScene()
    {
        loadingZoneName = jumpToLoadingZone;

        SceneManager.LoadScene(jumpToScene, LoadSceneMode.Single);
    }
}