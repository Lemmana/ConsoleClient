# Lemmana API Guide (C#)


## Overview
The Lemmana API gives you access to a set of secure data extraction features for use in your own applications such as document upload, classification and entity extraction/management and document deletion/management. It is a RESTful service and it is organized around the main resources used in the Lemmana web interface.

The sample application is intended to demonstrate the basic usage of the Lemmana REST service. It can be used as the basis for building further calls into Lemmana and for use in your applications.

Please Note: The sample application is intended as a guide to get you started. Any production usage will need to be tested and supported by the implementing systems integrator. Lemmana is not responsible for management and usage of your client code.

## Detailed Documentation

This sample only shows calling a sub set of the available Lemmana REST endpoints. It is not intended to be a complete application showing all the features of the Lemmana system.

## Sample Application Setup

The application requires that you download the latest versions of NewtonSoft JSON.Net and RestSharp HTTP Client libraries using NuGet Package Manager. Please ensure their relevant licenses comply with your company policies prior to use.


Windows Visual Studio
1.	Select Tools > NuGet Package Manager
2.	Set Package Source to ‘All’
3.	Search ‘Newtonsoft’ and install ‘Newtonsoft.Json’
4.	Search ‘RestSharp’ and install ‘RestSharp’

Mac Visual Studio
1.	Right click on ‘Packages’ in the solution tree view and select ‘Add Packages’
2.	Search ‘Json.net’ and install ‘Newtonsoft.Json’
3.	Search ‘RestSharp’ and install ‘RestSharp’


## Sample Application Process

The process of the C# sample application is as follows:

1.	Add the user token to urlLocal in Program.cs. To obtain the token sign into Lemmana and select account from the menu.
2.  Run the program to upload a document called Test.pdf
3.  Program.cs demonstrates uploading a document, polling for the status of the document and retrieving it when complete.


## Disclaimer
Software downloaded from Lemmana, GitHub or other sharing sites is provided 'as is' without warranty of any kind, either express or implied, including, but not limited to, the implied warranties of fitness for a purpose, or the warranty of non-infringement. Without limiting the foregoing, Lemmana makes no warranty that:

i.	the software will meet your requirements

ii.	the software will be uninterrupted, timely, secure or error-free

iii.	the results that may be obtained from the use of the software will be effective, accurate or reliable

iv.	the quality of the software will meet your expectations

v.	any errors in the software obtained from Lemmana will be corrected


Software and its documentation made available on the Lemmana the web site, GitHub or other sharing sites:

vi.	could include technical or other mistakes, inaccuracies or typographical errors. Lemmana may make changes to the software or documentation made available on its web site.

vii.	may be out of date, and Lemmana makes no commitment to update such materials.


Lemmana assumes no responsibility for errors or omissions in the software or documentation available from its web site, GitHub or other sharing sites.

In no event shall Lemmana be liable to you or any third parties for any special, punitive, incidental, indirect or consequential damages of any kind, or any damages whatsoever, including, without limitation, those resulting from loss of use, data or profits, whether or not Lemmana has been advised of the possibility of such damages, and on any theory of liability, arising out of or in connection with the use of this software.


The use of the software downloaded through the Lemmana site, GitHub or other sharing sites is done at your own discretion and risk and with agreement that you will be solely responsible for any damage to your computer system or loss of data that results from such activities. No advice or information, whether oral or written, obtained by you from Lemmana or from the Lemmana web site shall create any warranty for the software.
