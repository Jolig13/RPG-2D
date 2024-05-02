using System.Collections;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class DayNightManager : MonoBehaviour
{
    [SerializeField] private Gradient lightGradient;
    [SerializeField] private float dayDuration;
    [SerializeField] private Light2D light2D;
    private float min;
    private float normalTime;
    private float dayTime = 0.3f;
    private float nightTime = 0.8f;


    private void Awake() 
    {
        min = dayTime * dayDuration;
        StartCoroutine(DayNight());   
    }

    IEnumerator DayNight()
    {
        while (true)
        {
            min += 1 * Time.deltaTime;
            if (min >= dayDuration)
            {
                min = 0f;
            }

            normalTime = min/dayDuration;

            if(normalTime >= dayTime && normalTime < nightTime)
            {
                Debug.Log("Es de DIA");
            }         
            else
            {
                Debug.Log("Es de NOCHE");
            }
            

            light2D.color = lightGradient.Evaluate(normalTime);

            yield return null;
        }
    }   
}
