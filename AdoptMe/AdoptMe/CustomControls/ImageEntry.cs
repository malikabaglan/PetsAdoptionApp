﻿using System;
using Xamarin.Forms;

namespace AdoptMe.CustomControls
{
    public class ImageEntry : Entry
    {




        public ImageEntry()
        {
            this.HeightRequest = 50;

        }
        public static readonly BindableProperty ImageProperty =



        public Color LineColor
        {
            get { return (Color)GetValue(LineColorProperty); }
            set { SetValue(LineColorProperty, value); }
        }

        public int ImageWidth
        {
            get { return (int)GetValue(ImageWidthProperty); }
            set { SetValue(ImageWidthProperty, value); }
        }

        public int ImageHeight
        {
            get { return (int)GetValue(ImageHeightProperty); }
            set { SetValue(ImageHeightProperty, value); }
        }

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public ImageAlignment ImageAlignment
        {
            get { return (ImageAlignment)GetValue(ImageAlignmentProperty); }
            set { SetValue(ImageAlignmentProperty, value); }
        }

 
    }

    public enum ImageAlignment
    {
        Left,
        Right
    }
}