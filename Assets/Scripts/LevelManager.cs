using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{

    [SerializeField] private GameObject platform;
    [SerializeField] private float distanceBetweenPlatforms = 0.35f;
    [SerializeField] private Transform centerPillar;
    [SerializeField] private Transform finishLine;
    [SerializeField] private float levelMinLength = 10f;
    [SerializeField] private float levelMaxLength = 20f;
    [SerializeField] private Material normalMat;
    [SerializeField] private Material damageMat;


    void Start()
    {
        Initialize();
    }
    void Initialize()
    {
        float levelLength = Random.Range(levelMinLength, levelMaxLength);

        int numberOfPlatforms = Mathf.CeilToInt(levelLength / distanceBetweenPlatforms);

        levelLength = numberOfPlatforms * distanceBetweenPlatforms;

        centerPillar.localScale = new Vector3(1, levelLength + 1, 1);

        finishLine.position = new Vector3(0, -levelLength, 0);

        for(int i = 0; i < numberOfPlatforms; i++)
        {
           GameObject p = Instantiate(platform, new Vector3(0, -distanceBetweenPlatforms * i, 0), Quaternion.identity);
           Platform platformScript = p.GetComponent<Platform>();
            List<int> allTileIndecies = new List<int>(9) { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            List<int> damageTileIndecies = new List<int>();

            int damageTilesCount = Random.Range(0, 5);

            for(int j = 0; j < damageTilesCount; j++)
            {
                int randomIndex = Random.Range(0, allTileIndecies.Count);

                damageTileIndecies.Add(allTileIndecies[randomIndex]);

                allTileIndecies.RemoveAt(randomIndex);
            }

            platformScript.Initialize(damageTileIndecies, normalMat, damageMat);
        }
    }
}
