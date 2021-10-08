using System.ComponentModel.DataAnnotations;

namespace GlobusRemote.Data.Annotations
{
    public class MaxLengthLocalizedAttribute : MaxLengthAttribute
    {
        public MaxLengthLocalizedAttribute(int length) : base(length) { }

        public override string FormatErrorMessage(string name)
        {
            return $"{Localize.Index.FieldValidate_Max_Title1} {Length} {Localize.Index.FieldValidate_Max_Title2}";
        }
    }
}
