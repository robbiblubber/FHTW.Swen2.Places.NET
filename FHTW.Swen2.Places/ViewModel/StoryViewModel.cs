using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FHTW.Swen2.Places.Model;

namespace FHTW.Swen2.Places.ViewModel
{
    public sealed class StoryViewModel
    {
        public StoryViewModel(MainViewModel parent, Story story)
        {
            Parent = parent;
            Story = story;
        }


        public MainViewModel Parent
        {
            get;
        }


        public Story Story
        {
            get;
        }


        public string PrimaryImageSource
        {
            get
            {
                foreach(string i in Story.Pictures)
                {
                    string rval = Configuration.Instance.ImagePath.TrimEnd('\\') + '\\' + i;
                    if(File.Exists(rval)) return rval;
                }

                return Configuration.Instance.ImagePath.TrimEnd('\\') + @"\_missing.jpg";
            }
        }


        public string Text
        {
            get { return Story.Text; }
        }
    }
}
