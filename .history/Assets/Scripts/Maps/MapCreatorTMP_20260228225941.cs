using UnityEngine;

public class BaseBuilding
{
    public int SongID; public int MapID;
    public string Song; public string Composer; public string Illustrator; public string Mapper;
    public float BPM; public int TotalTiming;
    public int Timing;
    public int Color; // RED-1, BLUE-2, WHITE-0
    public int Track; // LEFT-1, RIGHT-2, MIDDLE-0, FREE-9
    public float X;
}

public class MapCreatorTMP : MonoBehaviour
{
    public BaseBuilding Building = new BaseBuilding();
    private object[] Note;

    private void Start()
    {
            Note = new object[] { Building.Timing ,Building.Color, Building.Track, Building.X  };
            Debug.Log("Note values on Start: " + string.Join(", ", Note));
    }
    private void Update()
    {
        
    }
}
