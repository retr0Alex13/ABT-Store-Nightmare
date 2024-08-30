using UnityEngine;
using Ami.BroAudio;

public class Footsteps : MonoBehaviour
{
    [SerializeField]
    private SoundID walkRockFootsteps;
    [SerializeField]
    private SoundID runRockFootsteps;
    [SerializeField]
    private SoundID walkGroundFootSteps;
    [SerializeField]
    private SoundID runGroundFootSteps;

    private TerrainDetector terrainDetector;

    private void Awake()
    {
        terrainDetector = new TerrainDetector();
    }

    public void PerformStep(bool isRunning)
    {
        SoundID footStep = isRunning ? GetRunFootstepType() : GetWalkFootstepType();
        BroAudio.Play(footStep);
    }

    private SoundID GetWalkFootstepType()
    {
        int terrainTextureIndex = GetTerrainTextureIndex();

        switch (terrainTextureIndex)
        {
            case 0:
                return walkRockFootsteps;
            case 1:
                return walkGroundFootSteps;
            default:
                return walkRockFootsteps;
        }

    }

    private SoundID GetRunFootstepType()
    {
        int terrainTextureIndex = GetTerrainTextureIndex();

        switch (terrainTextureIndex)
        {
            case 0:
                return runRockFootsteps;
            case 1:
                return runGroundFootSteps;
            default:
                return runRockFootsteps;
        }

    }

    private int GetTerrainTextureIndex()
    {
        return terrainDetector.GetActiveTerrainTextureIdx(transform.position);
    }

}