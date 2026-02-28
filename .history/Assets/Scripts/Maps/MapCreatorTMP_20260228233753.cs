using UnityEngine;

public class SongData
{
    public int SongID; public int MapID;
    public string SongName; public string Composer; public string Illustrator; public string Mapper;
    public float BPM; public int TotalTiming;
}

public class NoteData
{
    public int Timing;
    public int Color; // RED-1, BLUE-2, WHITE-0
    public int Track; // LEFT-1, RIGHT-2, MIDDLE-0, FREE-9
    public float X;
    public NoteData(int timing, int color, int track, float x)
    {Timing = timing; Color = color; Track = track; X = x; }
}

public class DataContainer //序列化 SongData 和 NoteData
{
    
    public List<SongData> SongInfo = new List<SongData>();
    public List<NoteData> Notes = new List<NoteData>();
}

public class MapCreatorTMP : MonoBehaviour
{
    public SongData songData = new SongData();
    public NoteData noteData;
    private string serializedData;

    private void Start()
    {
        // 创建一个 DataContainer 用于保存所有 Data
        DataContainer dataContainer = new DataContainer();

        // 添加歌曲信息（如果有的话）
        dataContainer.SongInfo.Add(songData);
        
        // 检查 noteData 是否已初始化
        if (noteData != null)
        {
            // 将 Note 的数据添加到 DataContainer 中
            dataContainer.Notes.Add(new NoteData(noteData.Timing, noteData.Color, noteData.Track, noteData.X));
        }
        else
        {
            // 测试数据
            dataContainer.Notes.Add(new NoteData(1000, 1, 1, 2.5f));
            Debug.LogWarning("noteData is null, using test data instead");
        }
        
        // 序列化成 JSON 字符串
        serializedData = JsonUtility.ToJson(dataContainer);  // 修正变量名
        Debug.Log("Serialized JSON: " + serializedData);
        
        // 反序列化回来
        DataContainer deserializedContainer = JsonUtility.FromJson<DataContainer>(serializedData);  // 修正类名
        
        if (deserializedContainer != null && deserializedContainer.Notes.Count > 0)
        {
            foreach (var note in deserializedContainer.Notes)
            {
                Debug.Log($"Timing: {note.Timing}, Color: {note.Color}, Track: {note.Track}, X: {note.X}");
            }
        }
    }
    private void Update()
    {
        
    }
}
