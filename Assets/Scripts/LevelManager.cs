using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class LevelManager
{
    private static int currentLevel;
    private static int totalScenes = SceneManager.sceneCountInBuildSettings;
    const float delayFactor = 1.5f;

    #region Public Methods
    public static IEnumerator NextLevel()
    {
        currentLevel = UpdateLevelIndex();
        yield return new WaitForSecondsRealtime(delayFactor);
        SceneManager.LoadScene((currentLevel + 1)%totalScenes);
    }

    public static IEnumerator PrevLevel()
    {
        currentLevel = UpdateLevelIndex();
        yield return new WaitForSecondsRealtime(delayFactor);
        SceneManager.LoadScene(currentLevel - 1);
    }

    public static IEnumerator GoToSpecificLevel(int level)
    {
        yield return new WaitForSecondsRealtime(delayFactor);
        SceneManager.LoadScene(level);
    }

    public static IEnumerator QuitApplication()
    {
        yield return new WaitForSecondsRealtime(delayFactor);
        Application.Quit();
    }
    #endregion

    #region Private Methods
    private static int UpdateLevelIndex()
    {
        return SceneManager.GetActiveScene().buildIndex;
    }
    #endregion
}
