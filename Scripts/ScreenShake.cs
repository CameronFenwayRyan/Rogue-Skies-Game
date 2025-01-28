using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float shakeDuration;
    public float shakeMagnitude = 1000f;
    public float dampingSpeed = 1.0f;

    private Vector3 initialPosition;
    public bool stopScreenShake;

    void OnEnable()
    {
        initialPosition = transform.localPosition;
    }

    void Update()
    {
        if (shakeDuration > 0 && stopScreenShake == false)
        {
            transform.localPosition = initialPosition + Random.insideUnitSphere.normalized * shakeMagnitude * Time.timeScale;

            shakeDuration -= Time.deltaTime * dampingSpeed * Time.timeScale;
        }
        else
        {
            shakeDuration = 0f;
            transform.localPosition = initialPosition;
        }
    }

    public void TriggerShake()
    {
        shakeDuration = 0.2f;
    }
}
