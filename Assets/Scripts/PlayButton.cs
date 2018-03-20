using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayButton : MonoBehaviour {

	
	public void SwitchScene(int scene) {
        
        Debug.Log("Clicked");
        //SceneManager.LoadScene(SceneManager.GetSceneByBuildIndex(scene).buildIndex);


    }
}
