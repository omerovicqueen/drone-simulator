# Publication validation

The source release was prepared with Unity Editor **6000.3.8f1**.

- The original project compiled successfully in Unity batch mode.
- Unity's recursive `AssetDatabase.GetDependencies` export preserved the main scene, render settings, input assets, scripts, and referenced resources with their `.meta` files.
- A SHA-256 comparison confirmed that all 858 unmodified export files matched the source project. Unity Cloud identifiers were removed from the publication's player settings; embedded package entries were changed to the same versions from Unity's registry.
- OBJ material definitions and font/audio notices were included separately where they are resolved by filename or license requirements rather than scene GUID references.
- The two README images are renders of the actual main scene and interface. The preview uses a camera placed behind the drone; it does not imply that this is the default in-game camera offset.
- Large TIFF textures and binary terrain data are stored using Git LFS. Generated caches, recovery scenes, local IDE/SCM metadata, and build outputs are excluded.

This is a source-publication check, not an automated gameplay test suite or a complete playthrough. The cleaned repository has not been tested with a cold Unity import. Use the manual Play-mode checks in [CONTRIBUTING.md](../CONTRIBUTING.md) when making gameplay changes.
