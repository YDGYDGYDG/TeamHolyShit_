﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainUIbgm : MonoBehaviour
{

    public static MainUIbgm Instance;

    // Start is called before the first frame update
    void Start()
    {
        if(Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "LavaStage1")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "LavaStage2")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "LavaStage3")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "LavaStage4")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "WaterPlanet1")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "WaterPlanet2")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "WaterPlanet3")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "WaterPlanet4")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "WaterPlanet5")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "TutorialStage1")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "TutorialStage2")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "TutorialStage3")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "TutorialStage4")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "TutorialStage5")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "InfinityStorm4-1")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "InfinityStorm4-2")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "InfinityStorm4-3")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "InfinityStorm4-4")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "InfinityStorm4-5")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "MachineryStage0")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "MachineryStage1")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "MachineryStage2")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "MachineryStage3")
        {
            Destroy(this.gameObject);
        }

        else if (SceneManager.GetActiveScene().name == "MachineryStage4")
        {
            Destroy(this.gameObject);
        }
    }
}