using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//[RequireComponent(typeof(Cannonball))]
public class DecalManager : MonoBehaviour
{

    public static DecalManager instance;

    //public GameObject decalPrefab;
    public Camera decalCamera; // ����� ������ ��� ���������� �������
    public RenderTexture decalRenderTexture; // Render Texture ��� ����� ������
    public Material decalMaterial; // ������� ��� ����������� �����
    public GameObject decalPrefab; // ������ �����

    void Start()
    {
        instance = this;
        //Cannonball cannonball = GetComponent<Cannonball>();
        //cannonball.OnCollision += RenderDecal;
    }

    public void RenderDecal(Vector3 position, Vector3 normal)
    {
        // ��������� ���� ������
        var currentDecal = Instantiate(decalPrefab, position, Quaternion.LookRotation(normal));
        //// ����������� ������� �����
        //Renderer decalRenderer = currentDecal.GetComponent<Renderer>();
        //if (decalRenderer != null)
        //{
        //    decalRenderer.material = decalMaterial;
        //}

        // ������ ������ �� �������� ����� ��������� � ����� ������
        decalCamera.Render();
    }
}
