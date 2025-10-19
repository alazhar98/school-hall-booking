// Print function for specific elements
window.printElement = function(elementId) {
    const element = document.getElementById(elementId);
    if (!element) {
        console.error('Element not found:', elementId);
        return;
    }

    // Create a new window for printing
    const printWindow = window.open('', '_blank');
    
    // Get the element's HTML content
    const elementHTML = element.outerHTML;
    
    // Create the print document
    printWindow.document.write(`
        <!DOCTYPE html>
        <html dir="rtl" lang="ar">
        <head>
            <meta charset="utf-8">
            <title>جدول المناوبة الأسبوعية</title>
            <style>
                body {
                    font-family: 'Segoe UI', 'Tahoma', 'Arial', sans-serif;
                    direction: rtl;
                    text-align: right;
                    margin: 20px;
                }
                .card {
                    border: 1px solid #ddd;
                    border-radius: 8px;
                    margin-bottom: 20px;
                }
                .card-header {
                    background-color: #198754;
                    color: white;
                    padding: 15px;
                    border-radius: 8px 8px 0 0;
                }
                .card-body {
                    padding: 15px;
                }
                table {
                    width: 100%;
                    border-collapse: collapse;
                    margin-top: 10px;
                }
                th, td {
                    border: 1px solid #ddd;
                    padding: 8px;
                    text-align: center;
                }
                th {
                    background-color: #f8f9fa;
                    font-weight: bold;
                }
                .table-responsive {
                    overflow-x: auto;
                }
                @media print {
                    body { margin: 0; }
                    .card { border: none; box-shadow: none; }
                }
            </style>
        </head>
        <body>
            <h1 style="text-align: center; margin-bottom: 30px;">جدول المناوبة الأسبوعية</h1>
            ${elementHTML}
        </body>
        </html>
    `);
    
    printWindow.document.close();
    
    // Wait for content to load then print
    printWindow.onload = function() {
        printWindow.print();
        printWindow.close();
    };
};

// Function to get data attribute from element
window.getElementData = function(element, attributeName) {
    if (!element) return '';
    return element.getAttribute('data-' + attributeName) || '';
};

// Function to download file from base64 data or CSV content
window.downloadFile = function(fileName, data, mimeType) {
    try {
        let blob;
        
        // Check if data is base64 encoded (Excel files)
        if (mimeType && mimeType.includes('openxmlformats')) {
            // Convert base64 to blob for Excel files
            const byteCharacters = atob(data);
            const byteNumbers = new Array(byteCharacters.length);
            for (let i = 0; i < byteCharacters.length; i++) {
                byteNumbers[i] = byteCharacters.charCodeAt(i);
            }
            const byteArray = new Uint8Array(byteNumbers);
            blob = new Blob([byteArray], { type: mimeType || 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
        } else {
            // Handle CSV or text content
            const contentType = mimeType || 'text/csv;charset=utf-8;';
            blob = new Blob([data], { type: contentType });
        }
        
        // Create download link
        const url = window.URL.createObjectURL(blob);
        const link = document.createElement('a');
        link.href = url;
        link.download = fileName;
        
        // Trigger download
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        
        // Clean up
        window.URL.revokeObjectURL(url);
        
        console.log('File downloaded successfully:', fileName);
    } catch (error) {
        console.error('Error downloading file:', error);
        alert('فشل تحميل الملف. يرجى المحاولة مرة أخرى.');
    }
};

// Function to download HTML file
window.downloadHTMLFile = function(fileName, htmlContent) {
    try {
        // Create blob from HTML content
        const blob = new Blob([htmlContent], { type: 'text/html;charset=utf-8' });
        
        // Create a link element
        const link = document.createElement('a');
        link.href = URL.createObjectURL(blob);
        link.download = fileName;
        document.body.appendChild(link);
        link.click();
        document.body.removeChild(link);
        URL.revokeObjectURL(link.href);
        
        // Open the file in a new tab for printing
        const printWindow = window.open();
        printWindow.document.write(htmlContent);
        printWindow.document.close();
        
        // Show print dialog after a short delay
        setTimeout(() => {
            printWindow.print();
        }, 500);
        
        console.log('HTML file downloaded and opened for printing:', fileName);
    } catch (e) {
        console.error("Error downloading HTML file:", e);
        alert("فشل تحميل الملف. يرجى المحاولة مرة أخرى.");
    }
};

// Function to export data to Excel (legacy - use interop.js instead)
// This function is kept for backward compatibility but should not be used
// Use window.blazorInterop.exportToExcel(elementId, fileName) instead

// Function to export HTML to PDF (legacy - use interop.js instead)
// This function is kept for backward compatibility but should not be used
// Use window.blazorInterop.exportToPDF(elementId, fileName) instead

// Function to show confirmation dialog
window.confirmDialog = function(message) {
    return window.confirm(message);
};

// Function to print HTML content to PDF (alias for exportToPDF)
window.printToPDF = function(htmlContent, fileName) {
    try {
        if (typeof window.exportToPDF === 'function') {
            return window.exportToPDF(htmlContent, fileName);
        } else {
            console.error('exportToPDF function not available');
            alert('وظيفة الطباعة غير متاحة. يرجى تحديث الصفحة والمحاولة مرة أخرى.');
        }
    } catch (error) {
        console.error('Error in printToPDF:', error);
        alert('فشل في طباعة PDF. يرجى المحاولة مرة أخرى.');
    }
};

// Ensure all functions are available when the page loads
document.addEventListener('DOMContentLoaded', function() {
    console.log('JavaScript interop functions loaded successfully');
    console.log('Available functions:', {
        downloadFile: typeof window.downloadFile,
        printToPDF: typeof window.printToPDF,
        exportToPDF: typeof window.exportToPDF,
        exportToExcel: typeof window.exportToExcel
    });
});

