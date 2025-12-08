
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameState state;
    private bool hasChangedState = false;
    [SerializeField]
    private InventoryUI inventory;

    void Start()
    {
        state = GameState.GAMEPLAY;
    }

    void Update()
    {

    }

    public void ChangeGameState()
    {
        //switch the game state and bring up/close player inventory UI
        switch (state)
        {
            case GameState.GAMEPLAY:
               
                state = GameState.PAUSE;
                hasChangedState = true;
                inventory.OpenPlayer();

            break;

            case GameState.PAUSE:
                
                state = GameState.GAMEPLAY;
                hasChangedState = true;
                inventory.Close();

            break; 
        }

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
                    
                    //plays time
                    Time.timeScale = 1.0f;

                break;

                case GameState.PAUSE:
                   
                    //stops time
                    Time.timeScale = 0.0f;
                    
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
