using Assets.Scripts.Data;
using Assets.Scripts.Models;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ProductItem : MonoBehaviour
{
    public Image image;
    public Text categoryNameText;
    public Text nameText;
    public Text priceText;

    public Product product;
    public Manager manager;

    // Start is called before the first frame update
    void Start()
    {
        Data data = new Data();
        Debug.Log("Images/" + product.ImageName);
        image.sprite = Resources.Load<Sprite>("Images/" + product.ImageName);
        Debug.Log(image.sprite);
        categoryNameText.text = data.Categories.FirstOrDefault(c => c.Id == product.CategoryId).Name;
        nameText.text = product.Name;
        priceText.text = product.Price.ToString();
    }

    public void InstantiateObject()
    {
        manager.ShowProduct(product.Id);
    }
}
