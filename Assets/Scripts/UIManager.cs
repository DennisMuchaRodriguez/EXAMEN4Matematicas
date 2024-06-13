using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public RectTransform uiElement;
    public float moveDuration = 1f;
    public Vector2 targetPosition;
    public Vector2 targetScale;

    void Start()
    {

        uiElement.DOAnchorPos(targetPosition, moveDuration);


        uiElement.DOScale(targetScale, moveDuration);
    }
    public void Scenechange()
    {
        SceneManager.LoadScene("Nivel 1");
    }
}
