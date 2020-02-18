using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace GymShop
{
    public class Enums
    {
        public enum Title
        {
            Mr,
            Mrs,
            Miss,
            Ms
        }

        public enum MassUnit
        { 
            g,
            kg
        }

        public enum Delivery
        { 
            InStore,
            Post
        }

        // Helper method to display the name of the enum values.
        public static string GetDisplayName(Enum value)
        {
            return value.GetType()?
                .GetMember(value.ToString())?.First()?
                .GetCustomAttribute<DisplayAttribute>()?
                .Name;
        }
    }
}