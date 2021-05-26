<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/MultipleDataSources/Form1.cs) (VB: [Form1.vb](./VB/MultipleDataSources/Form1.vb))
* [Program.cs](./CS/MultipleDataSources/Program.cs) (VB: [Program.vb](./VB/MultipleDataSources/Program.vb))
* [XPOClasses.cs](./CS/MultipleDataSources/XPOClasses.cs) (VB: [XPOClasses.vb](./VB/MultipleDataSources/XPOClasses.vb))
<!-- default file list end -->
# How to Bind a Snap Document to Multiple Data Dources in Code

> Snap for WinForms is currently in maintenance support mode. As such, no new features/capabilities will be incorporated into this product.

<p>This example illustrates how you can bind a Snap document to multiple data sources:</p>

* XPCollections with <a href="https://docs.devexpress.com/XPO/2257/getting-started/tutorial-2-relations-one-to-many?v=19.2">one-to-many relationship</a>
* a data table contained in the <a href="https://docs.microsoft.com/en-US/dotnet/api/system.data.dataset">DataSet</a> object
* <a href="https://docs.devexpress.com/WindowsForms/115529/common-features/data-binding/binding-to-excel-data-sources">Excel data source</a>
 
<p>Use the <strong>SnapControl.Options.SnapMailMergeVisualOptions.DataSourceName</strong> property to set one of the available data sources as the mail merge source.</p>
