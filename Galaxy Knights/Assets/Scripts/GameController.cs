﻿using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public GameObject hazard;
    public GameObject hazard2;
    public Vector3 spawnValues;
    public int hazardCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    public GUIText scoreText;
    public GUITexture gameOverText;
    public GUITexture restartText;
    public AudioSource LevelMusic;
    public AudioClip EndMusic;

    private bool gameOver;
    private bool restart;
    private int score;


    void Start()
    {
        score = 0;
        UpdateScore();
        gameOverText.enabled = false;
        restartText.enabled = false;
        StartCoroutine (SpawnWaves());
    }

    void Update()
    {
        if (restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel(Application.loadedLevel);
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("Menu");
            }
        }
    }


    IEnumerator SpawnWaves()
    {
        yield return new WaitForSeconds(startWait);
        while (true)
        {
            for (int i = 0; i < hazardCount; i++)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(hazard, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
            yield return new WaitForSeconds(waveWait);

            if (gameOver)
            {
                restartText.enabled = true;
                restart = true;
                break;
            }
        }

    }

    public void AddScore (int NewScoreValue)
    {
        score += NewScoreValue;
        UpdateScore();
    }

    void UpdateScore()
    {
        scoreText.text = "" + score;
    }

    public void GameOver ()
    {
        gameOverText.enabled = true;
        gameOver = true;
        Destroy(LevelMusic);
        AudioSource.PlayClipAtPoint(EndMusic, transform.position);
    }
}