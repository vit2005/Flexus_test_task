using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[RequireComponent(typeof(Cannonball))]
public class DecalManager : MonoBehaviour
{

    public static DecalManager instance;

    //public GameObject decalPrefab;
    public Camera decalCamera; // Друга камера для рендерингу декалей
    public RenderTexture decalRenderTexture; // Render Texture для другої камери
    public Material decalMaterial; // Матеріал для відображення декалі
    public GameObject decalPrefab; // Префаб декалі

    void Start()
    {
        instance = this;
        //Cannonball cannonball = GetComponent<Cannonball>();
        //cannonball.OnCollision += RenderDecal;
    }

    public void RenderDecal(Vector3 position, Vector3 normal)
    {
        // Створюємо нову декаль
        var currentDecal = Instantiate(decalPrefab, position, Quaternion.LookRotation(normal));
        //// Налаштовуємо матеріал декалі
        //Renderer decalRenderer = currentDecal.GetComponent<Renderer>();
        //if (decalRenderer != null)
        //{
        //    decalRenderer.material = decalMaterial;
        //}

        // Додаємо декаль до текстури через рендеринг з другої камери
        decalCamera.Render();
    }
}
