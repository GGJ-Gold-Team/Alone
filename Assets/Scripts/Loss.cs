using UnityEngine;
using UnityEngine.SceneManagement;

public class Loss : MonoBehaviour {
    void Update() {
        if (Input.GetButtonDown("Interaction")) {
            SceneManager.LoadScene("Game");
        } else if (Input.GetButtonDown("Cancel")) {
            Application.Quit();
        }
    }
}
