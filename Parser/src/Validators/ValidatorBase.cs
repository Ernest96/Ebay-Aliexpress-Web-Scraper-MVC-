using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Validators
{
    public abstract class ValidatorBase
    {
        protected ValidatorBase Successor { get; private set; }
        protected List<string> ErrorsResult { get; set; }

        protected ValidatorBase()
        {
            ErrorsResult = new List<string>();
        }

        public abstract List<string> HandleValidation(Item item);

        public void SetSuccesor(ValidatorBase successor)
        {
            this.Successor = successor;
        }
    }
}