using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MovingPanel : MonoBehaviour {
    public RectTransform mainPage;
    public Vector2 initialPosition;
    public Vector2 finalPosition;
    public float animationDuration = 1.0f;

    void Start() {
        mainPage.anchoredPosition = initialPosition;
    }

    public void MovePanel() {
        StartCoroutine(MovePanelCoroutine());
    }
    
    IEnumerator MovePanelCoroutine() {
        float elapsedTime = 0;
        var startingPosition = mainPage.anchoredPosition;
        
        while (elapsedTime < animationDuration) {
            elapsedTime += Time.deltaTime;
            var t = Mathf.Clamp01(elapsedTime / animationDuration);
            
            mainPage.anchoredPosition = Vector2.Lerp(startingPosition, finalPosition, t);

            yield return null;
        }
        mainPage.anchoredPosition = finalPosition;
        SwapDestination();
    }

    public void SwapDestination() {
        (initialPosition, finalPosition) = (finalPosition, initialPosition);
    }
}
