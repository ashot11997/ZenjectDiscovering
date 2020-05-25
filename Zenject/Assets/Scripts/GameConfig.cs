using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameConfig", menuName = "Create Game Config")]
public class GameConfig : ScriptableObject
{
    public int OpponentsCount;
    public int OpponentsMinSpeed;
    public int OpponentsMaxSpeed;

    public float PlayerSpeed;
    public float DistanceBetweenOpponents;

    public Vector3 StartPos;
    public Vector3 FinishPos;

    public GameObject PlayerPrefab;
    public GameObject OpponentPrefab;
}
