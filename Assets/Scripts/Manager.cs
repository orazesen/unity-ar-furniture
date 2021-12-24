using Assets.Scripts.Data;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation.Samples;

public class Manager : MonoBehaviour
{
    #region Objects
    public Image cameraImage;
    public Image addImage;
    public GameObject menu;
    public GameObject productPrefab;
    public Transform productsParent;
    #endregion

    #region Scripts
    public PlaceOnPlane placeOnPlane;
    public FacingDirectionManager facingDirectionManager;
    #endregion

    #region Private Variables
    private Data data;
    private List<GameObject> products= new List<GameObject>();
    private Sprite delete;
    private Sprite tick;
    private Sprite add;
    private Sprite cameraSprite;
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        placeOnPlane.enabled = false;
        facingDirectionManager.enabled = false;
        data = new Data();

        foreach(var product in data.Products)
        {
            GameObject p = Instantiate(productPrefab, productsParent);
            p.GetComponent<ProductItem>().product = product;

            p.SetActive(true);

            products.Add(p);
        }

        delete = Resources.Load<Sprite>("Sprites/style03/shape080_style03_color08");
        tick = Resources.Load<Sprite>("Sprites/style03/shape038_style03_color03");
        add = Resources.Load<Sprite>("Sprites/style03/shape035_style03_color08");
        cameraSprite = Resources.Load<Sprite>("Sprites/style03/shape016_style03_color08");
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void ShowProduct(int id)
    {
        menu.SetActive(false);
        addImage.sprite = tick;
        cameraImage.sprite = delete;
        placeOnPlane.enabled = true;
        facingDirectionManager.enabled = true;
        Product product = data.Products.FirstOrDefault(p => p.Id == id);
        GameObject currentObject = Instantiate(Resources.Load<GameObject>("Prefabs/" + product.Name));
        currentObject.SetActive(false);
        placeOnPlane.spawnedObject = currentObject;
        facingDirectionManager.worldSpaceObject = currentObject;
        addImage.sprite = tick;
        cameraImage.sprite = delete;
    }

    public void CenterButtonAction()
    {
        if(addImage.sprite == add)
        {
            menu.SetActive(true);
            placeOnPlane.enabled = false;
            facingDirectionManager.enabled = false;
        }
        else
        {
            addImage.sprite = add;
            cameraImage.sprite = cameraSprite;
            placeOnPlane.DisableObject();
            placeOnPlane.enabled = false;
            facingDirectionManager.enabled = false;
        }
    }

    public void LeftButtonAction()
    {
        if(cameraImage.sprite == cameraSprite)
        {

        }
        else
        {
            addImage.sprite = add;
            cameraImage.sprite = cameraSprite;
            placeOnPlane.spawnedObject = null;
            facingDirectionManager.worldSpaceObject = null;
        }        
    }
}
