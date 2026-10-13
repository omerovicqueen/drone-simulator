# Contributing

Open the project with Unity **6000.3.8f1** and use `Assets/Scenes/Main.unity` for gameplay work. Preserve the Unity `.meta` files when moving or adding assets.

For a bug report, include your editor version, reproduction steps, expected behavior, and relevant Console messages. For a pull request, explain the player-visible change and how you checked it in Play mode. Screenshots help when changing the interface or environment.

## Component references

- Prefer explicit `[SerializeField] private` references assigned in the Inspector.
- Validate required references in `Awake`; log a clear error and prevent invalid execution if a dependency is missing.
- Avoid runtime scene searches and repeated component lookups. A dynamic-object exception should explain its reason in a code comment.
- Assign references explicitly even when using `[RequireComponent]`.

## Before submitting

1. Confirm the scene imports without missing scripts or materials.
2. Exercise start, movement, altitude, yaw, boost, and all camera modes.
3. Check checkpoint feedback, pause/resume, timeout, restart, and score saving.
4. Include only source assets, scripts, settings, and `.meta` files. Keep generated caches and builds out of commits.

Original code contributions are covered by the project's MIT license. Include the source and applicable license for any new third-party resource; see [THIRD_PARTY_NOTICES.md](THIRD_PARTY_NOTICES.md).
