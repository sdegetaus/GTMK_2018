using UnityEngine;

 /// <summary>
 /// InputController: singleton class which interprates the input and passes it on. 
 /// </summary>
public class InputController : MonoBehaviour {

    static public InputController instance;

    public void Awake() {
        instance = this;
    }

}

