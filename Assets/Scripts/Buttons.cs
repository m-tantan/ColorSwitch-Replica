using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public Slider musicSlider;
    public Slider soundsSlider;

	public void PlayGame(int scene) {
        
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

    public void changeMusicVolume()
    {
        FindObjectOfType<AudioManager>().editMusicVolume(musicSlider.value);
    }
    public void changeSoundsVolume()
    {
        FindObjectOfType<AudioManager>().editMusicVolume(musicSlider.value);
    }
    public void ExitScene()
    {
        
        Debug.Log("Exit");
        Application.Quit();
    }
}
