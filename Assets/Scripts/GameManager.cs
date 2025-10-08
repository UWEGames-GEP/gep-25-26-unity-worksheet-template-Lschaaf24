using UnityEditor.Rendering;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    private bool hasChangedState = false;

    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    void Update()
    {
        //Switch Statements

        switch (state)
        {
            case GameState.GAMEPLAY:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = GameState.PAUSE;
                    hasChangedState = true;
                }
                break;

            case GameState.PAUSE:
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    state = GameState.GAMEPLAY;
                    hasChangedState = true;
                }
                break;
        }

        //If Statements

        // if (state == GameState.GAMEPLAY)
        // {
        //     if (Input.GetKeyDown(KeyCode.Escape))
        //     {
        //         state = GameState.PAUSE;
        //         hasChangedState = true;
        //     }
        // }
        // else if (state == GameState.PAUSE)
        // {
        //     if (Input.GetKeyDown(KeyCode.Escape))
        //     {
        //         state = GameState.GAMEPLAY;
        //         hasChangedState = true;
        //     }
        // }
    }

    void LateUpdate()
    {
        //Switch Statements

        if (hasChangedState)
        {
            hasChangedState = false; 
            switch (state)
            {
                case GameState.GAMEPLAY:
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Time.timeScale = 1.0f;
                    }
                    break;

                case GameState.PAUSE:
                    if (Input.GetKeyDown(KeyCode.Escape))
                    {
                        Time.timeScale = 0.0f;
                    }
                    break;
            }

        }

        //If Statements

        // if (hasChangedState)
        // {
        //     hasChangedState = false;
        //     if (state == GameState.GAMEPLAY)
        //     {
        //         Time.timeScale = 1.0f;
        //     }
        //     else if (state == GameState.PAUSE)
        //     {
        //         Time.timeScale = 0.0f;
        //     }
        // }
    }
}

public enum GameState
{
    GAMEPLAY,
    PAUSE, 
}
