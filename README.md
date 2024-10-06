# HumanoidHandPoseHelper

## English:
This is a script that edits the hand pose of a humanoid character in Unity3D and exports it as an AnimationClip.

It is intended to be used to be able to add facial expressions to the character's hands when making videos using Timeline.

The created AnimationClip is in Humanoid format, so it can be used universally for other characters.

![Screenshot 2024-04-29 155517](https://github.com/cubee-cb/HumanoidHandPoseHelper/assets/157681441/89c28190-a1cc-4d3d-8995-cf366dbdbd94)

## How to use
1. Put the HumanoidHandPoseHelper folder in the repository into your Unity project.

2. Add the HumanoidHandPoseHelper script to the object with the Animator component of the character in Humanoid format.

3. You can edit in edit mode without entering the play mode of the Unity editor.

4. Move the slider corresponding to each knuckle to change the pose of the character's hand.

5. By pressing the Export button, you can export the edited hand pose to AnimationClip.

	You can export in three patterns: left hand only, right hand only, and both hands.

	By default, it will be exported with a path like Assets/{game object name}_LeftHandPose.anim.

	If you set a name for AnimationClipName, it will be exported with that name.

6. Press the "Reset HandPose" button to reset the edited hand pose.

7. If "IsShowEditHandPose" is checked, you can preview the edit pose.

	If you don't need to preview the hand pose, such as when editing the Timeline, uncheck it.

	Even if you uncheck it, it will not be reflected immediately, but it will be reflected if you select another object, etc.

8. You can mirror the pose of the hand by pressing the "Mirror left hand pose to right hand" button.

	Alternatively, you can check "Lock Right Hand Pose To Left" to have the right hand always match the left hand's pose. This will disable the right hand sliders and the mirror button.

Note: When you enter or return to the editor's play mode, the edited pose will be reset.

### Credits
I referred to the code of [EasyMotionRecorder] (https://github.com/duo-inc/EasyMotionRecorder) by Duo.Inc.
Translated from Japanese to English by DuckDuckGo Translate.


## Original:
In Unity3d, Edit hand pose of humanoid character, and export it as animation clip.

Unity3Dで、humanoidキャラクターの手のポーズを編集して、AnimationClipとして書き出すスクリプトです。

Timelineを使って動画を作る際にキャラの手に表情を付けられるようにする用途を想定してます。

作成されたAnimationClipはHumanoid形式なので、他のキャラクターにも汎用的に使い回せます。

![screenshot](https://raw.github.com/wiki/umiyuki/HumanoidHandPoseHelper/humanoidhandposehelperimage.jpg)


## 使い方
1.リポジトリの中にあるHumanoidHandPoseHelperフォルダを自分のUnityプロジェクトに入れてください。

2.Humanoid形式のキャラクタのAnimatorコンポーネントが付いてるオブジェクトにHumanoidHandPoseHelperスクリプトを付けてください。

3.Unityエディタのプレイモードに入らなくても、編集モードの中で編集できます。

4.それぞれの指の関節に対応したスライダーを動かすとキャラクターの手のポーズが変化します。

5.Exportボタンを押す事で編集した手のポーズをAnimationClipに書き出せます。

左手のみ、右手のみ、両手の３パターンで書き出せます。

デフォルトではAssets/{ゲームオブジェクト名}_LeftHandPose.animみたいなパスで書き出します。AnimationClipNameに名前を設定するとその名前で書き出します。

6."Reset HandPose"ボタンを押すと編集した手のポーズをリセットできます。

7."IsShowEditHandPose"のチェックが付いてると編集ポーズをプレビューできます。

Timelineの編集中など、手のポーズをプレビューする必要が無い時はチェックを外してください。

チェックを外してもすぐに反映されませんが、他のオブジェクトを選択するなどすると反映されます。

注意点: エディタのプレイモードに入ったり、プレイモードから編集モードに戻ってくる時に編集したポーズがリセットされてしまいます。

### クレジット
Duo.Inc様の[EasyMotionRecorder](https://github.com/duo-inc/EasyMotionRecorder)のコードを参考にさせていただきました。
