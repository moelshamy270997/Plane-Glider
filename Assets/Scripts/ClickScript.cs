using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System.Threading;

public class ClickScript : MonoBehaviour, IPointerClickHandler
{
    AudioScript audioScript;


    void Start()
    {
        audioScript = GameObject.Find("AudioObject").GetComponent<AudioScript>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        string sceneName = eventData.pointerPress.gameObject.name;
        audioScript.PlaySFX();
        Thread.Sleep(500);
        if (sceneName == "LevelOneImage")
            SceneManager.LoadScene("FirstLevelScene", LoadSceneMode.Single);
        else
            SceneManager.LoadScene("SecondLevelScene", LoadSceneMode.Single);

    }
}
