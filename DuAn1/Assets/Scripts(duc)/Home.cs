using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class Home : MonoBehaviour
{
    private VisualElement homeElement;
    private VisualElement quitElement;
    // Start is called before the first frame update
    void Start()
    {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;
        homeElement = root.Q<VisualElement>("home");        
        homeElement.style.display = DisplayStyle.Flex;
        Button Play = root.Q<Button>("play");
        Play.RegisterCallback<ClickEvent>(playgame);
        Button Exit = root.Q<Button>("exit");
        Exit.RegisterCallback<ClickEvent>(exit);
        quitElement = root.Q<VisualElement>("quit");
        Button Yes = root.Q<Button>("yes");
        Yes.RegisterCallback<ClickEvent>(yes);
        Button No = root.Q<Button>("no");
        No.RegisterCallback<ClickEvent>(no);
    }
    private void playgame(ClickEvent cke)
    {
        SceneManager.LoadScene("Map1(duc)");
    }
    private void exit(ClickEvent cke)
    {
        quitElement.style.display = DisplayStyle.Flex;
    }
    private void yes(ClickEvent cke)
    {
        
    }
    private void no(ClickEvent cke)
    {
        quitElement.style.display = DisplayStyle.None;
    }
}
