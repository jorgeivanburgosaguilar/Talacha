using System;
using System.ComponentModel;

namespace SIPOTCC.SIPOT.Enumeradores
{
    public static class Extensiones
    {
        public static string Descripcion(this Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof (DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}
