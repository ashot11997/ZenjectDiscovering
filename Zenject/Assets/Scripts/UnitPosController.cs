using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UnitPosController
{
    [Inject] GameConfig GameConfig;

    private int PosCounter;

    public Vector3 GetNewPos() {
        PosCounter++;
        return GameConfig.StartPos + new Vector3(PosCounter * GameConfig.DistanceBetweenOpponents, 0, 0);
    }

    public void Reset() {
        PosCounter = 0;
    }
}
