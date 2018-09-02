using UnityEngine;

namespace XXXGame.Gameplay {
    public enum TranslationDir {Left, Right, Up, Down}

    public partial class PlayerController : MonoBehaviour {

        public static PlayerController instance;
        public bool selectionMade;
       
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
            selectionMade = false;
            placeEvent += PlaceSelection;
        }
        private void Update()
        {

            if (Input.GetKeyDown(KeyCode.Alpha6) && !selectionMade)
            {
                //Selecting the Spring
                if (selectionEvent != null)
                    selectionEvent(6);
                MakeSelection();
            }
            if (Input.GetKeyDown(KeyCode.Alpha1) && !selectionMade)
            {
                if (selectionEvent != null)
                    selectionEvent(1);
                MakeSelection();
            }
            if (Input.GetKeyDown(KeyCode.Alpha2) && !selectionMade)
            {
                if (selectionEvent != null)
                    selectionEvent(2);
                MakeSelection();
            }
            if (Input.GetKeyDown(KeyCode.Alpha3) && !selectionMade)
            {
                if (selectionEvent != null)
                    selectionEvent(3);
                MakeSelection();
            }
            if (Input.GetKeyDown(KeyCode.Alpha4) && !selectionMade)
            {
                if (selectionEvent != null)
                    selectionEvent(4);
                MakeSelection();
            }
            if (Input.GetKeyDown(KeyCode.Alpha5) && !selectionMade)
            {
                if (selectionEvent != null)
                    selectionEvent(5);
                MakeSelection();
            }

            if (Input.GetKeyDown(KeyCode.Return))
            {
                if(placeEvent != null)
                    placeEvent();
            }

            if (translationEvent != null)
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

        public void MakeSelection()
        {
            selectionMade = true;
        }
        public void PlaceSelection()
        {
            selectionMade = false;
        }
        public void ResetEvents() {
            if(placeEvent != null) {
                placeEvent();
            }
            placeEvent = null;
            selectionEvent = null;
            translationEvent = null;
        }

    }
    
}