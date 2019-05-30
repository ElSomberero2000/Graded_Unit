﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

[CustomEditor (typeof (EnemyBehaviour))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        EnemyBehaviour fov = (EnemyBehaviour)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.transform.position, Vector3.up, Vector3.forward, 360, fov.viewRadius); // Draws wireframe curve around the enemy actor
        Vector3 viewAngleA = fov.DirFromAngle(-fov.viewAngle / 2, false); // Sets the curve to only draw inbetween a specified angle
        Vector3 viewAngleB = fov.DirFromAngle(fov.viewAngle / 2, false);

        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleA * fov.viewRadius); // Draws radial wireframe in the editor window eminating from the enemy actor
        Handles.DrawLine(fov.transform.position, fov.transform.position + viewAngleB * fov.viewRadius);

        Handles.color = Color.red; // Renders the wireframe as red
        foreach (Transform visibleTarget in fov.visibleTargets)
        {
            Handles.DrawLine(fov.transform.position, visibleTarget.position); // Draws a red line to any objects on the target layer that are within the view radius
        }
    }
    
}
