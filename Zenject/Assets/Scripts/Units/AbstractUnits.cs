using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class AbstractUnits : MonoBehaviour
{
    [Inject] protected float Speed;
    [Inject] protected float FinishPos;

    [Inject] protected GameController GameController;

    void Update()
    {
        if (GameController.CanMove)
        {
            Move();
        }
    }

    protected virtual void Move() {

    }
}
