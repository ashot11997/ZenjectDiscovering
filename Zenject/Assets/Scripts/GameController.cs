using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameController : MonoBehaviour
{
    public bool CanMove;

    [Inject] private TimeController TimeController;
    [Inject] private UnitPosController PosController;
    [Inject] private UIController UIController;
    [Inject] private GameObject FinishPrefab;
    [Inject] private GameConfig GameConfig;
    [Inject] private OpponentController.OpponentFabric OpponentFabric;
    [Inject] private PlayerController.PlayerFabric PlayerFabric;
    [Inject] private PlayerWonSignal PlayerWonSignal;
    [Inject] private OpponentWonSignal OpponentWonSignal;

    public Transform OpponentsContainer;

    private GameObject Player;
    private GameObject[] Opponents;

    private string PlayerCondition;

    private GameObject FinishLine;

    private void Start()
    {
        UIController.HideGamePanel();
        PlayerWonSignal.PlayerWonAction += PlayerWon;
        OpponentWonSignal.OpponentWonAction += OpponentWon;
    }

    public void PlayerWon() {
        Debug.Log("Player Won");
        PlayerCondition = "You Won!";
        TimeController.PauseOn();
        OnGameEnd();
    }

    public void OpponentWon()
    {
        Debug.Log("Opponent Won");
        PlayerCondition = "Opponent Won!";
        TimeController.PauseOn();
        OnGameEnd();
    }

    public void OnGameEnd() {
        CanMove = false;
        UIController.ShowMenuPanel();
        UIController.SetTitle(PlayerCondition);
        UIController.HideGamePanel();

        Opponents = null;
        foreach (Transform item in OpponentsContainer)
        {
            Destroy(item.gameObject);
        }

        Destroy(Player);
        Destroy(FinishLine);
    }

    void CreateFinish() {
        FinishLine = GameObject.Instantiate(FinishPrefab, GameConfig.FinishPos, Quaternion.identity);
    }

    void CreateOpponents() {
        if (Opponents == null)
        {
            Opponents = new GameObject[GameConfig.OpponentsCount];

            for (int i = 0; i < GameConfig.OpponentsCount; i++)
            {
                Opponents[i] = OpponentFabric.Create(Random.Range(GameConfig.OpponentsMinSpeed, GameConfig.OpponentsMaxSpeed), GameConfig.FinishPos.y, this).gameObject;
                Opponents[i].transform.parent = OpponentsContainer;
            }
        }

        for (int i = 0; i < GameConfig.OpponentsCount; i++)
        {
            Opponents[i].transform.position = PosController.GetNewPos();
        }
    }

    void CreatePlayer()
    {
        if (Player == null)
        {
            Player = PlayerFabric.Create(GameConfig.PlayerSpeed, GameConfig.FinishPos.y, this).gameObject;
        }
        Player.transform.position = PosController.GetNewPos();
    }

    public void Play()
    {
        CanMove = true;
        PosController.Reset();
        TimeController.PauseOff();
        UIController.HideMenuPanel();
        UIController.ShowGamePanel();
        CreateFinish();
        CreatePlayer();
        CreateOpponents();
    }

    public void Restart()
    {
        UIController.ShowMenuPanel();
        UIController.HideGamePanel();
    }

    public void Exit()
    {
        Application.Quit();
    }
}
