using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeController : MonoBehaviour
{
    public InputField txt;
    public Button btn;
    public Text result;

    private BinaryTree tree;

    private void Awake()
    {
        tree = new BinaryTree();
    }

    public void Add()
    {
        try
        {
            int value = Convert.ToInt32(txt.text);

            tree.Insert(value);

            string preorder = tree.TraversePreOrder();
            string inorder = tree.TraverseInOrder();
            string postorder = tree.TraversePostOrder();

            result.text = string.Format("preorder: {0}\ninorder: {1}\npostorder: {2}", preorder, inorder, postorder);

            txt.text = string.Empty;
        }
        catch(FormatException e)
        {
            txt.text = "not valid number.";
        }
    }
}
