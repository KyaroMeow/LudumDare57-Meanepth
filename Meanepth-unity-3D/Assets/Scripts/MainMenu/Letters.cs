using UnityEngine;
using UnityEngine.Events;
public class InteractiveText : MonoBehaviour
{
    public Material hoverMaterial; // Материал для состояния наведения
    public Light letterLight; // Источник света для буквы
    public UnityEvent onButtonClick; // Действие при клике
    private Material originalMaterial; // Исходный материал буквы
    public Animator animator;

    void Start()
    {
        // Сохраняем исходный материал
        originalMaterial = GetComponent<Renderer>().material;

        // Изначально выключаем свет
        if (letterLight != null)
        {
            letterLight.enabled = false;
        }
    }

    

    void OnMouseEnter()
    {
        // При наведении меняем материал и включаем свет
        if (hoverMaterial != null)
        {
            GetComponent<Renderer>().material = hoverMaterial;
        }
        if (letterLight != null)
        {
            letterLight.enabled = true;
        }
        if(animator!= null)
        {
            animator.SetBool("MouseEnter",true);
        }
    }

    void OnMouseExit()
    {
        // При выходе курсора возвращаем исходный материал и выключаем свет
        if (originalMaterial != null)
        {
            GetComponent<Renderer>().material = originalMaterial;
        }
        if (letterLight != null)
        {
            letterLight.enabled = false;
        }
        if(animator != null){
            animator.SetBool("MouseEnter",false);
        }
    }

    void OnMouseDown()
    {
        if (onButtonClick != null)
        {
            onButtonClick.Invoke();
        }
    }
}
