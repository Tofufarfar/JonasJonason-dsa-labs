using System;
using System.Collections.Generic;
using System.Diagnostics;

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
            foreach (var Child in root.Children)
            {
                count += CountNodes<T>(Child);
            }
            // TODO: count this node, then count every child subtree.
            return count;

        }

        public static bool Contains<T>(HierarchyNode<T> root, T target)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            
            if (EqualityComparer<T>.Default.Equals(root.Value, target))
            {
                return true;
            }

            foreach (var child in root.Children)
            {
                if (Contains(child, target))
                {
                    return true;
                }
            }
            // TODO: compare the current node, then search child subtrees.
            //throw new NotImplementedException();
            return false;
        }

        public static IReadOnlyList<T> DepthFirstPreOrder<T>(HierarchyNode<T> root)
        {
            if (root == null)
            {
                throw new ArgumentNullException(nameof(root));
            }
            var result = new List<T>();
            
            void CreateList(HierarchyNode<T> node)
            {
                result.Add(node.Value);
                foreach (var child in node.Children)
                {
                    CreateList(child);
                }
            }
            
            CreateList(root);
            return result;
            
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
                depth = Math.Max(depth,MaxDepth(child)+1);
            }
            
            return depth;
            
            // Depth is measured in edges from the root.
            // A single-node tree therefore has max depth 0.
            //throw new NotImplementedException();
        }
    }
}
