# FluentActivator
I developed this library to facilite the creation dynamic object instances in .NET

Example:

```csharp
FluentActivator
	.SetType(formType)
	.SetArgs(new object[] { arg1, arg2})
	.OnBeforeConstructor((instance) => {
		BaseForm baseForm = instance as BaseForm;
		
		if (baseForm != null)
			baseForm.FormId = formRow.FormId;
	})
	.CreateInstance<Form>(ref form);
```