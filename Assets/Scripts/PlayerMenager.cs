using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMenager : MonoBehaviour
{
    #region Singleton
    public static PlayerMenager playerMenager;

    private void Awake()
    {
        playerMenager = this;
    }

    #endregion

    public GameObject player;

    public void DiePlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
