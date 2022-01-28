using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Slide : MonoBehaviour
{
    private RectTransform rectTransform;
    [SerializeField] private float slideTime = 1.0f;
    [SerializeField] private float panelFadeAlpha = 0.6f;
    [SerializeField] private float panelFadeOutTime = 1.0f;
    [SerializeField] private float panelFadeOutDelayTime = 0.5f;
    [SerializeField] private Image image;

    private void Start() {
        rectTransform = GetComponent<RectTransform>();
        StartSlide();
    }

    public void StartSlide() {
        rectTransform.DOLocalMoveX(-1920, slideTime)
                     .SetEase(Ease.InQuart);
        
        image.DOFade(panelFadeAlpha, slideTime)
                .SetEase(Ease.OutExpo)
                .OnComplete(PanelFadeOut);
    }

    private void PanelFadeOut() {
        image.DOFade(0, panelFadeOutTime)
                .SetDelay(panelFadeOutDelayTime);
    }
}
