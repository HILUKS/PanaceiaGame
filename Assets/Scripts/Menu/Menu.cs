using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    void Awake()
    {
        StartCoroutine("PlayGame");
    }
    IEnumerator PlayGame()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene(1);
        StopCoroutine("PlayGame");
    }
 }
