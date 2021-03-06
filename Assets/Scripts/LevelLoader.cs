﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    int delayTime = 3;
    int currentSceneIndex;
    // Start is called before the first frame update
    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        if ( currentSceneIndex == 0)
        {
            StartCoroutine ( WaitAndLoad() );
        }
    }


IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds( delayTime );
        LoadNextScene();
        
    }


    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex +1);
    }
    
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
