using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ListViewWithJson.Models;

using Xamarin.Forms;

namespace ListViewWithJson
{
    public partial class MoreInfoPage : ContentPage
    {
        public MoreInfoPage(Models.ProductData currentItem)
        {
            InitializeComponent();
            ProductName.Text = "Item Name: " + currentItem.ProductName;
            ProductImage.Source = currentItem.ImageUrl;
            ProductDescription.Text = "Item Description: " + currentItem.Description;
            ProductPrice.Text = "Price: $" + currentItem.Price;
            ProductRating.Text = "Rating: " + currentItem.StarRating;

        }
    }
}
