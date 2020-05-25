﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeController
{
    public void PauseOn() {
        Time.timeScale = 0f;
    }

    public void PauseOff()
    {
        Time.timeScale = 1f;
    }
}
