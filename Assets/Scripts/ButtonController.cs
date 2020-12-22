using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour
{
    bool explanationStarted;

    UIController uiController;
    AsymmetricModel aModel;
    void Start()
    {
        explanationStarted = false;
        uiController = FindObjectOfType<UIController>();
        aModel = FindObjectOfType<AsymmetricModel>();
    }

    void Update()
    {
        
    }

    public void StartButton()
    {
        StartCoroutine(LevelManager.NextLevel());
    }

    public void ExitButton()
    {
        StartCoroutine(LevelManager.QuitApplication());
    }

    public void StartExplanation()
    {
        if(!explanationStarted)
        {
            ToggleExplanationAnimation(true,0.4f,0.1f);
        }
        else
        {
            ToggleExplanationAnimation(false, 1f,0.4f);
        }
        
    }

    private void ToggleExplanationAnimation(bool trigger,float transparencyValue, float bgMusicVolume)
    {
        explanationStarted = trigger;
        uiController.ToggleButtonTransparency(transparencyValue);
        uiController.TogglePropertyAnimation("explanationStarted", trigger);
        uiController.ToggleExplanationPanelAnimation("explanationStarted", trigger);
        uiController.ToggleButtonAnimator("explanationStarted", trigger);
        uiController.ToggleNarrator(trigger);
        //uiController.SetBGMusicVolume(bgMusicVolume);
        aModel.ToggleAModelAnimator("explanationStarted", trigger);
        StartCoroutine(uiController.ToggleNextSceneButtonAlive(!trigger));
    }

    public void NextSceneButton()
    {
        StartCoroutine(LevelManager.NextLevel());
    }

    public void PrevSceneButton()
    {
        StartCoroutine(LevelManager.PrevLevel());
    }

    public void SelectionButton()
    {
        switch(EventSystem.current.currentSelectedGameObject.name)
        {
            case "Bromochlorofluoromethane":
                StartCoroutine(LevelManager.GoToSpecificLevel(3));
                break;
            case "Alanine":
                StartCoroutine(LevelManager.GoToSpecificLevel(4));
                break;
            case "Glucose":
                StartCoroutine(LevelManager.GoToSpecificLevel(5));
                break;
            case "ChairCyclohexane":
                StartCoroutine(LevelManager.GoToSpecificLevel(6));
                break;
            case "BoatCyclohexane":
                StartCoroutine(LevelManager.GoToSpecificLevel(7));
                break;
        }
    }

    public void GoToSelectionScreen(int level)
    {
        StartCoroutine(LevelManager.GoToSpecificLevel(2));
    }
}
