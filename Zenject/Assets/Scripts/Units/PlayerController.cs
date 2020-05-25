using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : AbstractUnits
{

    [Inject] private PlayerWonSignal PlayerWonSignal;

    public bool IsOneTime = false;
    

    protected override void Move()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);

            if (transform.position.y > FinishPos)
            {
                if (!IsOneTime)
                {
                    PlayerWonSignal.PlayerWonAction.Invoke();
                    Debug.Log("You Win");
                }
                IsOneTime = false;
            }
        }
    }

    public class PlayerFabric : Factory<float, float, GameController, PlayerController>
    {

    }
}
