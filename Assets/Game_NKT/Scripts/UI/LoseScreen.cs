using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseScreen : UICanvas
{
    public void BackToHomeButton()
    {
        GameManager.Ins.IsPlayGame= false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
