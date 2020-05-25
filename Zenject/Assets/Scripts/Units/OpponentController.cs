using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class OpponentController : AbstractUnits
{
    [Inject] private OpponentWonSignal OpponentWonSignal;

    public bool IsOneTime = false;
    

    protected override void Move() {
        transform.Translate(Vector3.right * Speed * Time.deltaTime);

        if (transform.position.y > FinishPos)
        {
            if (!IsOneTime)
            {
                Debug.Log("You Lose");
                OpponentWonSignal.OpponentWonAction.Invoke();
            }
            IsOneTime = false;
        }
    }

    public class OpponentFabric : Factory<float, float, GameController, OpponentController> {

    }
}
