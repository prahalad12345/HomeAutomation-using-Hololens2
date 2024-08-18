# HomeAutomation-using-Hololens2

**Hololens2 controller application for having control over the home lighting and fans**

## Glossary
| Term      | Description |
| ----------- | ----------- |
| Mixed Reality      | Mixed reality is a blend of physical and digital worlds, unlocking natural and intuitive 3D human, computer, and environmental interactions. This new reality is based on advancements in computer vision, graphical processing, display technologies, input systems, and cloud computing.Here our motive is to control my home |
| MRTK3  | MRTK3 is the third generation of Microsoft Mixed Reality Toolkit for Unity. It's a Microsoft-driven open-source project to accelerate cross-platform mixed reality development in Unity. This new version is built on top of Unity's XR Management system and XR Interaction Toolkit|
| HomeAutomation | Home automation refers to the use of technology to control and automate various household systems and devices. This can include lighting, heating, ventilation, air conditioning (HVAC), security systems, appliances, and entertainment systems. The goal of home automation is to enhance comfort, convenience, security, and energy efficiency.|
| UWP Socket | UWP (Universal Windows Platform) socket programming involves creating applications that can communicate over a network using sockets, which are endpoints for sending and receiving data between devices or services. Sockets allow for both TCP (Transmission Control Protocol) and UDP (User Datagram Protocol) communication, enabling the creation of a wide range of networked applications, such as chat clients, web services, or IoT (Internet of Things) devices. |



## About HomeAutomation-Hololens-App
The HomeAutomation-Hololens is an application for Hololens2 which is built specifically for my home , to control the appliances around me.

![IntroScreen](https://github.com/prahalad12345/HomeAutomation-using-Hololens2/blob/main/Image/20240818_072732_HoloLens.jpg)

## Purpose of HomeAutomation application?


* Innovative Mixed Reality Integration: This application enhances the convenience of home automation by integrating Mixed Reality, offering a modular and immersive way to control appliances. Instead of relying on traditional switches, users can access and manage their devices seamlessly through an intuitive interface.

* User-Friendly Home Automation Interface: The HomeAutomation-App provides a streamlined and user-friendly interface to control home appliances, building on an existing home automation setup. The controls are designed for maximum convenience, allowing users to manage their environment with ease.Have added voice commands to easily access the menu , This feature is a part of MRTK3.

[![IMAGE ALT TEXT HERE](https://www.youtube.com/watch?v=U-ST1nyrA8U)](https://www.youtube.com/watch?v=U-ST1nyrA8U)


## Data used by the home automation

Initially tried homebridge integration and using its api to integrate.(https://github.com/markbegma/homebridge-hdl-buspro). But this doesn't work since on sniffing the packet figure out that the packet doesn't go to HDL gateway but rather goes to another gateway, hence was difficult to track the overall path.

![Working Architecture](https://github.com/prahalad12345/HomeAutomation-using-Hololens2/blob/main/Image/Smart-Home-Working.png). 

Home automation usually involves the user processing a command voice ,phone application etc. Which head towards the gateway IP address and moves to the cloud server. After processing heads back to the home network and broadcasted.

I used sniffing tool (Wireshark), to check the packets which are being sent.I also found an article which has a datasheet of the packets being sent(https://www.scribd.com/document/324212485/HDL-BUS-Pro-UDP-protocal-and-device-type-Eng-pdf ).Both map well.

![Working Architecture](https://github.com/prahalad12345/HomeAutomation-using-Hololens2/blob/main/Image/unnamed.png). 


## Prerequisites
Make sure you have installed all of the following prerequisites on your development machine:

**1. Host PC setup:(through which deployment is done on Hololens2)**

* Git - [Download & Install Git](https://git-scm.com/downloads). OSX and Linux machines typically have this already installed.
* Unity - [Download & Install Unity](https://docs.unity3d.com/hub/manual/index.html). OSX and Linux machines typically have this already installed.
* Mixed Reality Toolkit 3(MRTK3) - [Download & Install MRTK3](https://learn.microsoft.com/en-us/windows/mixed-reality/mrtk-unity/mrtk3-overview/). Latest Mixed reality development toolkit by Microsoft.

**2. Testing Purposes**

* Python - [Download & Install Python3](https://www.geeksforgeeks.org/download-and-install-python-3-latest-version/) 

## Installation

**1. Host PC setup:**

Clone this unity repository which consist of the complete Homeautomation App. Add this project to the Unity Hub.The project is preinstalled with MRTK3 which enables Mixed reality development features.Modification of the flow and dialogs in the application might require changes.


Go to Assets->Scene . Click on SampleScene to enable access to the application.

Build The project in UWP(refer the Hololens2 fundamental course).

![My Room Menu](https://github.com/prahalad12345/HomeAutomation-using-Hololens2/blob/main/Image/20240818_072903_HoloLens.jpg)


## Next Step
1. Integrate CNN to the project . On Reaching a specific room the menu's of the room should pop up.
2. Localizing menu for each of the appliances in the room.Eg - On looking at a fan I should get the slider to control it , on looking away the menu should vanish.

## Reference

| Topic      | Reference Link |
| ----------- | ----------- |
| HoloLens 2 fundamentals: develop mixed reality applications | https://learn.microsoft.com/en-us/training/paths/beginner-hololens-2-tutorials/ |
| smart-bus-gadget(for HDL ON) | https://www.npmjs.com/package/smart-bus-mrgadget  |
| Example of Home automation  | https://www.roadtomr.com/2016/04/21/632/home-automation-with-hololens/ |
| Python Library for Smartbus | https://github.com/eyesoft/home_assistant_buspro/tree/main/custom_components/buspro/pybuspro  |


## License

Homeautomation-Hololens2 is completely free and open-source 