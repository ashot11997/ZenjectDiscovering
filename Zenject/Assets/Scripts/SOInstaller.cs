using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

[CreateAssetMenu(fileName = "SOInstaller", menuName = "Create SOInstaller")]
public class SOInstaller : ScriptableObjectInstaller
{
    [SerializeField] private GameConfig GameConfig;

    [SerializeField] private GameObject FinishPrefab;

    public override void InstallBindings()
    {
        Container.BindInstance(GameConfig);
        Container.BindInstance(FinishPrefab);
    }
}
