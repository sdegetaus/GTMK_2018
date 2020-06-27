using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace GMTK
{
    public abstract class SpawnGroup<Type, ObjectEnum> : MonoBehaviour
        where Type : Component
        where ObjectEnum : Enum
    {
        [SerializeField]
        protected ObjectEnum activeObject;

        // Private Variables
        protected List<Type> objects;
        protected FloatVariable speed = null;
        protected FloatVariable lerpSpeed = null;

        public virtual void Initialize()
        {
            if (objects is null || objects.Count == 0)
                objects = gameObject.GetComponentsInChildren<Type>(true).ToList();

            speed = Assets.Instance.Speed;
            lerpSpeed = Assets.Instance.LerpSpeed;
            UnactivateAll();
            ActivateRandom();
        }

        private void OnDisable()
        {
            Debug.Log("Disabled!");
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

        protected void ActivateItem(ObjectEnum item)
        {
            int enumToInt = (int)Enum.Parse(typeof(ObjectEnum), item.ToString());
            objects[enumToInt].gameObject.SetActive(true);
            activeObject = item;
        }

        public void DeactivateItem(ObjectEnum item)
        {
            int enumToInt = (int)Enum.Parse(typeof(ObjectEnum), item.ToString());
            objects[enumToInt].gameObject.SetActive(false);
        }

        protected void ActivateRandom()
        {
            ActivateItem(Utilities.GetRandomEnum<ObjectEnum>());
        }

        protected void UnactivateAll()
        {
            foreach (Type item in objects)
                item.gameObject.SetActive(false);
        }
    }
}