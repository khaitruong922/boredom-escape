#pragma warning disable 0649

using UnityEngine;
using UnityEngine.SceneManagement;
public class GameQuitter : MonoBehaviour
{
    public static void Quit()
    {
        Debug.Log("Quitted");
        Application.Quit();
    }
}

