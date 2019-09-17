using System.Collections;

namespace Framework.CRUD.Models
{
    public class DefaultErrors
    {
        public ArrayList ErrorList { get; set; }

        public void Reject(string errorCode, string errorMessage = null, string developerMessage = null)
        {
            var defaultError = new DefaultError
            {
                ErrorCode = errorCode,
                ErrorMessage = errorMessage,
                DeveloperMessage = developerMessage
            };

            if (ErrorList == null)
            {
                ErrorList = new ArrayList();
            }
            
            ErrorList.Add(defaultError);
        }
    }
}