using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] Animator property2Animator;
    [SerializeField] Animator explanationPanelAnimator;
    [SerializeField] Animator explanationButtonAnimator;
    [SerializeField] GameObject explanationButton;
    [SerializeField] GameObject nextSceneButton;

    Color explanationButtonTextColor;
    AudioSource narrator;
    AudioSource audioManager;

    void Start()
    {
        explanationButtonTextColor=explanationButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color;
        narrator = GameObject.FindGameObjectWithTag("Narrator").GetComponent<AudioSource>();
        //audioManager = FindObjectOfType<AudioManager>().GetComponent<AudioSource>();
    }

    void Update()
    {

    }
    public void TogglePropertyAnimation(string triggerName, bool value)
    {
        property2Animator.SetBool(triggerName, value);
    }

    public void ToggleExplanationPanelAnimation(string triggerName, bool value)
    {
        explanationPanelAnimator.SetBool(triggerName, value);
    }

    public void ToggleButtonAnimator(string triggerName,bool value)
    {
        explanationButtonAnimator.SetBool(triggerName, value);
    }

    public void ToggleButtonTransparency(float value)
    {
        explanationButton.GetComponent<Image>().color= new Color(1f, 1f, 1f, value);

        explanationButton.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color=
        new Color(explanationButtonTextColor.r, explanationButtonTextColor.g, explanationButtonTextColor.b, value);
    }

    public IEnumerator ToggleNextSceneButtonAlive(bool value)
    {
        if(value==true)
        {
            yield return new WaitForSecondsRealtime(3.5f);
            nextSceneButton.SetActive(value);
        }
        else
        {
            yield return new WaitForSecondsRealtime(0f);
            nextSceneButton.SetActive(value);
        }
        
    }
    
    public void ToggleNarrator(bool value)
    {
        if(value==true)
        {
            narrator.Play();
        }
        else
        {
            narrator.Stop();
        }
    }

    public void SetBGMusicVolume(float value)
    {
        audioManager.volume = value;
    }
 
}
