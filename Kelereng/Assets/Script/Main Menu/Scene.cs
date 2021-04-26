using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    // public GameObject pauseGame;
    public string nameScene;
    public float stayTime;
    public static int numberScene;
    LingakaranPlayer lingkaran;
    void Start()
    {
        if(numberScene == 0)
        {
            StartCoroutine(SplashToMenu());
        }
    }


    // Update is called once per frame
    void Update()
    {
        MoveFromMainMenu();
    }
    IEnumerator SplashToMenu()
    {
        yield return new WaitForSeconds(stayTime);
        numberScene = 1;
        SceneManager.LoadScene(1);
    }
    public void PauseGame()
    {
        //pauseGame.SetActive(true);
    }

    //pindah scene menu
    public void MenuScene()
    {
        SceneManager.LoadScene("Main Menu");
    }

    //pindah scene galeri
    public void GaleriScene()
    {
        SceneManager.LoadScene("Galeri");
    }

    //pindah scene setting
    public void SettingScene()
    {
        SceneManager.LoadScene("Setting");
    }

    //pindah scene pilih level
    public void PilihLevelScene()
    {
        SceneManager.LoadScene("Pilih Level");
    }

    //keluar dari game
    public void KeluarScene()
    {
        Application.Quit();
    }

    public void MoveFromMainMenu()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Tap The Screen");
            SceneManager.LoadScene("Galeri");
        }
    }

    public void GoToScene()
    {
        SceneManager.LoadScene(nameScene);
    }

    public void LoadNextLevel()
    {
        lingkaran.nextLevel = SceneManager.GetActiveScene().buildIndex + 1;   
    }
}
