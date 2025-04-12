using BepInEx;
using BepInEx.Logging;
using HarmonyLib;
using UnityEngine;

namespace Fumos;

[BepInPlugin("Pufikas.Fumos", "Fumos", "1.0")]
public class Fumos : BaseUnityPlugin
{
    internal static Fumos Instance { get; private set; } = null!;
    internal new static ManualLogSource Logger => Instance._logger;
    private ManualLogSource _logger => base.Logger;
    internal Harmony? Harmony { get; set; }

    private void Awake()
    {
        Instance = this;
        
        // Prevent the plugin from being deleted
        this.gameObject.transform.parent = null;
        this.gameObject.hideFlags = HideFlags.HideAndDontSave;

        Patch();

        Logger.LogInfo($"{Info.Metadata.GUID} v{Info.Metadata.Version} has loaded!");
        Logger.LogInfo("Fumos are roaming...");
    }

    internal void Patch()
    {
        Harmony ??= new Harmony(Info.Metadata.GUID);
        Harmony.PatchAll();
    }

    internal void Unpatch()
    {
        Harmony?.UnpatchSelf();
    }

    private void Update()
    {
        // Code that runs every frame goes here
    }

    public class RotateTowardsPlayer : MonoBehaviour
    {
        private Transform playerTransform;

        void Start()
        {
            // Find the player by tag (make sure your player has the "Player" tag)
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                playerTransform = player.transform;
            }
        }

        void Update()
        {
            if (playerTransform != null)
            {
                // Calculate direction to player
                Vector3 direction = playerTransform.position - transform.position;

                // Only rotate on the Y axis (for typical ground-based enemies)
                direction.y = 0;

                // Rotate towards the player
                if (direction != Vector3.zero)
                {
                    transform.rotation = Quaternion.LookRotation(direction);
                }
            }
        }
    }
}