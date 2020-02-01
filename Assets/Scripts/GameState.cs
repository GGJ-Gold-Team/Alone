using UnityEngine;

[System.Serializable]
public class GameState {
    [SerializeField]
    private bool isGameOver = false;

    public bool IsGameOver {
        get {
            return isGameOver;
        }
    }
}