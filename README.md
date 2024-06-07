# PC Manager Application  ![Logo](https://github.com/TopxT750/PC-Manager/blob/master/Resources/PC%20Manager.png)

PC Manager is a modern and sleek application designed to help users optimize and manage their computers efficiently. Inspired by popular PC management tools like Microsoft's PC Manager, this application provides a user-friendly interface and powerful features to keep your system running smoothly.

## Features

- **System Optimization**: Clean junk files, manage startup programs, and optimize system performance.
- **Resource Monitoring**: Monitor CPU, RAM, disk usage, and network activity in real-time.
- **Software Management**: Install, update, and uninstall applications seamlessly.
- **Custom Installer**: A modern, easy-to-use installer for deploying the application.

## Screenshots

![Main Interface](https://github.com/TopxT750/PC-Manager/assets/71926499/1b38ffc2-a313-49d1-9182-b0d09e7ddbd7)
![image](https://github.com/TopxT750/PC-Manager/assets/71926499/57d75f4e-3328-4355-a0b5-9e5e731aeb7b)
![image](https://github.com/TopxT750/PC-Manager/assets/71926499/166bbec9-6232-4395-901b-372646b27a04)


## Installation

### Prerequisites

- Windows 7 or higher
- .NET Framework 4.7.2 or later

### Steps

1. **Download the Installer**: Get the latest version of the installer from the [Releases](https://github.com/TopxT750/pc-manager/releases) page.
2. **Run the Installer**: Double-click the installer file and follow the on-screen instructions.
3. **Launch the Application**: After installation, launch the application from the Start Menu or Desktop shortcut.

## Building from Source

To build PC Manager from the source code, follow these steps:

### Prerequisites

- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/)
- .NET Framework 4.7.2 SDK
- [Guna UI Framework](https://gunaui.com/)

### Steps

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/yourusername/pc-manager.git
   cd pc-manager
   ```

2. **Open the Solution**:
   Open `PC Manager.sln` in Visual Studio.

3. **Restore NuGet Packages**:
   Visual Studio should automatically restore the required NuGet packages. If not, go to `Tools > NuGet Package Manager > Manage NuGet Packages for Solution` and restore them manually.

4. **Build the Solution**:
   Build the solution by selecting `Build > Build Solution` or pressing `Ctrl+Shift+B`.

5. **Run the Application**:
   Start debugging by pressing `F5` or selecting `Debug > Start Debugging`.

## Usage

1. **System Optimization**:
   - Open the application and navigate to the `System Optimization` tab.
   - Click `Scan` to detect junk files and other optimizable areas.
   - Click `Clean` to optimize your system.

2. **Resource Monitoring**:
   - Navigate to the `Resource Monitoring` tab to view real-time statistics of CPU, RAM, disk usage, and network activity.

3. **Software Management**:
   - Go to the `Software Management` tab to see installed applications.
   - Use the `Install`, `Update`, or `Uninstall` buttons to manage your software.

## Contributing

Contributions are welcome! If you have suggestions for new features, improvements, or bug fixes, feel free to open an issue or submit a pull request.

### Steps to Contribute

1. **Fork the Repository**: Click the `Fork` button at the top right of this page.
2. **Clone Your Fork**:
   ```sh
   git clone https://github.com/yourusername/pc-manager.git
   cd pc-manager
   ```
3. **Create a Branch**:
   ```sh
   git checkout -b feature/your-feature-name
   ```
4. **Make Changes**: Implement your feature or bug fix.
5. **Commit Your Changes**:
   ```sh
   git commit -m "Add feature/fix: describe your changes"
   ```
6. **Push to Your Fork**:
   ```sh
   git push origin feature/your-feature-name
   ```
7. **Open a Pull Request**: Go to the original repository and click `New Pull Request`.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.

## Acknowledgments

- **Microsoft** for the inspiration from their PC Manager tool.
- **Guna UI Framework** for providing modern UI controls.
- **Open Source Community** for the valuable libraries and tools used in this project.

---

Thank you for using PC Manager! We hope it helps you keep your system running smoothly.
```