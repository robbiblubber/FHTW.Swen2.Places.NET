using System;
using System.IO;

using FHTW.Swen2.Places.Model;



namespace FHTW.Swen2.Places.ViewModel
{
    /// <summary>This class provides a view model for a story.</summary>
    public sealed class StoryViewModel
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // constructors                                                                                             //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Creates a new instance of this class.</summary>
        /// <param name="parent">Parent view model.</param>
        /// <param name="story">Story.</param>
        public StoryViewModel(MainViewModel parent, Story story)
        {
            Parent = parent;
            Story = story;
        }



        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        // public properties                                                                                        //
        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        /// <summary>Gets the parent main view model.</summary>
        public MainViewModel Parent
        {
            get;
        }


        /// <summary>Gets the story for this view model.</summary>
        public Story Story
        {
            get;
        }


        /// <summary>Gets the image source for the primary image of this story.</summary>
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


        /// <summary>Gets the text for this story.</summary>
        public string Text
        {
            get { return Story.Text; }
        }
    }
}
