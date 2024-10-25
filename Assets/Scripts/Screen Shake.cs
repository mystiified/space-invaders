using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    //Variabler
    public float cameraShakeFrequency;
    public float cameraShakeDuration;
    public float cameraShakeMaxAngle;
    public float cameraMagnitudeForXY;
    void Start()
    {
        StartCoroutine(keepShaking());
    }

    

    public IEnumerator keepShaking()
    {
        while (true)
        {

            cameraShake(cameraShakeFrequency, cameraShakeDuration, cameraShakeMaxAngle, cameraMagnitudeForXY);
            yield return new WaitForSeconds(0f);

        }
    }

    public void cameraShake (float cameraShakeFrequency, float cameraShakeDuration, float cameraShakeMaxAngle, float cameraMagnitudeForXY)
    {
        if (GameManager.Instance.playerHit == true)
        {
            StartCoroutine(Shake(cameraShakeFrequency, cameraShakeDuration, cameraShakeMaxAngle, cameraMagnitudeForXY));
            GameManager.Instance.playerHit = false;
        }
    }

    //Seeds för shake värdena, perlin noise
    public IEnumerator Shake(float cameraShakeFrequency, float cameraShakeDuration, float cameraShakeMaxAngle, float cameraMagnitudeForXY)
    {
        float elapsed = 0.0f;

        Vector3 originalCamPos = Camera.main.transform.position;

        while (elapsed < cameraShakeDuration)
        {
            elapsed += Time.deltaTime;

            float percentComplete = elapsed / cameraShakeDuration;
            float damper = 1.0f - Mathf.Clamp(4.0f * percentComplete - 3.0f, 0.0f, 1.0f);

            float seed1 = Random.Range(0.5f, 1f) * Time.time * cameraShakeFrequency;
            float seed2 = Random.Range(0.5f, 1f) * Time.time * cameraShakeFrequency;
            float seed3 = Random.Range(0.5f, 1f) * Time.time * cameraShakeFrequency;

            float x = Mathf.PerlinNoise(seed1, 0f) * 2.0f - 1.0f;
            float y = Mathf.PerlinNoise(0f, seed2) * 2.0f - 1.0f;
            float shake = Mathf.PerlinNoise(seed3, 0f) * 2.0f - 1.0f;

            x += cameraMagnitudeForXY * damper;
            y += cameraMagnitudeForXY * damper;
            shake += cameraShakeMaxAngle * damper;

            Camera.main.transform.localRotation = Quaternion.Euler(0.0f, 0.0f, shake);
            Camera.main.transform.position = originalCamPos + new Vector3(x, y, originalCamPos.z);

            yield return null;
        }

        //Reset:ar kameran efter shake:et
        Camera.main.transform.position = originalCamPos;
        Camera.main.transform.localRotation = Quaternion.identity;
    }
}
