using UnityEngine;

// Simple AvatarLoader: instantiate a prefab from Resources or assign a prefab in the inspector.
// For dynamic Ready Player Me runtime avatars, use the official RPM Unity SDK to download & instantiate.
public class AvatarLoader : MonoBehaviour
{
    [Tooltip("If set, this prefab will be instantiated as the avatar child.")]
    public GameObject avatarPrefab;

    [Tooltip("Optional: name of a prefab inside Resources/Avatars to instantiate instead.")]
    public string resourcesAvatarName;

    [Tooltip("Where to place the loaded avatar (usually a child transform on the player)")]
    public Transform target;

    private GameObject spawnedAvatar;

    void Start()
    {
        if (avatarPrefab != null)
        {
            SpawnFromPrefab(avatarPrefab);
        }
        else if (!string.IsNullOrEmpty(resourcesAvatarName))
        {
            var res = Resources.Load<GameObject>("Avatars/" + resourcesAvatarName);
            if (res != null)
            {
                SpawnFromPrefab(res);
            }
            else
            {
                Debug.LogWarning("AvatarLoader: Resources avatar not found: " + resourcesAvatarName);
            }
        }
    }

    public void SpawnFromPrefab(GameObject prefab)
    {
        if (spawnedAvatar != null) Destroy(spawnedAvatar);
        if (target != null)
            spawnedAvatar = Instantiate(prefab, target, false);
        else
            spawnedAvatar = Instantiate(prefab, transform);
    }

    // Placeholder: for runtime RPM avatars, the RPM SDK provides a loader that returns a GameObject.
    // Example: ReadyPlayerMe.AvatarLoader.LoadAvatar(url, onSuccess, onFail).
}
