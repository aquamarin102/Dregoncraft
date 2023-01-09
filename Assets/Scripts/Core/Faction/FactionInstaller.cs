using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FactionInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<FactionControlModel>().AsSingle();
    }
}
