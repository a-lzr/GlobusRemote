using System.ComponentModel.DataAnnotations;

namespace GlobusRemote.Data.Annotations
{
    public class RequiredLocalizedAttribute : RequiredAttribute
    {
        public override string FormatErrorMessage(string name)
        {
            return Localize.Index.FieldValidate_Required_Title;
        }
    }
}
