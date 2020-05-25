using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameInstaller : MonoInstaller
{
    [Inject] GameConfig GameConfig;

    public override void InstallBindings()
    {
        Container.Bind<TimeController>().AsSingle();
        Container.Bind<UnitPosController>().AsSingle();

        Container.BindFactory<float, float, GameController, PlayerController, PlayerController.PlayerFabric>().FromComponentInNewPrefab(GameConfig.PlayerPrefab);
        Container.BindFactory<float, float, GameController, OpponentController, OpponentController.OpponentFabric>().FromComponentInNewPrefab(GameConfig.OpponentPrefab);

        Container.Bind<PlayerWonSignal>().AsSingle();
        Container.Bind<OpponentWonSignal>().AsSingle();
    }
}
