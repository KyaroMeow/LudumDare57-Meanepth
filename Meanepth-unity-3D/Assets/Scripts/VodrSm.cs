using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class SeaweedAnimation : MonoBehaviour
{
    // -------------------------------
    // ПАРАМЕТРЫ ДЛЯ НАСТРОЙКИ АНИМАЦИИ
    // -------------------------------
    
    [Header("Animation Settings")]
    [Tooltip("Максимальная амплитуда покачивания (чем больше значение, тем сильнее изгиб)")]
    public float amplitude = 0.5f;
    
    [Tooltip("Частота покачивания (скорость колебаний)")]
    public float frequency = 1.0f;
    
    [Tooltip("Дополнительный фазовый сдвиг для разнообразия движения")]
    public float phaseOffset = 0.0f;
    
    [Tooltip("Множитель влияния высоты вершины на покачивание (0 – базовая часть не двигается, 1 – верх двигается полностью)")]
    [Range(0f, 1f)]
    public float vertexInfluence = 1.0f;
    
    [Tooltip("Если включено, смещение будет по оси Z, иначе по оси X")]
    public bool swayAlongZ = false;

    [Header("Mesh Settings")]
    [Tooltip("Пересчитывать нормали после деформации (может улучшить освещение)")]
    public bool recalcNormals = true;

    // -------------------------------
    // ВНУТРЕННИЕ ПЕРЕМЕННЫЕ
    // -------------------------------
    
    private MeshFilter meshFilter;
    private Mesh mesh;
    private Vector3[] originalVertices;  // Исходное состояние вершин
    private Vector3[] modifiedVertices;  // Изменённое положение вершин
    private float minY; // Низ водоросли (минимальное значение по Y)
    private float maxY; // Верх водоросли (максимальное значение по Y)
    private float totalHeight; // Разница между maxY и minY

    // -------------------------------
    // МЕТОД START - ИНИЦИАЛИЗАЦИЯ МЕША И ВЕРШИН
    // -------------------------------
    
    void Start()
    {
        // Получаем компонент MeshFilter
        meshFilter = GetComponent<MeshFilter>();
        if (meshFilter == null)
        {
            Debug.LogError("На объекте отсутствует MeshFilter!");
            enabled = false;
            return;
        }
        
        // Создаём копию исходного меша (чтобы не менять оригинал)
        if (meshFilter.sharedMesh == null)
        {
            Debug.LogError("MeshFilter не содержит меш!");
            enabled = false;
            return;
        }
        
        // Создаем копию, чтобы работать с вершинами
        mesh = Instantiate(meshFilter.sharedMesh);
        mesh.name = meshFilter.sharedMesh.name + " (Clone)";
        meshFilter.mesh = mesh;
        
        // Проверка доступности вершин
        if (!mesh.isReadable)
        {
            Debug.LogError("Mesh не доступен для чтения! Включи опцию Read/Write в настройках импорта");
            enabled = false;
            return;
        }
        
        // Получаем исходные вершины
        originalVertices = mesh.vertices;
        modifiedVertices = new Vector3[originalVertices.Length];
        // Копируем вершины
        System.Array.Copy(originalVertices, modifiedVertices, originalVertices.Length);
        
        // Вычисляем минимальное и максимальное значение по Y, чтобы понять высоту водоросли
        minY = float.MaxValue;
        maxY = float.MinValue;
        for (int i = 0; i < originalVertices.Length; i++)
        {
            float y = originalVertices[i].y;
            if (y < minY) minY = y;
            if (y > maxY) maxY = y;
        }
        totalHeight = maxY - minY;
        if (totalHeight <= 0f) totalHeight = 1f; // защитный случай, чтобы избежать деления на 0
    }

    // -------------------------------
    // МЕТОД UPDATE - ОБНОВЛЕНИЕ ПОЛОЖЕНИЯ ВЕРШИН КАЖДЫЙ КАДР
    // -------------------------------
    
    void Update()
    {
        // Время для анимации
        float t = Time.time;

        // Для каждой вершины вычисляем смещение
        for (int i = 0; i < originalVertices.Length; i++)
        {
            // Берем оригинальную вершину
            Vector3 origVertex = originalVertices[i];
            
            // Вычисляем фактор по высоте: 0 у основания, 1 у вершины
            float heightFactor = Mathf.Clamp01((origVertex.y - minY) / totalHeight);
            // Можно уменьшить влияние вершины базовой части через vertexInfluence (например, установить vertexInfluence = 0.5, чтобы верх двигался сильнее)
            float influence = heightFactor * vertexInfluence;
            
            // Вычисляем смещение как синус колебаний + фазовый сдвиг.
            // Используем координату по X (можно добавить влияние координаты Z для более сложного движения)
            float wave = Mathf.Sin(t * frequency + origVertex.x + phaseOffset) * amplitude * influence;
            
            // Создаем копию вершины для модификации
            Vector3 modVertex = origVertex;
            // Если выбран режим по оси X, смещаем X, иначе Z
            if (!swayAlongZ)
            {
                modVertex.x += wave;
            }
            else
            {
                modVertex.z += wave;
            }
            
            // Сохраняем результат
            modifiedVertices[i] = modVertex;
        }
        
        // Обновляем вершины меша
        mesh.vertices = modifiedVertices;
        
        // Пересчитываем нормали и границы, чтобы освещение и коллайдеры работали правильно
        if (recalcNormals)
        {
            mesh.RecalculateNormals();
        }
        mesh.RecalculateBounds();
    }
}
