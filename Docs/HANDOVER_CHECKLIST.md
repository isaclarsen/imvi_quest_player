# Handover Checklist

## Repository

- [ ] Create the GitHub repository.
- [ ] Commit `Assets/`, `Packages/`, `ProjectSettings/`, `.gitignore`, `README.md`, `Docs/`, and any intentional project settings.
- [ ] Do not commit `Library/`, `Temp/`, `Obj/`, `Logs/`, `UserSettings/`, `.utmp/`, `.vs/`, generated IDE files, APKs, or AABs.
- [ ] Confirm Git LFS is installed before cloning or pushing, because `Assets/BigBuckBunny.mp4` is intentionally tracked with LFS.

## Unity

- [ ] Install Unity `6000.3.5f2`.
- [ ] Install Android Build Support with SDK, NDK, and OpenJDK.
- [ ] Open this folder as the Unity project root.
- [ ] Let Unity restore packages from `Packages/manifest.json`.
- [ ] Confirm Android is the active build target.
- [ ] Confirm Oculus Loader is enabled under XR Plug-in Management for Android.
- [ ] Confirm ARM64 is enabled in Android Player Settings.

## Scene and video

- [ ] Open `Assets/VideoTest 1.unity`.
- [ ] Select `TrainingRig`.
- [ ] Assign the intended imported `VideoClip` to `TrainingManager > Video File`.
- [ ] Verify `Left Video` and `Right Video` point to the intended `VideoPlayer` components.
- [ ] Verify `Left Pendulum` and `Right Pendulum` point to the intended `VisionPendulum` components.

## Quest 3 build

- [ ] Enable Developer Mode on the Quest 3.
- [ ] Connect the headset over USB-C.
- [ ] Accept USB debugging in the headset.
- [ ] Build and run from Unity to the connected headset.
- [ ] Place final APKs under `Builds/` for local delivery.
- [ ] Do not commit final APKs unless the project owner explicitly wants release artifacts tracked elsewhere.

## Known local artifacts to review

- [ ] `build.apk` exists at the repository root and is a local build artifact.
- [ ] `Assets/BigBuckBunny.mp4` is about 151 MB and is tracked with Git LFS.
- [ ] `.DS_Store` files exist locally and are ignored.
- [ ] `UserSettings/` contains local Unity/editor paths and is ignored.
- [ ] `.utmp/` contains Android build temp files with absolute local paths and is ignored.
