<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128608564/16.1.4%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E4784)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/MultipleDataSources/Form1.cs) (VB: [Form1.vb](./VB/MultipleDataSources/Form1.vb))
* [Program.cs](./CS/MultipleDataSources/Program.cs) (VB: [Program.vb](./VB/MultipleDataSources/Program.vb))
* [XPOClasses.cs](./CS/MultipleDataSources/XPOClasses.cs) (VB: [XPOClasses.vb](./VB/MultipleDataSources/XPOClasses.vb))
<!-- default file list end -->
# How to Bind a Snap Document to Multiple Data Dources in Code

> **Note**
>
> As you may already know, the [WinForms Snap control](https://docs.devexpress.com/WindowsForms/11373/controls-and-libraries/snap) and [Snap Report API](https://docs.devexpress.com/OfficeFileAPI/15188/snap-report-api) are now in maintenance support mode. No new features or capabilities are incorporated into these products. We recommend that you use [DevExpress Reporting](https://docs.devexpress.com/XtraReports/2162/reporting) tool to generate, edit, print, and export your business reports/documents.

<p>This example illustrates how you can bind a Snap document to multiple data sources:</p>

* XPCollections with <a href="https://docs.devexpress.com/XPO/2257/getting-started/tutorial-2-relations-one-to-many?v=19.2">one-to-many relationship</a>
* a data table contained in the <a href="https://docs.microsoft.com/en-US/dotnet/api/system.data.dataset">DataSet</a> object
* <a href="https://docs.devexpress.com/WindowsForms/115529/common-features/data-binding/binding-to-excel-data-sources">Excel data source</a>
 
<p>Use the <strong>SnapControl.Options.SnapMailMergeVisualOptions.DataSourceName</strong> property to set one of the available data sources as the mail merge source.</p>
