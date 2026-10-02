using System;

namespace AppHub
{
    public class Tool
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconName { get; set; }
        public string Link { get; set; }

        public Tool(string title, string description, string iconName, string link)
        {
            Title = title;
            Description = description;
            IconName = iconName;
            Link = link;
        }
    }
}
