using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Validators
{
    public class Validators
    {
        public class ItemNameValidator : ValidatorBase
        {
            public override List<string> HandleValidation(Item item)
            {
                if (String.IsNullOrEmpty(item.name))
                {
                    ErrorsResult.Add("item name is null or empty");
                    return ErrorsResult;
                }

                if (item.name.Length > 255)
                {
                    ErrorsResult.Add("item name is too long (255 max)");
                    return ErrorsResult;
                }

                if (Successor != null)
                {
                    return Successor.HandleValidation(item);
                }

                return ErrorsResult;
            }
        }

        public class ItemCategoryValidator : ValidatorBase
        {
            public override List<string> HandleValidation(Item item)
            {
                if (String.IsNullOrEmpty(item.category))
                {
                    ErrorsResult.Add("item category is null or empty");
                    return ErrorsResult;
                }

                if (item.category.Length > 255)
                {
                    ErrorsResult.Add("item category is too long (255 max)");
                    return ErrorsResult;
                }

                if (Successor != null)
                {
                    return Successor.HandleValidation(item);
                }

                return ErrorsResult;
            }
        }

        public class ItemDescriptionValidator : ValidatorBase
        {
            public override List<string> HandleValidation(Item item)
            {
                if (String.IsNullOrEmpty(item.description))
                {
                    item.description = "No description...";
                }


                if (Successor != null)
                {
                    return Successor.HandleValidation(item);
                }

                return ErrorsResult;
            }
        }

        public class ItemSiteValidator : ValidatorBase
        {
            public override List<string> HandleValidation(Item item)
            {
                if (String.IsNullOrEmpty(item.site))
                {
                    ErrorsResult.Add("item site is null or empty");
                    return ErrorsResult;
                }

                if (item.site.Length > 255)
                {
                    ErrorsResult.Add("item site is too long (255 max)");
                    return ErrorsResult;
                }

                if (Successor != null)
                {
                    return Successor.HandleValidation(item);
                }

                return ErrorsResult;
            }
        }

        public class ItemPriceValidator : ValidatorBase
        {
            public override List<string> HandleValidation(Item item)
            {
                if (item.price.Length > 32)
                {
                    ErrorsResult.Add("item price is too long (16 max)");
                    return ErrorsResult;
                }

                if (Successor != null)
                {
                    return Successor.HandleValidation(item);
                }

                return ErrorsResult;
            }
        }

    }
}
