using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    private VisualElement homeElement;
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        homeElement = root.Q<VisualElement>("home");
        homeElement.style.display = DisplayStyle.Flex;
        Button Replay = root.Q<Button>("replay");
        Replay.RegisterCallback<ClickEvent>(replay);
        Button Exit = root.Q<Button>("exit");
        Exit.RegisterCallback<ClickEvent>(exit);
    }
    private void replay(ClickEvent cke)
    {
        SceneManager.LoadScene("Map1(duc)");
    }
    private void exit(ClickEvent cke)
    {
        SceneManager.LoadScene("Home(duc)1");
    }
}
