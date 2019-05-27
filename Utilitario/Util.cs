using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Utilitario
{
    public static class Util
    {
        public static string PegaDescricaoEnum(Enum valor)
        {
            FieldInfo field = valor.GetType().GetField(valor.ToString());
            DescriptionAttribute attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? valor.ToString() : attribute.Description;

        }
    }
}
