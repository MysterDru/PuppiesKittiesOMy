using System;

namespace PuppiesKittiesOMy
{
    public class PuppyPage : PicturePage
    {
        public PuppyPage()
            : base("Get A New Puppy!", "http://www.thepuppyapi.com/puppy?format=src")
        {
            Title = "Puppies!";
            Icon = "dog.png";
        }
    }
}