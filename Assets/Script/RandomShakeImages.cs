using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomShakeImages : MonoBehaviour
{
    public List<Image> imagesToShake; // 将需要抖动的Image拖入这里
    public float shakeDuration = 0.5f; // 每次抖动的持续时间
    public float shakeIntensity = 10f; // 抖动强度
    public float shakeInterval = 1f; // 每次抖动的间隔时间

    private List<Vector3> originalPositions = new List<Vector3>();

    void Start()
    {
        // 保存每个Image的原始位置
        foreach (var image in imagesToShake)
        {
            originalPositions.Add(image.rectTransform.localPosition);
        }

        // 开始随机抖动协程
        StartCoroutine(RandomShake());
    }

    IEnumerator RandomShake()
    {
        while (true)
        {
            // 随机选择一个Image进行抖动
            int randomIndex = Random.Range(0, imagesToShake.Count);
            StartCoroutine(ShakeImage(imagesToShake[randomIndex], randomIndex));

            // 等待一段时间后再触发下一次抖动
            yield return new WaitForSeconds(shakeInterval);
        }
    }

    IEnumerator ShakeImage(Image image, int index)
    {
        RectTransform rectTransform = image.rectTransform;
        Vector3 originalPosition = originalPositions[index];

        float elapsedTime = 0f;

        while (elapsedTime < shakeDuration)
        {
            // 随机生成一个偏移量
            float offsetX = Random.Range(-shakeIntensity, shakeIntensity);
            float offsetY = Random.Range(-shakeIntensity, shakeIntensity);

            // 应用偏移量
            rectTransform.localPosition = originalPosition + new Vector3(offsetX, offsetY, 0);

            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // 恢复到原始位置
        rectTransform.localPosition = originalPosition;
    }
}
