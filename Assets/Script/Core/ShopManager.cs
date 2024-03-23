using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopManager : MonoBehaviour
{
    public GameObject ShopUI;
    public GameObject PlayerUI;
    public void GoMain()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
