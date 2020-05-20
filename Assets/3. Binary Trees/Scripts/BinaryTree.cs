using System.Collections;
using System.Collections.Generic;
using UnityEngine;
class BinaryTree
{
    public BinaryLeaf Root { get; set; }

    public BinaryLeaf Add(int value)
    {
        return Add(value, this.Root);
    }
    private BinaryLeaf Add(int value, BinaryLeaf root)
    {
        if (root == null)
        {
            root = new BinaryLeaf();
            root.Data = value;
        }
        else if (value < root.Data)
        {
            root.LeftNode = Add(value, root.LeftNode);
        }
        else
        {
            root.RightNode = Add(value, root.RightNode);
        }

        return root;
    }

    public bool Insert(int value)
    {
        BinaryLeaf before = null, after = this.Root;

        while (after != null)
        {
            before = after;
            if (value < after.Data) //Is new node in left tree? 
                after = after.LeftNode;
            else if (value > after.Data) //Is new node in right tree?
                after = after.RightNode;
            else
            {
                //Exist same value
                return false;
            }
        }

        BinaryLeaf newNode = new BinaryLeaf();
        newNode.Data = value;

        if (this.Root == null)//Tree ise empty
            this.Root = newNode;
        else
        {
            if (value < before.Data)
                before.LeftNode = newNode;
            else
                before.RightNode = newNode;
        }

        return true;
    }

    public BinaryLeaf Find(int value)
    {
        return this.Find(value, this.Root);
    }
    private BinaryLeaf Find(int value, BinaryLeaf parent)
    {
        if (parent != null)
        {
            if (value == parent.Data) return parent;
            if (value < parent.Data)
                return Find(value, parent.LeftNode);
            else
                return Find(value, parent.RightNode);
        }

        return null;
    }

    public void Remove(int value)
    {
        Remove(this.Root, value);
    }
    private BinaryLeaf Remove(BinaryLeaf parent, int key)
    {
        if (parent == null) return parent;

        if (key < parent.Data) parent.LeftNode = Remove(parent.LeftNode, key);
        else if (key > parent.Data)
            parent.RightNode = Remove(parent.RightNode, key);

        // if value is same as parent's value, then this is the node to be deleted  
        else
        {
            // node with only one child or no child  
            if (parent.LeftNode == null)
                return parent.RightNode;
            else if (parent.RightNode == null)
                return parent.LeftNode;

            // node with two children: Get the inorder successor (smallest in the right subtree)  
            
            int minv = parent.RightNode.Data;

            while (parent.RightNode.LeftNode != null)
            {
                minv = parent.RightNode.LeftNode.Data;
                parent.RightNode = parent.RightNode.LeftNode;
            }

            parent.Data = minv;

            // Delete the inorder successor  
            parent.RightNode = Remove(parent.RightNode, parent.Data);
        }

        return parent;
    }

    public int GetTreeDepth()
    {
        return this.GetTreeDepth(this.Root);
    }
    private int GetTreeDepth(BinaryLeaf parent)
    {
        return parent == null ? 0 : System.Math.Max(GetTreeDepth(parent.LeftNode), GetTreeDepth(parent.RightNode)) + 1;
    }

    public string TraversePreOrder()
    {
        return TraversePreOrder(this.Root);
    }
    private string TraversePreOrder(BinaryLeaf parent)
    {
        if (parent != null)
        {
            //Debug.Log(parent.Data + " ");
            return string.Format("{0}, {1}, {2}",
                parent.Data.ToString(),
                TraversePreOrder(parent.LeftNode),
                TraversePreOrder(parent.RightNode));
        }
        else
        {
            return string.Empty;
        }
    }

    public string TraverseInOrder()
    {
        return TraverseInOrder(this.Root);
    }
    private string TraverseInOrder(BinaryLeaf parent)
    {
        if (parent != null)
        {
            //Debug.Log(parent.Data + " ");
            return string.Format("{0}, {1}, {2}",
                TraverseInOrder(parent.LeftNode),
                parent.Data.ToString(),
                TraverseInOrder(parent.RightNode));

        }
        else
        {
            return string.Empty;
        }        
    }

    public string TraversePostOrder()
    {
        return TraversePostOrder(this.Root);
    }
    private string TraversePostOrder(BinaryLeaf parent)
    {
        if (parent != null)
        {
            //Debug.Log(parent.Data + " ");
            return string.Format("{0}, {1}, {2}",
                TraversePostOrder(parent.LeftNode),
                TraversePostOrder(parent.RightNode),
                parent.Data.ToString());
        }
        else
        {
            return string.Empty;
        }
    }
}