using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parser.Validators
{
    // CHAIN OF RESPONSABILITY
    public class ItemValidator
    {
        public static List<string> Validate(Item item)
        {
            Validators.ItemNameValidator itemNameValidator = new Validators.ItemNameValidator();
            Validators.ItemCategoryValidator itemCategoryValidator = new Validators.ItemCategoryValidator();
            Validators.ItemDescriptionValidator itemDescriptionValidator = new Validators.ItemDescriptionValidator();
            Validators.ItemSiteValidator itemSiteValidator = new Validators.ItemSiteValidator();
            Validators.ItemPriceValidator itemPriceValidator = new Validators.ItemPriceValidator();

            itemNameValidator.SetSuccesor(itemCategoryValidator);
            itemCategoryValidator.SetSuccesor(itemDescriptionValidator);
            itemDescriptionValidator.SetSuccesor(itemPriceValidator);
            itemPriceValidator.SetSuccesor(itemSiteValidator);

            return itemNameValidator.HandleValidation(item);
        }
    }
}