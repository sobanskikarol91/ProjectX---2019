﻿using System;
using UnityEngine;

public class LevelManager : MonoBehaviour, IScore, IRestart
{
    public float NextLvlValue => settings.Lvls[lvlNr + 1];
    public float PreviousLvlValue => settings.Lvls[lvlNr];
    [SerializeField] LvlSettings settings;
    [SerializeField] AudioClip gainLvlSnd;

    private int lvlNr = 0;
    private float expierience = 0;
    private IDependsOnLvl[] lvlDependencies;
    private AudioSource audioSource;

    private void Awake()
    {
        lvlDependencies = GetComponents<IDependsOnLvl>();
        audioSource = AudioSourceFactory.GetAudioSource(transform, gainLvlSnd);
    }

    bool IsPlayerReachedNewLvl()
    {
        return expierience >= NextLvlValue;
    }

    void IncreaseLvl()
    {
        lvlNr++;
        Array.ForEach(lvlDependencies, l => l.OnGainNextLvl(lvlNr));
        audioSource.Play();
    }

    public bool IsLastLvl()
    {
        return lvlNr == settings.MaxLvl - 1;
    }

    public void UpdatedScore(float score)
    {
        expierience = score;

        if (IsLastLvl())
            return;
        else if (IsPlayerReachedNewLvl())
            IncreaseLvl();
    }

    public void OnRestart()
    {
        expierience = lvlNr = 0;
    }
}