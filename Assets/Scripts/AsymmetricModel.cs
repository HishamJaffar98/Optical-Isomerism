using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AsymmetricModel : MonoBehaviour
{
    Animator modelAnimator;
    [SerializeField] SpriteRenderer[] crosses;

    Color opaque = new Color(1f, 1f, 1f, 1f);
    Color transparent = new Color(1f, 1f, 1f, 0f);
    float lerpFactor1 = 0f;
    float reverseLerpFactor = 0f;
    
    void Start()
    {
        modelAnimator = gameObject.GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(lerpFactor1>=0f && lerpFactor1<1)
        {
            lerpFactor1 = CrossesTransparencyFade(transparent,opaque,lerpFactor1);
            
        }
        else if(lerpFactor1>=1 && reverseLerpFactor<1f)
        {
            reverseLerpFactor=CrossesTransparencyFade(opaque, transparent, reverseLerpFactor);
        }
        else if(reverseLerpFactor>=1)
        {
            lerpFactor1 = 0f;
            reverseLerpFactor = 0f;
        }    
        transform.Rotate(0f, 1f, 0f);
    }

    private float CrossesTransparencyFade(Color color1, Color color2, float lerpFactor)
    {
        crosses[0].color = Color.Lerp(color1, color2, lerpFactor);
        crosses[1].color = Color.Lerp(color1, color2, lerpFactor);
        crosses[2].color = Color.Lerp(color2, color1, lerpFactor);
        crosses[3].color = Color.Lerp(color2, color1, lerpFactor);
        lerpFactor += Time.deltaTime;
        return lerpFactor;
    }

    public void ToggleAModelAnimator(string triggerName,bool value)
    {
        modelAnimator.SetBool(triggerName,value);
    }


}
