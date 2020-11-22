# Timeturner
<p align="center">
    <img src="Xaml-Controls-Gallery-master/XamlControlsGallery/Assets/team9_emblem.png" class="centerImage" width="300"/>
    <br><br>
    Achilles Dabrowski, Aiden Miao, Alex Xu 
</p>
<hr>

## Folders
* **Firmware**: contains the code required to control the device itself. See /Firmware/readme.md for more information.
* **Release**: contains a packaged version of the companion application. It has *not* been digitally signed because we do not have access to certificates from a certificate authority (CA). Self-signing the application would only have allowed the application to be able to be run on the computer on which it was signed.
* **Xaml-Controls-Gallery-master**: contains the the source files for the companion application. See the "Files" section for more information about its name.

## Platform
* Timeturner's companion application is a Universal Windows Platform (UWP) application.
* It can only be run in Windows 10. 
* Machines that are not natively running Windows 10 must run Windows 10 in a virtual environment or natively through a dual-boot configuration where both the original operating system and Windows 10 are installed on the machine.

## Files
#### The companion application was originally built on a template from Microsoft for UWP applications. For this reason, many of the pages have names that do not describe their purpose. Changing each of these names would have required a significant amount of refactoring and Visual Studio, the IDE that was used, does not always automatically rename files or symbols in all of their usages across a codebase. 

#### XAML files are used for scaffolding and CS files files are used for setting interaction events. This pairing can be thought of as an alternative to HTML and JavaScript.
<br>

### Below is a map of each file to its purpose as it appears in the application. Relative paths are given for each file.
<br>

#### *Settings*
*  **Device Sounds:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ButtonPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ButtonPage.xaml.cs
*  **Notifications:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/DropDownButtonPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/DropDownButtonPage.xaml.cs
*  **Activities:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/HyperlinkButtonPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/HyperlinkButtonPage.xaml.cs
*  **Activities:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/HyperlinkButtonPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/HyperlinkButtonPage.xaml.cs

#### *Calendar*
*  **View:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/AutomationPropertiesPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/AutomationPropertiesPage.xaml.cs
*  **Add:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ProgressBarPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ProgressBarPage.xaml.cs
*  **Delete:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ProgressRingPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ProgressRingPage.xaml.cs

#### *Device*
*  **Status:**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ContentDialogPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ContentDialogPage.xaml.cs

#### *Reports*
*  **Insights**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ScrollViewerPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/ScrollViewerPage.xaml.cs
*  **Data**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/SemanticZoomPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/SemanticZoomPage.xaml.cs

#### *Miscellaneous*
*  **Calendar login form**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CalendarInfoForm.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CalendarInfoForm.xaml.cs
*  **Calendar loading**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CalendarLoading.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CalendarLoading.xaml.cs
*  **Calendar login successful**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CalendarAddComplete.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CalendarAddComplete.xaml.cs
*  **Current activity display when device is flipped**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CurrentActivityPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ControlPages/CurrentActivityPage.xaml.cs
*  **Wrapper page for all menus (used as launching point for current activity page)**
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ItemPage.xaml
   *  /Xaml-Controls-Gallery-master/XamlControlsGallery/ItemPage.xaml.cs