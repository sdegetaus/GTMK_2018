using System;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public abstract class ObjectGroup<Type, GroupEnum> : MonoBehaviour
        where Type : Component
        where GroupEnum : Enum
    {
        [SerializeField]
        protected List<Type> objects = new List<Type>();

        [SerializeField]
        protected GroupEnum activeObject;

        // Private Variables
        protected FloatVariable speed = null;
        protected FloatVariable lerpSpeed = null;

        public virtual void Initialize()
        {
            speed = Assets.Instance.Speed;
            lerpSpeed = Assets.Instance.LerpSpeed;
            UnactivateAll();
            RandomObstacle();
        }

        protected void FixedUpdate()
        {
            if (!GameManager.CanReadInput) return;
            transform.position = Vector3.Lerp(
                a: transform.position,
                b: transform.position.With(x: transform.position.x - speed.value),
                t: Time.fixedDeltaTime * lerpSpeed.value
            );
        }

        public void UnsetActiveItem(GroupEnum item)
        {
            int enumToInt = (int)Enum.Parse(typeof(GroupEnum), item.ToString());
            objects[enumToInt].gameObject.SetActive(false);
        }

        protected void SetActiveItem(GroupEnum item)
        {
            int enumToInt = (int)Enum.Parse(typeof(GroupEnum), item.ToString());
            objects[enumToInt].gameObject.SetActive(true);
            activeObject = item;
        }

        protected void RandomObstacle()
        {
            SetActiveItem(Utilities.GetRandomEnum<GroupEnum>());
        }

        protected void UnactivateAll()
        {
            foreach (Type item in objects)
                item.gameObject.SetActive(false);
        }
    }

}
