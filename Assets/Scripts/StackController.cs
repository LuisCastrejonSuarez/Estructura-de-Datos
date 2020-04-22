using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StackController : MonoBehaviour
{
    public GameObject menu;
    public GameObject element;

    Stack<KeyValuePair<int, int[]>> stack;
    List<GameObject> buttons;


    void Start()
    {
        stack = new Stack<KeyValuePair<int, int[]>>();
        buttons = new List<GameObject>();
        for(int i=0;i<4;++i)
        {
            GameObject tmp = Instantiate(element, menu.transform);
            buttons.Add(tmp);
        }
        CreateMenu(new KeyValuePair<int, int[]>(-1, null));
    }

    void CreateMenu(KeyValuePair<int, int[]> item)
    {
        int i = 0;
        int[] rnd = new int[4];

        for (i = 0; i < 4; ++i)
        {
            if (item.Key == -1)
                rnd[i] = Random.Range(0, 10);
            else
                rnd[i] = item.Value[i];
        }
        for (i = 0; i < 4; ++i)
        {
            buttons[i].GetComponentInChildren<Text>().text = rnd[i].ToString();
            buttons[i].GetComponent<Button>().onClick.AddListener(() => SelectOption(new KeyValuePair<int, int[]>(i, rnd)));
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
    public void SelectOption(KeyValuePair<int, int[]> item)
    {
        stack.Push(item);

        CleanMenu();
        StartCoroutine(showmenu());

        Debug.Log(string.Format(" > {0}", item.Key));
    }
    // Función de Back que corresponde al menú
    public void Back()
    {
        if (stack.Count == 0)
            return;
        KeyValuePair<int, int[]> item = stack.Pop();
        CreateMenu(item);

    }
    IEnumerator showmenu()
    {
        // TODO: animación de salida
        CreateMenu(new KeyValuePair<int, int[]>(-1, null));
        // TODO: animación de entrada
        yield return null;
    }

    void Update()
    {
        
    }
    
}
