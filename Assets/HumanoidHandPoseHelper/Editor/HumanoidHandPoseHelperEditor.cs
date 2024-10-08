﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HumanoidHandPoseHelper))]
public class HumanoidHandPoseHelperEditor : Editor
{

  HumanoidHandPoseHelper humanoidHandPoseHelper;

  private void OnEnable()
  {
    humanoidHandPoseHelper = (HumanoidHandPoseHelper)target;
  }

  public override void OnInspectorGUI()
  {
    DrawDefaultInspector();

    //mirrorLeftPoseToRight;

    if (GUILayout.Button("Export Left HandPose as animation clip"))
    {
      ExportHandPose(true, false, "_LeftHandPose.anim");
    }

    if (GUILayout.Button("Export Right HandPose as animation clip"))
    {
      ExportHandPose(false, true, "_RightHandPose.anim");
    }

    if (GUILayout.Button("Export Both HandPose as animation clip"))
    {
      ExportHandPose(true, true, "_BothHandPose.anim");
    }


    // copy the pose of the left hand onto the right
    EditorGUI.BeginDisabledGroup(humanoidHandPoseHelper.lockRightHandPoseToLeft);
    if (GUILayout.Button("Mirror left hand pose to right hand") || humanoidHandPoseHelper.lockRightHandPoseToLeft)
    {

      foreach (string keyLeft in humanoidHandPoseHelper.leftHandPoseValueMap.Keys)
      {
        string keyRight = keyLeft.Replace("Left", "Right");
        humanoidHandPoseHelper.rightHandPoseValueMap[keyRight] = humanoidHandPoseHelper.leftHandPoseValueMap[keyLeft];
      }
    }
    EditorGUI.EndDisabledGroup();

    // copy the pose of the left hand onto the right
    if (GUILayout.Button(humanoidHandPoseHelper.lockRightHandPoseToLeft ? "Copy right hand pose" : "Mirror right hand pose to left hand"))
    {

      foreach (string keyRight in humanoidHandPoseHelper.rightHandPoseValueMap.Keys)
      {
        string keyLeft = keyRight.Replace("Right", "Left");
        humanoidHandPoseHelper.leftHandPoseValueMap[keyLeft] = humanoidHandPoseHelper.rightHandPoseValueMap[keyRight];
      }
    }


    if (GUILayout.Button("Reset HandPose"))
    {
      List<string> keyList = new List<string>();
      var keys = humanoidHandPoseHelper.leftHandPoseValueMap.Keys;
      foreach (var key in keys)
      {
        keyList.Add(key);
      }

      foreach (var key in keyList)
      {
        humanoidHandPoseHelper.leftHandPoseValueMap[key] = 0f;
      }
      keyList.Clear();

      keys = humanoidHandPoseHelper.rightHandPoseValueMap.Keys;
      foreach (var key in keys)
      {
        keyList.Add(key);
      }

      foreach (var key in keyList)
      {
        humanoidHandPoseHelper.rightHandPoseValueMap[key] = 0f;
      }
    }

    Dictionary<string, float> updateValues = new Dictionary<string, float>();

    foreach (var pair in humanoidHandPoseHelper.leftHandPoseValueMap)
    {
      float value = EditorGUILayout.Slider(pair.Key,
          pair.Value, -1f, 1f);

      updateValues[pair.Key] = value;
    }

    foreach (var pair in updateValues)
    {
      humanoidHandPoseHelper.leftHandPoseValueMap[pair.Key] = pair.Value;
    }
    updateValues.Clear();

    EditorGUI.BeginDisabledGroup(humanoidHandPoseHelper.lockRightHandPoseToLeft);
    foreach (var pair in humanoidHandPoseHelper.rightHandPoseValueMap)
    {
      float value = EditorGUILayout.Slider(pair.Key,
          pair.Value, -1f, 1f);

      updateValues[pair.Key] = value;
    }
    EditorGUI.EndDisabledGroup();

    foreach (var pair in updateValues)
    {
      humanoidHandPoseHelper.rightHandPoseValueMap[pair.Key] = pair.Value;
    }

  }

  //両手のポーズをアニメーションクリップとして保存
  public void ExportHandPose(bool left, bool right, string outputFileName)
  {
    var clip = new AnimationClip { frameRate = 30 };
    AnimationUtility.SetAnimationClipSettings(clip, new AnimationClipSettings { loopTime = true });

    for (int i = 0; i < HumanTrait.MuscleCount; i++)
    {
      var muscle = HumanTrait.MuscleName[i];
      if (left && HumanoidHandPoseHelper.TraitLeftHandPropMap.ContainsKey(muscle))
      {
        var curve = new AnimationCurve();
        curve.AddKey(0f, humanoidHandPoseHelper.leftHandPoseValueMap[muscle]);

        string musclePropName = HumanoidHandPoseHelper.TraitLeftHandPropMap[muscle];
        clip.SetCurve("", typeof(Animator), musclePropName, curve);
      }
      else if (right && HumanoidHandPoseHelper.TraitRightHandPropMap.ContainsKey(muscle))
      {
        var curve = new AnimationCurve();
        curve.AddKey(0f, humanoidHandPoseHelper.rightHandPoseValueMap[muscle]);

        string musclePropName = HumanoidHandPoseHelper.TraitRightHandPropMap[muscle];
        clip.SetCurve("", typeof(Animator), musclePropName, curve);
      }
    }

    string path;
    if (string.IsNullOrEmpty(humanoidHandPoseHelper.animationClipName))
    {
      path = "Assets/" + this.name + outputFileName;
    }
    else
    {
      path = "Assets/" + humanoidHandPoseHelper.animationClipName + ".anim";
    }
    var uniqueAssetPath = AssetDatabase.GenerateUniqueAssetPath(path);

    AssetDatabase.CreateAsset(clip, uniqueAssetPath);
    AssetDatabase.SaveAssets();
  }
}
