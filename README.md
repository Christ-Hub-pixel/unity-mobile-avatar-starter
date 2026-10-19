# Unity Mobile Avatar Starter

Starter project for Unity mobile (Android/iOS) that shows how to integrate 3D avatars (Ready Player Me / VRM) and a simple mobile controller with optimization tips.

This repository contains guidance, scripts and a recommended project structure so you can quickly create a prototype on mobile using Unity + URP.

Quick links
- Ready Player Me: https://readyplayer.me/
- Ready Player Me Unity SDK (official): https://github.com/readyplayerme/rpm-unity-sdk-core
- Ready Player Me workshop: https://github.com/readyplayerme/rpm-unity-workshop

What’s included
- README (this file)
- Assets/Scripts/PlayerControllerMobile.cs — simple CharacterController-based movement for mobile.
- Assets/Scripts/VirtualJoystick.cs — on-screen joystick UI script (use with Unity UI Canvas).
- Assets/Scripts/AvatarLoader.cs — small helper to instantiate an avatar prefab (placeholder). Use the official RPM SDK for dynamic avatar downloads.

Project setup (recommended)
1. Unity version: 2021.3 LTS or later (2022/2023 LTS recommended).
2. Template: 3D (use URP template for better mobile performance).
3. Install packages via Window > Package Manager:
   - Universal RP
   - Input System (optional)
   - Addressables (optional)
   - Cinemachine (optional)

Scene setup (quick)
1. Create a new Scene (Assets/Scenes/MainScene.unity).
2. Add a Plane or simple environment.
3. Add an empty GameObject PlayerRoot with a CharacterController component.
4. Create a child GameObject "Avatar" where you will place the avatar prefab (from Ready Player Me or Resources).
5. Attach the PlayerControllerMobile script to PlayerRoot and set the Avatar child reference.
6. Create a Canvas (Screen Space - Overlay) and add a joystick UI (Image for background, Image for handle). Attach VirtualJoystick to the background and reference the handle.
7. Add a Main Camera and make it follow/rotate the player (simple script or Cinemachine Virtual Camera).

How to use Ready Player Me
- For runtime dynamic avatar loading use the official Ready Player Me Unity SDK: https://github.com/readyplayerme/rpm-unity-sdk-core
- This repo's AvatarLoader.cs demonstrates a simple prefab instantiation flow. For production, wire the Ready Player Me loader to instantiate into the Avatar transform and then convert/optimize (set URP shaders, reduce material count, create LODs).

Mobile build tips
- Player Settings > Other Settings: Scripting Backend: IL2CPP, Target Architectures: ARM64 (Android).
- Graphics: use URP asset with low/medium quality for mobile, shadow distance reduced.
- Textures: use ASTC (iOS/modern Android) or ETC2; maximum atlas usage; prefer 512 or 1024 px for character textures.
- Skinned meshes: limit bone influences to 4; reduce blendshapes when possible.
- Bake static lights; use light probes for characters.
- Profile on device frequently (Unity Profiler, Android Studio Profiler).

Next steps
- Integrate Ready Player Me SDK and test importing an avatar.
- Add Mixamo animations or use Humanoid retargeting with Animator Controller.
- Add networking later (Photon, Mirror, or Unity Netcode) if you need multiplayer.

License: MIT
