using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;

public class DecimalModelBinder : DefaultModelBindingContext {
    public override object BindModel(ControllerContext controllerContext, DefaultModelBindingContext bindingContext) {
        var valueProviderResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

        return valueProviderResult == null ? base.bin BindModel(controllerContext, bindingContext) : Convert.ToDecimal(valueProviderResult.AttemptedValue);

    }
}