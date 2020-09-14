using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
  //Variable para guardar Escena Actual:
  int currentSceneIndex;

  //Tiempo de espera para pantalla inicial:
  [SerializeField] int timeToWait = 4;


  void Start()
  {
    currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    if (currentSceneIndex == 0)
    {
      FindObjectOfType<AudioManager>().Play("MainThemeSong");
      StartCoroutine(WaitForTime());
    }
  }

  IEnumerator WaitForTime()
  {
    yield return new WaitForSeconds(timeToWait);
    LoadNextScene();
  }
  public void LoadMainMenu()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Start Screen");
  }

  public void LoadLoginScreen()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Login Screen");
  }


  public void LoadMapScreen()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Building Map Screen");
  }

  public void LoadScene(string nameScene)
  {
    StartCoroutine(IELoadScene(nameScene));
  }

  public IEnumerator IELoadScene(string nameScene)
  {
    AsyncOperation _async = new AsyncOperation();


    if (SceneManager.GetSceneByName(nameScene).IsValid())
    {
      SceneManager.UnloadSceneAsync(nameScene);
    }
    _async = SceneManager.LoadSceneAsync(nameScene, LoadSceneMode.Additive);
    _async.allowSceneActivation = false;

    while (_async.progress < 0.9f)
    {
      yield return null;
    }

    _async.allowSceneActivation = true;

    while (!_async.isDone)
    {
      yield return null;
    }

    Scene nextScene = SceneManager.GetSceneByName(nameScene);
    if (nextScene.IsValid())
    {
      FindObjectOfType<AudioManager>().StopSounds();
      FindObjectOfType<AudioManager>().Play("ActivityThemeSong");
      SceneManager.SetActiveScene(nextScene);
      Scene mapScene = SceneManager.GetSceneByName("Building Map Screen");
      foreach (GameObject g in mapScene.GetRootGameObjects())
      {
        g.SetActive(false);
      }
    }
  }

  public void BackToMapScreen()
  {
    Time.timeScale = 1;
    Scene mapScene = SceneManager.GetSceneByName("Building Map Screen");
    FindObjectOfType<AudioManager>().StopSounds();
    FindObjectOfType<AudioManager>().Play("MainThemeSong");
    SceneManager.SetActiveScene(mapScene);

    foreach (GameObject g in mapScene.GetRootGameObjects())
    {
      g.SetActive(true);
    }

    for (int i = 0; i < SceneManager.sceneCount; i++)
    {
      if (SceneManager.GetSceneAt(i).name != "Building Map Screen")
      {
        SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(i));
      }
    }

  }

  public void LoadBlankScreen()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Blank Screen");
  }

  public void LoadOptionScreen()
  {
    Time.timeScale = 1;
    SceneManager.LoadScene("Option Screen");
  }

  public void RestartScene()
  {
    string nameActualScene = SceneManager.GetActiveScene().name;
    // Time.timeScale = 1;
    // SceneManager.LoadScene(currentSceneIndex);
    SceneManager.UnloadSceneAsync(nameActualScene);
    BackToMapScreen();
    LoadScene(nameActualScene);

  }

  public void LoadNextScene()
  {
    SceneManager.LoadScene(currentSceneIndex + 1);
  }

  public void LoadGameOver()
  {
    SceneManager.LoadScene("Lose Screen");
  }

  public void QuitGame()
  {
    Application.Quit();
  }

}
