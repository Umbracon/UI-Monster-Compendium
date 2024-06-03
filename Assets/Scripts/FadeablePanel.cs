using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeablePanel : MonoBehaviour {
    public CanvasGroup canvasGroup;
    public float animationDuration = 1.0f;

    public void FadePanel(bool forward) {
        StartCoroutine(FadePanelCoroutine(forward));
    }

    IEnumerator FadePanelCoroutine(bool forward) {
        yield return new WaitForSeconds(0.2f);
        float elapsedTime = 0;
        
        while (elapsedTime < animationDuration) {
            elapsedTime += Time.deltaTime;
            var t = Mathf.Clamp01(elapsedTime / animationDuration);

            canvasGroup.alpha = forward ? 
                Mathf.Lerp(0,1, animationDuration) : 
                Mathf.Lerp(1,0, animationDuration);
            
            yield return null;
        }

        canvasGroup.alpha = forward ? 1 : 0;
    }
}
