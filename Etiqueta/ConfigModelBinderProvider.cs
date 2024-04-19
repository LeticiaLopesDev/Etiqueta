using Etiqueta.ViewModel;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Reflection;

namespace Etiqueta;

public class ConfigModelBinderProvider : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException(nameof(context));
        }

        if (context.Metadata.ModelType.GetTypeInfo().IsGenericType &&
            context.Metadata.ModelType.GetGenericTypeDefinition() == typeof(Config<>))
        {
            Type[] types = context.Metadata.ModelType.GetGenericArguments();
            Type o = typeof(ConfigModelBinder<>).MakeGenericType(types);

            return (IModelBinder)Activator.CreateInstance(o);
        }

        return null;
    }
}
