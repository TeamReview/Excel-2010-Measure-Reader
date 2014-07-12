Excel-2010-Measure-Reader
=========================

The purpose of this project is to demonstrate the access of PowerPivot measures (calculated fields) in Excel 2010 xlsx and xlsm files without opening the files within Excel.  The application is inspired from a manual process described by PowerPivot guru Rob Collie on his PowerPivotPro website (http://www.powerpivotpro.com/2012/10/magic-grab-all-your-measure-formulas-as-text/).

The value offered by the current project is summed up in that it is not limited to accessing a single Excel 2010 file's DAX measures per request, but can concurrently extract DAX measures from files located in multiple directories or across multiple disks.

Special features include the use of DotNetZip (https://dotnetzip.codeplex.com/) to extract data from files without creating copies on disk and without changing their file extensions--the processing is done in your machine's memory.

The measure information is extracted as a single block of text for each Excel file and the results are displayed in a Visual Studio 2010 WinForm application, which also allows the results to be saved as a text file to disk.

Special features include:

* Each Excel 2010 file is opened as memory streams inside of the measure reader application (no need to alter file name on disk or create a special directory for Excel file copies)

* A custom Excel class is really a wrapper around a DotNetZip ZipFile class (the code "lets" Excel extract its own items)

* Multiple Excel 2010 files can be have their measures extracted with a single request

* Files located in different directories, even on different disks, can be processed concurrently

Applies only to Excel 2010 files with PowerPivot data models (not to Excel 2013).


Project Source Code
===================

Source code for this project was developed using Microsoft Visual Studio 2010 Professional Edition.

Installation
============

An .msi and a setup.exe file are located within the directory "Excel 2010 Measure Reader Installer".

Sample Excel File with Data Model
=================================

For demonstration purposes, a copy of an Excel xlsx file with a PowerPivot data model has been included.
