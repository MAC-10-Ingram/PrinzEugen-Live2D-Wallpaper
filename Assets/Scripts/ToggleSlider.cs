using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSlider : MonoBehaviour
{
    public CanvasGroup slider;
    private bool isActive;

    // Start is called before the first frame update
    void Start()
    {
        isActive = false;
        ActiveControl();
    }

    public void toggleSlider(){
        isActive = !isActive;
        ActiveControl();
    }

    private void ActiveControl(){
        slider.alpha = isActive ? 1f : 0f;
        slider.interactable = isActive;
        slider.blocksRaycasts = isActive;
    } 
}
