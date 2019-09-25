using System;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseGroup<Type, GroupEnum> : MonoBehaviour
    where Type : Component
    where GroupEnum : Enum
    {

    [SerializeField]
    protected List<Type> objects = new List<Type>();

    [SerializeField]
    protected GroupEnum activeObject;

    [Space]

    [SerializeField]
    protected FloatVariable globalSpeed = null;

    protected void Update() {

        if (!GameManager.IsRunPlaying) return;

        transform.position = transform.position.With(
            x: transform.position.x + globalSpeed.value * Time.deltaTime
        );
    }

    public virtual void Init() {
        UnactivateAll();
        SetRandomObstacle();
    }

    public void UnsetActiveItem(GroupEnum item) {
        int enumToInt = (int)Enum.Parse(typeof(GroupEnum), item.ToString());
        objects[enumToInt].gameObject.SetActive(false);
    }

    protected void SetActiveItem(GroupEnum item) {
        int enumToInt = (int)Enum.Parse(typeof(GroupEnum), item.ToString());
        objects[enumToInt].gameObject.SetActive(true);
        activeObject = item;
    }

    protected void SetRandomObstacle() {
        SetActiveItem(Helper.GetRandomEnum<GroupEnum>());
    }

    protected void UnactivateAll() {
        foreach (Type item in objects) {
            item.gameObject.SetActive(false);
        }
    }
}
