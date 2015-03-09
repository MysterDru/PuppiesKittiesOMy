using System;

namespace PuppiesKittiesOMy
{
    public class KittyPage : PicturePage
    {
        public KittyPage()
            : base("Get A New Kitty!", "http://thecatapi.com/api/images/get")
        {
            Title = "Kitties!";
            Icon = "cat.png";
        }
    }
}