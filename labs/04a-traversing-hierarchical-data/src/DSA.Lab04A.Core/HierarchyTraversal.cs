using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace DSA.Lab04A
{
    /// <summary>
    /// Recursive algorithms over a rooted hierarchy.
    ///
    /// The key idea is structural recursion:
    /// solve the current node, then apply the same operation to each child subtree.
    /// </summary>
    public static class HierarchyTraversal
    {
        public static int CountNodes<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            int count = 1;
            foreach(HierarchyNode<T> child in root.Children)
            {
                count += CountNodes<T>(child);
            }
            return count;
            // TODO: count this node, then count every child subtree.
            //throw new NotImplementedException();
        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
           
            if (Equals(root.Value,target))
            {
                return true;
            }
            foreach(HierarchyNode<T> child in root.Children)
            {
                if (Contains(child, target))
                {
                    return true;
                }
            }
            return false;
            // TODO: compare the current node, then search child subtrees.
            //throw new NotImplementedException();
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            List<T> result = new List<T>();
            result.Add(root.Value);
            foreach(HierarchyNode<T> child in root.Children)
            {
                result.AddRange(DepthFirstPreOrder(child));
            }
            return result;

            // TODO: return values in pre-order:
            // current node first, then each child subtree from left to right.
            //throw new NotImplementedException();
        }

        public static int MaxDepth<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            int depth = 0;
            
            foreach (var child in root.Children)
            {
                if (MaxDepth(child) >= depth)
                {
                    depth = MaxDepth(child) + 1;
                }
                
                
            }
            return depth;
            
            // Depth is measured in edges from the root.
            // A single-node tree therefore has max depth 0.
            //throw new NotImplementedException();
        }
    }
}
