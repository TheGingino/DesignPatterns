using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecursiveTraverser : MonoBehaviour
{
    [SerializeField] private Transform _target;
    
    void TraverseRecursively(Transform currentTransform) {
        Debug.Log(currentTransform.name);
        foreach (Transform child in currentTransform) {
            TraverseRecursively(child);
        }
    }

    void Start() {
        TraverseRecursively(_target);
    }
}
