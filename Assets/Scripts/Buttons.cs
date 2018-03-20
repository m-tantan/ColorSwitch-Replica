using UnityEngine.SceneManagement;
using UnityEngine;

public class Buttons : MonoBehaviour {

	
	public void SwitchScene(int scene) {
        
        Debug.Log("Clicked Play");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);


    }

    public void OptionsMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    public void FromOptionsToMenu() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -2);
    }
    public void FromGameToMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

    public void ExitScene()
    {
        Debug.Log("Exit");
        Application.Quit();
    }
}
