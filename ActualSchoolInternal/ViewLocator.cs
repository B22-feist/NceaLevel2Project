using ActualSchoolInternal.ViewModels;
using Avalonia.Controls;
using Avalonia.Controls.Templates;

namespace ActualSchoolInternal;

public class ViewLocator : IDataTemplate
{
	public Control? Build(object? param)
	{
		if (param is null)
			return null;

		string name = param.GetType().FullName!.Replace("ViewModel", "View", StringComparison.Ordinal);
		Type? type = Type.GetType(name);

		if (type != null)
		{
			return (Control)Activator.CreateInstance(type)!;
		}

		return new TextBlock { Text = "Not Found: " + name };
	}
	public bool Match(object? data)
	{
		return data is PageViewModelBase;
	}
}