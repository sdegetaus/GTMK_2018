using UnityEngine;

namespace XXXGame.Gameplay {
    public enum TranslationDir {Left, Right, Up, Down}

    public partial class PlayerController : MonoBehaviour {

        public static PlayerController instance;
        private bool selectionIsMade;

        #region Observer
        public delegate void SelectObstacle(int selectionMade);
        public static event SelectObstacle selectionEvent;

        public delegate void MoveSelectedObstacle(TranslationDir dir);
        public static event MoveSelectedObstacle translationEvent;

        public delegate void PlaceObstacle();
        public static event PlaceObstacle placeEvent;
        #endregion


        private void Awake() {
            instance = this;
            selectionEvent += SelectionEvent;
            placeEvent += placeEvent;
        }
        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha6))
            {
                //Selecting the Spring
                if (selectionEvent != null)
                    selectionEvent(6);
            }
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                if (selectionEvent != null)
                    selectionEvent(1);
            }
            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                if (selectionEvent != null)
                    selectionEvent(2);
            }
            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                if (selectionEvent != null)
                    selectionEvent(3);
            }
            if (Input.GetKeyDown(KeyCode.Alpha4))
            {
                if (selectionEvent != null)
                    selectionEvent(4);
            }
            if (Input.GetKeyDown(KeyCode.Alpha5))
            {
                if (selectionEvent != null)
                    selectionEvent(5);
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if(placeEvent != null)
                    placeEvent();
            }

            if (selectionIsMade)
            {
                if (Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    translationEvent(TranslationDir.Left);
                }
                if (Input.GetKeyDown(KeyCode.RightArrow))
                {
                    translationEvent(TranslationDir.Right);
                }
                if (Input.GetKeyDown(KeyCode.UpArrow))
                {
                    translationEvent(TranslationDir.Up);
                }
                if (Input.GetKeyDown(KeyCode.DownArrow))
                {
                    translationEvent(TranslationDir.Down);
                }
            }

        }
        public void SelectionEvent(int num)
        {
            selectionIsMade = true;
        }

        public void PlaceEvent()
        {
            selectionIsMade = false;
        }
    }
}