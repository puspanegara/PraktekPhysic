using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
    public GameObject pauseGame;

    // Start is called before the first frame update
    void Start()
    {
        pauseGame.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PauseGame()
    {
        pauseGame.SetActive(true);
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

    //pindah scene in game level 1
    public void Level1Scene()
    {
        SceneManager.LoadScene("In Game Level 1");
    }
    
    //pindah scene in game level 2
    public void Level2Scene()
    {
        SceneManager.LoadScene("In Game Level 2");
    }

    //keluar dari game
    public void KeluarScene()
    {
        Application.Quit();
    }
}
