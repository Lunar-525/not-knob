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
    public BaseBuilding Building;
    public object[] Note;
    private void Start()
    {
        if (Building != null)
        {
            Note = new object[] { Building.Timing, Building.Color, Building.Track, Building.X };
            Debug.Log("Note values: " + string.Join(", ", Note));
        }
        else
        {
            Debug.LogError("Building is not initialized.");
        }
    }
    private void Update()
    {
        // 获取用户输入并更新 Building 的属性
        int newTiming = 0;
        int newColor = 0;
        int newTrack = 0;
        float newX = 0f;
        // 用户通过键盘输入来选择数据
        if (Input.GetKeyDown(KeyCode.UpArrow))   // 假设上箭头增加 Timing
        {
            newTiming = Mathf.Min(Building.Timing + 1, 10);  // 限制 Timing 最大为 10
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))  // 假设下箭头减少 Timing
        {
            newTiming = Mathf.Max(Building.Timing - 1, 0);  // 限制 Timing 最小为 0
        }
        // 假设颜色通过数字键选择
        if (Input.GetKeyDown(KeyCode.Alpha1))   // 数字 1 选择 RED
        {
            newColor = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))   // 数字 2 选择 BLUE
        {
            newColor = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))   // 数字 3 选择 WHITE
        {
            newColor = 0;
        }
        // 假设 Track 通过 Q、W、E 键来选择
        if (Input.GetKeyDown(KeyCode.Q))  // Q 键选择 LEFT
        {
            newTrack = 1;
        }
        if (Input.GetKeyDown(KeyCode.W))  // W 键选择 RIGHT
        {
            newTrack = 2;
        }
        if (Input.GetKeyDown(KeyCode.E))  // E 键选择 MIDDLE
        {
            newTrack = 0;
        }
        // 通过键盘输入设置 X 和 Y 坐标
        if (Input.GetKey(KeyCode.A))  // 按住 A 键时 X 位置减小
        {
            newX -= 0.1f;
        }
        if (Input.GetKey(KeyCode.D))  // 按住 D 键时 X 位置增大
        {
            newX += 0.1f;
        }
        // 调用 UpdateBuildingData 来更新 Building 的数据并重新生成 Note 数组
        UpdateBuildingData(newTiming, newColor, newTrack, newX);
    }
    public void UpdateBuildingData(int timing, int color, int track, float x)
    {
        Building.Timing = timing;
        Building.Color = color;
        Building.Track = track;
        Building.X = x;
        // 重新生成 Note 数组
        Note = new object[] { Building.Timing, Building.Color, Building.Track, Building.X};
        Debug.Log("Updated Note values: " + string.Join(", ", Note));
    }
}
