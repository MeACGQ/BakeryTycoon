using JetBrains.Annotations;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ProcessBar : MonoBehaviour
{
    public Image barImage;

    private void Start()
    {
        barImage.fillAmount = 0f;
    }

    public void StartFill(float _fillTime)
    {
        StartCoroutine(FillBarForSeconds(_fillTime));
    }

    private IEnumerator FillBarForSeconds(float _fillTime)
    {
        float elapsedTime = 0f;
        
        while (elapsedTime < _fillTime)
        {
            elapsedTime += Time.deltaTime;

            barImage.fillAmount = elapsedTime / _fillTime;

            yield return null;
        }

        barImage.fillAmount = 0f;
    }
}