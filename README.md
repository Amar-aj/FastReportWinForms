# FastReport JSON Viewer & PDF Preview Demo

A modern C# Windows Forms application demonstrating how to load, filter, and report on JSON data using FastReport OpenSource, with integrated PDF previewing via WebView2.

![Application Mockup](https://raw.githubusercontent.com/FastReports/FastReport/master/FastReport.png)

## 🚀 Features

-   **Dynamic JSON Loading**: Automatically deserializes JSON data from a local file into a list of objects.
-   **Real-time Filtering**: Instantly filters the data grid and report output as you type.
-   **FastReport Integration**: Dynamically generates professional reports using business objects.
-   **Embedded PDF Preview**: Converts reports to PDF bytes and displays them side-by-side using the modern Microsoft WebView2 (Edge) control.
-   **Responsive UI**: Uses a split-container layout for a seamless data entry/preview experience.

## 🛠️ Tech Stack

-   **.NET 10.0** (Windows Forms)
-   **FastReport.OpenSource**: Core reporting engine.
-   **FastReport.OpenSource.Export.PdfSimple**: Lightweight PDF export for OpenSource version.
-   **WebView2**: Chromium-based viewer for modern PDF rendering.
-   **System.Text.Json**: Fast and efficient JSON serialization.

## 📋 Prerequisites

To run this project, ensure you have:
1.  [.NET 10.0 SDK](https://dotnet.microsoft.com/download) or later.
2.  [WebView2 Runtime](https://developer.microsoft.com/en-us/microsoft-edge/webview2/) (usually pre-installed on Windows 10/11).
3.  Visual Studio 2022 or VS Code.

## ⚙️ Installation

1.  **Clone the repository**:
    ```bash
    git clone https://github.com/Amar-aj/FastReportWinForms.git
    cd FastReportWinForms/FastReportWinForms
    ```

2.  **Restore dependencies**:
    ```bash
    dotnet restore
    ```

3.  **Run the application**:
    ```bash
    dotnet run
    ```

## 📖 How It Works

1.  **The Data**: The app loads `Data/64KB.json` on startup.
2.  **The Filter**: Type in the Search box to filter records.
3.  **The Report**:
    -   Click **"Generate PDF"**.
    -   The app prepares a FastReport instance.
    -   It registers the *filtered* data as a `List<Person>`.
    -   The report is exported to a `MemoryStream` as PDF bytes.
    -   The bytes are saved as a temporary file and navigated to by the `WebView2` control.

## 📂 Project Structure

-   `Form1.cs`: Contains the core logic for data management and reporting.
-   `Reports/demo.frx`: The FastReport template defining the layout.
-   `Data/64KB.json`: Sample JSON dataset.
-   `FastReportWinForms.csproj`: Project configuration and package references.

## 📄 License

This project is open-source and available under the [MIT License](LICENSE).
