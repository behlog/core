namespace Behlog.Core
{

    public class BehlogInvalidEntityIdException : BehlogException
    {

        public BehlogInvalidEntityIdException() :base() {

        }

        public BehlogInvalidEntityIdException(string entityName)
            : base(message: $"The Entity '{entityName}' Id is not valid."){

        }
    }
}
