using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackTraverser : MonoBehaviour
{
    [SerializeField] private Transform _target;
    void TraverseWithStack(Transform startPoint) {
        var stack = new Stack<Transform>();
        stack.Push(startPoint);

        while (stack.Count > 0) {
            var current = stack.Pop();
            Debug.Log(current.name);

            foreach (Transform child in current) {
                stack.Push(child);
            }
        }
    }

    void Start() {
        TraverseWithStack(_target);
    }
}
