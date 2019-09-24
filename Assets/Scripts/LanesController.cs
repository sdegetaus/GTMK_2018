using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LanesController : MonoBehaviour {

    private void Start() {
        //SpawnLanes();
    }

    private void SpawnLanes() {
        //pooler.InitializePool(() => {
        //    for (int i = 0; i < Consts.totalLanes; i++) {
        //        GameObject lane = pooler.Spawn(PoolTag.Arrows,
        //            new Vector3(Consts.laneGroupStartingPosition + (Consts.laneGroupSeparation * i), 0.0f)
        //        );
        //        lane.AddComponent(typeof(ObstacleMover));
        //    }
        //});
    }

    public void SpawnToBack() {
        //pooler.Spawn(PoolTag.Arrows, new Vector3(Consts.laneGroupSeparation, 0.0f));
    }

}