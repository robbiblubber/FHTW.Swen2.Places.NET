using FHTW.Swen2.Places.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHTW.Swen2.Places.Client
{
    public class StoryListData
    {
        internal PlaceDetailViewModel _Parent;
        private Story _Story;


        internal StoryListData(PlaceDetailViewModel parent, Story story)
        {
            _Parent = parent;
            _Story = story;
        }


        public string ImageSource
        {
            get
            {
                foreach(string i in _Story.Pictures) 
                {
                    string rval = Root.Config.ImagePath.TrimEnd('\\') + '\\' + i;
                    if(File.Exists(rval)) { return rval; }
                }

                return Root.Config.ImagePath.TrimEnd('\\') + @"\_missing.jpg";
            }
        }


        public string Text
        {
            get { return _Story.Text; }
        }
    }
}
