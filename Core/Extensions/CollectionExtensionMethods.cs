using Core.Validation;
using System.Text;

namespace Core.Extensions
{
    public static class CollectionExtensionMethods
    {
        public static string ValidationErrorMessagesWithNewLine(this List<ValidationErrorModel> model)
        {
            StringBuilder sb = new();
            foreach (var error in model)
            {
                sb.Append(error.ErrorMessage);
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }
    }
}
