using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering;

public class CarGenerator : MonoBehaviour
{
    [SerializeField] GameObject carPrefab;
    [SerializeField] int numMinCars, numMaxCars;
    [SerializeField] float delayMin , delayMax;

    private void Start()
    {
        StartCoroutine(GenerateCar(numMinCars,numMaxCars,delayMin,delayMax));
    }

    IEnumerator GenerateCar(int minCar, int maxCar, float minDelay, float maxDelay )
    {
        int numberCars;
        float delay;
        
        while(true)
        {
             numberCars = Random.Range(minCar,maxCar);
             delay = Random.Range(minDelay, maxDelay);
            
            for(int i = 0; i < numberCars; i++)
            {
                yield return new WaitForSeconds(delay);
                Instantiate(carPrefab, transform.position, transform.localRotation);
            }
            
            
        }
        
    }

}
