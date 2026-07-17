using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Interfaces.AspNetCore.Configuration.Extensions;

namespace Whoop.HardwareTelemetry.Platform.u202315165.Shared.Infrastructure.Interfaces.AspNetCore.Configuration;

/// <summary>
///     Applies kebab-case naming for controller route tokens.
/// </summary>
/// <remarks>Josep Eliu Melgarejo Quiroz</remarks>
public class KebabCaseRouteNamingConvention : IControllerModelConvention
{
    /// <inheritdoc />
    public void Apply(ControllerModel controller)
    {
        foreach (var selector in controller.Selectors)
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);

        foreach (var selector in controller.Actions.SelectMany(action => action.Selectors))
            selector.AttributeRouteModel = ReplaceControllerTemplate(selector, controller.ControllerName);
    }

    private static AttributeRouteModel? ReplaceControllerTemplate(SelectorModel selector, string name)
    {
        return selector.AttributeRouteModel is null
            ? null
            : new AttributeRouteModel
            {
                Template = selector.AttributeRouteModel.Template?.Replace("[controller]", name.ToKebabCase())
            };
    }
}
