using UnityEngine;
using System.Collections;

public enum GameState
{
    STATE_IDLE,
    STATE_WAIT_FALL,
    STATE_FALL,
    STATE_WAIT_UNWRAP,
    STATE_UNWRAP,
    STATE_CALCULATE_SCORE
}

public class GameManager : MonoBehaviour {

    public static GameManager Instance;

    public GameState state;

    void Awake()
    {
        if (Instance != null)
        {
            Debug.LogError("Multiple Instance of GameManager");
        }
        else
        {
            Instance = this;
        }
    }

    // Use this for initialization
    void Start () {
        state = GameState.STATE_WAIT_FALL;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
