using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackController : MonoBehaviour
{
    public CanvasGroup cnvGroup;
    public GameObject menu;
    public GameObject element;

    Stack<Room> stack;
    List<GameObject> buttons;


    void Start()
    {
        stack = new Stack<Room>();
        buttons = new List<GameObject>();
        for(int i=0;i<4;++i)
        {
            GameObject tmp = Instantiate(element, menu.transform);
            buttons.Add(tmp);
        }
        CreateMenu(new Room());
    }

    void CreateMenu(Room item)
    {
        int i = 0;
        int[] rnd = new int[4];
        Color c = Color.white;
        for (i = 0; i < 4; ++i)
        {
            if (item.doors.Count == 0)
            {
                rnd[i] = UnityEngine.Random.Range(0, 10);
                c = new Color(UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f, UnityEngine.Random.Range(0, 255) / 255f);
                
            }
            else
            {
                rnd[i] = item.doors[i];
                c = item.color;
            }
        }

        Camera.main.backgroundColor = c;

        for (i = 0; i < 4; ++i)
        {
            /* cambiar por setup de escena. prendiendo y apagando los objetos correspondientes */
            buttons[i].GetComponentInChildren<Text>().text = rnd[i].ToString();
            /* cambiar por collision o trigger */
            buttons[i].GetComponent<Button>().onClick.AddListener(() => StartCoroutine(SelectOption(new Room(rnd, c))));
        }
    }

    void CleanMenu()
    {
        for (int i = 0; i < 4; ++i)
        {
            buttons[i].GetComponent<Button>().onClick.RemoveAllListeners();
        }
    }
    // Función Click que corresponde al menú
    public IEnumerator SelectOption(Room item)
    {
        stack.Push(item);

        CleanMenu();
        StartCoroutine(showmenu());

        Debug.Log(string.Format(" > {0}", item));

        yield return null;
    }

    #region Fading

    private IEnumerator FadeOut()
    {
        float timer = 1;
        cnvGroup.alpha = 0f;

        while (timer > 0)
        {
            cnvGroup.alpha += Time.deltaTime;
            yield return null;
            timer -= Time.deltaTime;
        }
        cnvGroup.alpha = 1f;
        yield return null;
    }

    private IEnumerator FadeIn()
    {

        float timer = 1;
        cnvGroup.alpha = 1f;

        while (timer > 0)
        {
            cnvGroup.alpha -= Time.deltaTime;
            yield return null;
            timer -= Time.deltaTime;
        }
        cnvGroup.alpha = 0;
        yield return null;
    }

    #endregion
    // Función de Back que corresponde al menú
    public void Back()
    {
        if (stack.Count == 0)
            return;
        Room item = stack.Pop();
        CreateMenu(item);

    }
    IEnumerator showmenu()
    {
        StartCoroutine(FadeOut());

        yield return new WaitForSeconds(2f);
        CreateMenu(new Room());
        
        StartCoroutine(FadeIn());

        yield return null;
    }    
}
