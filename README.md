# Notes  ![Logo](https://github.com/TopxT750/Notes/blob/release/Notes/Resources/Notes.png)

Notes is a modern and sleek application designed to help users efficiently manage their notes and text documents. Inspired by Windows Notepad, this application provides a user-friendly interface and powerful features to enhance your note-taking and text editing experience.

## Features

- **Multi-Tab Interface**: Work with multiple documents simultaneously using tabbed browsing.
- **Rich Text Formatting**: Customize your text with various fonts, colors, and styles.
- **File Management**: Easily open, save, and manage text and rich text files.
- **Custom Title Bar**: Enjoy a modern look with a borderless form and custom title bar.

## Screenshots

![Main Interface](https://github.com/TopxT750/Notes/assets/71926499/67eccf13-2d61-4ae4-a1f2-b52b79d2bfae)

## Installation

### Prerequisites

- Windows 7 or higher
- .NET Framework 4.7.2 or later

### Steps

1. **Download the Installer**: Get the latest version of the installer from the [Releases](https://github.com/TopxT750/notes/releases) page.
2. **Run the Installer**: Double-click the installer file and follow the on-screen instructions.
3. **Launch the Application**: After installation, launch the application from the Start Menu or Desktop shortcut.

## Building from Source

To build Notes from the source code, follow these steps:

### Prerequisites

- [Visual Studio 2019 or later](https://visualstudio.microsoft.com/)
- .NET Framework 4.7.2 SDK
- [Guna UI Framework](https://gunaui.com/)

### Steps

1. **Clone the Repository**:
   ```sh
   git clone https://github.com/yourusername/notes.git
   cd notes
   ```

2. **Open the Solution**:
   Open `Notes.sln` in Visual Studio.

3. **Restore NuGet Packages**:
   Visual Studio should automatically restore the required NuGet packages. If not, go to `Tools > NuGet Package Manager > Manage NuGet Packages for Solution` and restore them manually.

4. **Build the Solution**:
   Build the solution by selecting `Build > Build Solution` or pressing `Ctrl+Shift+B`.

5. **Run the Application**:
   Start debugging by pressing `F5` or selecting `Debug > Start Debugging`.

## Usage

1. **Multi-Tab Interface**:
   - Click the `New Tab` button to create a new tab for your document.
   - Each new tab will be named "New Note 1", "New Note 2", and so on.

2. **Rich Text Formatting**:
   - Use the formatting toolbar to change fonts, text color, and apply styles like bold or italics.

3. **File Management**:
   - Open documents from the `File` menu.
   - Save your work with `Save` or `Save As` options.

## Contributing

Contributions are welcome! If you have suggestions for new features, improvements, or bug fixes, feel free to open an issue or submit a pull request.

### Steps to Contribute

1. **Fork the Repository**: Click the `Fork` button at the top right of this page.
2. **Clone Your Fork**:
   ```sh
   git clone https://github.com/yourusername/notes.git
   cd notes
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

- **Microsoft** for the inspiration from their Notepad tool.
- **Guna UI Framework** for providing modern UI controls.
- **Icons8** for the valuable icons used in this project.
- **Open Source Community** for the valuable libraries and tools used in this project.

Thank you for using Notes! We hope it helps you manage your notes and text documents more effectively.
