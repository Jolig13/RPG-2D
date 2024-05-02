using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainManager : MonoBehaviour
{
    [SerializeField] private ParticleSystem rainEffect;
    [SerializeField] private float minIntensity;
    [SerializeField] private float maxIntensity;

    [SerializeField] private float minTimeRain;
    [SerializeField] private float maxTimeRain;

    [SerializeField] private float minRainDelay;
    [SerializeField] private float maxRainDelay;

    private void Start() 
    {
       StartCoroutine(Rain());
    }

    private IEnumerator Rain()
    {   

        yield return new WaitForSeconds (Random.Range(minRainDelay,maxRainDelay));

        while (true)
        {
            rainEffect.Play();

            float intensity = Random.Range(minIntensity,maxIntensity);
            var  rainEmission = rainEffect.emission;
            rainEmission.rateOverTime = intensity;

            yield return new WaitForSeconds (Random.Range(minTimeRain,maxTimeRain));

            rainEffect.Stop();
            yield return new WaitForSeconds (Random.Range(minRainDelay,maxRainDelay));
        }
    }
}

