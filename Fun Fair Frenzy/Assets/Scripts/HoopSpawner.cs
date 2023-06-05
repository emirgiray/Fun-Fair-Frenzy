using HurricaneVR.Framework.Core;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class HoopSpawner : MonoBehaviour
{
    [SerializeField] TMP_Text ScoreText;
    [SerializeField] GameObject Hoop;
    [SerializeField] GameObject HoopSwanPoint;
    [SerializeField] int spawnLimit = 3;
    List<GameObject> spawnedHoops = new List<GameObject>();
    int spawned;
    int spawnIndex = 0;
    bool gameActive = true;
    void Start()
    {
        //ScoreText = GameObject.Find("Hoop Score").GetComponent<TMP_Text>();       
    }


    void Update()
    {

    }
    public void SpawnHoop()
    {
        if (/*gameActive &&*/ spawned <= spawnLimit)
        {
            spawnedHoops.Add(null);
            
            spawnedHoops[spawnIndex] = Instantiate(Hoop, HoopSwanPoint.transform.position, Quaternion.identity);
            spawned++;
            spawnIndex++; //reset them!!!
        }
    }
    public void ReseteGame()
    {
        //gameActive = false;
        for (int i = 0; i < spawned; i++)
        {
            Destroy(spawnedHoops[i]);
            spawnedHoops[i] = null;
        }
        spawnIndex = 0;
        spawned = 0;
        ScoreText.text = ("0");
        spawnedHoops.Clear();

        //if (!gameActive)
        //{
        //    gameActive = true;
        //}
        //else
        //{
        //    gameActive = false;
        //    for (int i = 0; i < spawned; i++)
        //    {
        //        Destroy(spawnedHoops[i]);
        //        spawnedHoops[i] = null;
        //    }
        //    spawnIndex = 0;
        //    spawned = 0;
        //}

    }
}
