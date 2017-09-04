using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Loader))]
public class LoaderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        Loader loader = (Loader) target;
        if(GUILayout.Button("Load Test Level"))
        {
            loader.Load("test");
        }
    }
}