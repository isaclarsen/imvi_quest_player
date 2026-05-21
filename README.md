# ImviQuestPlayer

Unity prototype for Meta Quest 3 that plays a local training video on a VR rig and drives left/right visual motion through the `TrainingManager` and `VisionPendulum` components. The current project appears to be an internship handover build focused on Quest video playback and convergence/divergence style training movement.

## Project root

Open the repository root folder as the Unity project. The correct root is the folder containing `Assets/`, `Packages/`, and `ProjectSettings/`.

## Unity version

Use Unity `6000.3.5f2`.

The version is recorded in `ProjectSettings/ProjectVersion.txt`. Install the exact editor version through Unity Hub if possible to avoid package/import churn.

## Target device

Target hardware: Meta Quest 3.

Current Android player settings found in the project:

- Product name: `ImviQuestPlayer`
- Company: `ImviLabs`
- Android package name: `com.owlreading.unity`
- Minimum Android SDK: 29
- Android architecture: ARM64
- XR loader for Android: Oculus Loader through XR Plug-in Management

## Required Unity modules and packages

Install these Unity editor modules with Unity Hub:

- Android Build Support
- Android SDK and NDK Tools
- OpenJDK

Important packages from `Packages/manifest.json`:

- `com.meta.xr.sdk.core` `83.0.1`
- `com.meta.xr.sdk.interaction.ovr` `83.0.1`
- `com.unity.xr.management` `4.5.4`
- `com.unity.xr.oculus` `4.5.2`
- `com.unity.inputsystem` `1.17.0`
- `com.unity.mobile.android-logcat` `1.4.7`
- Unity built-in `Video`, `XR`, `UI`, and Android JNI modules

If Unity prompts to restore packages on first open, allow it to resolve from `Packages/manifest.json` and `Packages/packages-lock.json`.

## Opening the project in Unity Hub

1. Open Unity Hub.
2. Select `Add` / `Add project from disk`.
3. Choose this project root folder, not the parent folder.
4. Open with Unity `6000.3.5f2`.
5. Let Unity reimport assets and rebuild `Library/`. That folder is generated and should not be committed.

## Main scene

The enabled build scene is:

```text
Assets/VideoTest 1.unity
```

Unity records this in `ProjectSettings/EditorBuildSettings.asset`. Other scenes exist for testing or earlier iterations, including `Assets/VideoTest.unity`, `Assets/Test.unity`, and `Assets/Scenes/SampleScene.unity`.

## TrainingManager video setup

Main script:

```text
Assets/TrainingManager.cs
```

The `TrainingManager` component has a public Inspector field:

```csharp
public VideoClip videoFile;
```

To assign a local video:

1. Put the video file inside `Assets/`, for example `Assets/TrainingVideos/<video-name>.mp4`.
2. Wait for Unity to import it as a `VideoClip`.
3. Open `Assets/VideoTest 1.unity`.
4. Select the `TrainingRig` GameObject.
5. In the `TrainingManager` component, drag the imported video asset into `Video File`.
6. Check that `Left Video` and `Right Video` reference the intended scene `VideoPlayer` components.
7. Press Play in the editor, or build to Quest 3.

The current scene references `Assets/BigBuckBunny.mp4` as a sample video. That file is about 151 MB and is intentionally tracked with Git LFS.

## Building to Meta Quest 3

1. Put the Quest 3 into Developer Mode from the Meta mobile app.
2. Connect the headset over USB-C and accept the USB debugging prompt inside the headset.
3. In Unity, open `File > Build Profiles` or `File > Build Settings`.
4. Select Android and switch platform if needed.
5. Confirm `Assets/VideoTest 1.unity` is enabled in Scenes in Build.
6. Confirm XR Plug-in Management for Android has Oculus enabled.
7. Confirm ARM64 is selected in Player Settings.
8. Use `Build And Run` with the Quest connected, or `Build` to create an APK.

If the device does not appear, check `adb devices`, reconnect the cable, accept the headset prompt again, and make sure Android Build Support is installed for the active Unity editor.

## Builds and APKs

Place local APKs and release candidates in:

```text
Builds/
```

Build artifacts are intentionally ignored by Git. Keep only source files, settings, packages, docs, and small handover assets in the repository. The existing root-level `build.apk` is a local build artifact and should not be committed.

## Git handover notes

The `.gitignore` excludes Unity-generated folders and local build artifacts, including:

- `Library/`
- `Temp/`
- `Obj/`
- `Logs/`
- `UserSettings/`
- `.utmp/`
- `.vs/`
- generated IDE project files
- APK/AAB build output

MP4 files are tracked through Git LFS so the local sample video can stay in the repository.

Do not commit generated folders. Unity will recreate them on each machine.

## Troubleshooting

- If Unity opens with many import changes, verify the editor version is `6000.3.5f2`.
- If the Quest build fails because Android tools are missing, reinstall Android Build Support with SDK, NDK, and OpenJDK from Unity Hub.
- If the app starts but video is blank, verify the assigned video is imported as a Unity `VideoClip`, not only present somewhere on disk.
- If only one screen receives the configured video, inspect the `TrainingManager` `Left Video` and `Right Video` fields and assign the correct `VideoPlayer` components.
- If GitHub rejects a push, check that Git LFS is installed and initialized before pushing the sample `Assets/BigBuckBunny.mp4`.
- If local paths appear in files under `UserSettings/`, ignore them. `UserSettings/` is machine-local Unity state.
- If a build produces temporary `.utmp/` files or APKs outside `Builds/`, leave them uncommitted or move the final APK into `Builds/`.
