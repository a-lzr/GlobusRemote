using System;
using System.ComponentModel.DataAnnotations;

namespace GlobusRemote.Data.Annotations
{
    public class RangeLocalizedAttribute : RangeAttribute
    {
        public RangeLocalizedAttribute(double minimum, double maximum) : base(minimum, maximum) {}
        public RangeLocalizedAttribute(int minimum, int maximum) : base(minimum, maximum) {}
        public RangeLocalizedAttribute(Type type, string minimum, string maximum) : base(type, minimum, maximum) {}
        public override string FormatErrorMessage(string name)
        {
            return $"{Localize.Index.FieldValidate_Range_Title1} {Minimum} {Localize.Index.FieldValidate_Range_Title2} {Maximum} {Localize.Index.FieldValidate_Range_Title3}";
        }
    }
}
