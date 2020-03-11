# FluentActivator
I developed this library to facilite the creation dynamic object instances in .NET

Example:

```csharp
FluentActivator
	.SetType(formType)
	.SetArgs(new object[] { global, id })
	.OnBeforeConstructor((instance) =>
	{
	   baseForm = instance as BaseForm;
	
	   if (baseForm != null)
			baseForm.FormId = formRow.FormId;
	})
	.CreateInstance<Form>(ref form);
```