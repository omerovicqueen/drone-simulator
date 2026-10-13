# Third-party assets and notices

Azra Ömeroğlu developed the drone flight controls, input integration, checkpoint game loop, camera switching, game states, and gameplay interface integration. This project also uses imported visual and audio resources, credited below.

The repository's MIT license covers Azra Ömeroğlu's original code in `Assets/Scripts/` and original project documentation. It does not relicense imported assets, fonts, Unity packages, generated package code, or other third-party material. Those resources retain their own licenses and notices. The project owner has confirmed permission to include the imported resources in this source release; this statement does not grant additional rights to reuse them independently.

## Resources used by the main scene

| Resource | Project location | Attribution and license scope |
| --- | --- | --- |
| Unity Terrain — URP Demo Scene | `Assets/TerrainDemoScene_URP/` | Unity's terrain demo resources. The package's original [ThirdPartyNotices.txt](Assets/TerrainDemoScene_URP/ThirdPartyNotices.txt) specifies the Unity Asset Store EULA for the scene and art assets, with separate credits for terrain height data. Imported assets retain those terms and the project owner's confirmed source distribution permission; they are outside the MIT license. |
| Terrain height data | Terrain demo package | © OpenStreetMap contributors; see [OpenStreetMap copyright and license information](https://www.openstreetmap.org/copyright). Data also credited to the U.S. Geological Survey. Preserve the original terrain package notice. |
| AllSky Free — 10 Sky / Skybox Set | `Assets/AllSkyFree/Epic_BlueSunset/` | Imported skybox from AllSky Free, identified in the Unity importer metadata as Asset Store product 146014. Retains its original asset terms and the project owner's confirmed source distribution permission. |
| Hyper Casual FX | `Assets/Lana Studio/Hyper Casual FX/` | Imported particle effect resources from Lana Studio, identified in importer metadata as Asset Store product 200333. Retains its original asset terms and the project owner's confirmed source distribution permission. |
| Free Fantasy SFX Pack | `Assets/UI_Sounds/Free Fantasy SFX Pack By TomMusic/` | Audio by [TomMusic](https://tommusic.itch.io/), including the Forest Day ambient loop. Keep the original pack ReadMe alongside the included audio. Imported audio remains outside the MIT license. |
| Sci-fi interface panels | `Assets/UI_Sprites/WenrexaAssetsUI_SciFI/` | [Assets: Free UI Minimalism SciFi by Wenrexa](https://wenrexa.itch.io/kit-nesia2), also [published by the author on OpenGameArt](https://opengameart.org/content/assets-ui-minimalism-scifi), under [CC0 1.0 Universal](https://creativecommons.org/publicdomain/zero/1.0/). |
| Orbitron font and TextMesh Pro atlas | `Assets/UI_Fonts/Orbitron-ExtraBold.ttf` and `Orbitron-ExtraBold SDF.asset` | Copyright 2018 The Orbitron Project Authors; Reserved Font Name: “Orbitron”. SIL Open Font License 1.1. The copyright matches the bundled font's embedded metadata. Full license: [docs/licenses/orbitron-OFL.txt](docs/licenses/orbitron-OFL.txt); [upstream license](https://github.com/google/fonts/blob/main/ofl/orbitron/OFL.txt). |
| Inter font and TextMesh Pro atlases | `Assets/TextMesh Pro/Fonts/` | Copyright 2016–2020 The Inter Project Authors; Inter is a trademark of Rasmus Andersson. SIL Open Font License 1.1. Preserve [License.txt](Assets/TextMesh%20Pro/Fonts/License.txt). |
| Liberation Sans font and TextMesh Pro atlases | `Assets/TextMesh Pro/Fonts/` and `Assets/TextMesh Pro/Resources/Fonts & Materials/` | Digitized data © 2010 Google Corporation; © 2012 Red Hat, Inc. SIL Open Font License 1.1. Preserve [LiberationSans - OFL.txt](Assets/TextMesh%20Pro/Fonts/LiberationSans%20-%20OFL.txt), including the Reserved Font Names listed there. |
| Imported drone model | `Assets/Models/uploads_files_4599666_Drone.fbx_PrivateStack_4.fbx` | Imported FBX retained under its original terms and the project owner's confirmed source distribution permission. The local file metadata does not identify its original author or download page; no authorship claim is made for this model. |
| Meshy model resources | `Assets/_Project/Materials/Meshy_AI*/` | Model resources imported from Meshy-generated project files. Their filenames record their origin; the repository does not claim they were modeled manually. Included under the project owner's confirmed distribution rights and their applicable original terms. |
| Chime effects | `Assets/UI_Sounds/Chimes_*.wav` | Imported audio resources whose local metadata does not record an original author or source page. Included under the project owner's confirmed distribution rights; outside the MIT license. |

## Unity dependencies

Unity packages are identified by `Packages/manifest.json` and `Packages/packages-lock.json`. Registry packages are restored by Unity's Package Manager. They remain governed by the package authors' licenses, and are not covered by this repository's MIT license.

If embedded copies of `com.unity.cinemachine` or `com.unity.inputsystem` are present, retain their `LICENSE.md` files and all third-party notices. These packages identify the [Unity Companion License](https://unity.com/legal/licenses/unity-companion-license) as their license for Unity-dependent projects.

TextMesh Pro resource shaders and shader include files originate from Unity's TextMesh Pro resources and remain Unity material. Their font resources have the separate font licenses described above.

## Scope of the source release

The published project contains the main gameplay scene and its required resources. Unused vendor examples, recovery scenes, editor caches, local workspace metadata, and build output are excluded. Asset credits describe the integrated resources without attributing their original artwork or audio to the game's developer.
