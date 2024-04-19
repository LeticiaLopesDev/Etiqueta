using Etiqueta.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Etiqueta;

public class ConfigModelBinder<T> : IModelBinder
{
    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        if (bindingContext == null)
        {
            throw new ArgumentNullException(nameof(bindingContext));
        }

        Config<T> config = new Config<T>();

        //TODO: Setup the Config<T> model 

        bindingContext.Result = ModelBindingResult.Success(config);
        return Task.FromResult(config);
    }
}
