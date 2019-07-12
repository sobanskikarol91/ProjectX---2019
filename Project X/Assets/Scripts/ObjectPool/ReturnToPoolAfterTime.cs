﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ReturnToPoolAfterTime : ReturnToPool
{
    [SerializeField] float timeToReturn = 1f;

    private float timeLeft;


    private void Update()
    {
        timeLeft -= Time.deltaTime;

        if (timeLeft <= 0)
            ObjectPoolManager.instance.ReturnToPool(gameObject);
    }

    private void OnEnable()
    {
        timeLeft = timeToReturn;
    }
}