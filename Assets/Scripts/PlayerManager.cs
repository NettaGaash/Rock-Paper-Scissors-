using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField]
    private PlayableCharacter[] players;

    private int ActivePlayerIndex = 0;

    private void Start()
    {
        // Activate player index 0 on start of game
        for (int i = 0; i < players.Length; i++)
        {
            players[i].gameObject.SetActive(i == ActivePlayerIndex);
        }

    }

    // Switching between players

    public void SwitchPlayer()
    {
        players[ActivePlayerIndex].gameObject.SetActive(false);
        Vector3 playerPosition = players[ActivePlayerIndex].transform.position;
        ActivePlayerIndex++;
        ActivePlayerIndex %= players.Length;
        players[ActivePlayerIndex].transform.position = playerPosition;
        players[ActivePlayerIndex].gameObject.SetActive(true);

    }

}

