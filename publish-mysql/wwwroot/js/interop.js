// JavaScript interop functions for Blazor
window.blazorInterop = {
    // Export to Excel function
        exportToExcel: function (elementId, fileName) {
            try {
                const element = document.getElementById(elementId);
                if (!element) {
                    alert('العنصر المطلوب تصديره غير موجود: ' + elementId);
                    return;
                }

                // Check if table has data
                const tableRows = element.querySelectorAll('tbody tr');
                
                if (tableRows.length === 0) {
                    alert('لا توجد بيانات للتصدير');
                    return;
                }

                // Get table headers
                const headerCells = element.querySelectorAll('thead th');
                const headers = Array.from(headerCells).map(cell => cell.textContent.trim());
                
                // Get table data
                const csvContent = window.blazorInterop.convertTableToCSV(element, headers);
                
                // Create blob with proper MIME type for RTL
                const blob = new Blob([csvContent], { 
                    type: 'text/csv;charset=utf-8;' 
                });
                
                const link = document.createElement('a');
                link.href = URL.createObjectURL(blob);
                link.download = fileName + '.csv';
                link.style.direction = 'rtl';
                document.body.appendChild(link);
                link.click();
                document.body.removeChild(link);
                URL.revokeObjectURL(link.href);
                
            } catch (e) {
                alert("فشل تصدير الملف. يرجى المحاولة مرة أخرى.");
            }
        },

    // Convert table to CSV
    convertTableToCSV: function (table, headers) {
        let csvContent = '';
        
        // Add BOM for UTF-8 and RTL marker
        csvContent += '\ufeff';
        
        // Add RTL marker for Excel
        csvContent += '\u200F';
        
        // Add headers (reverse order for RTL)
        const reversedHeaders = headers.slice().reverse();
        csvContent += reversedHeaders.map(header => `"\u200F${header.replace(/"/g, '""')}"`).join(',') + '\n';
        
        // Add data rows (reverse order for RTL)
        const rows = table.querySelectorAll('tbody tr');
        rows.forEach((row) => {
            const cells = row.querySelectorAll('td');
            const values = Array.from(cells).reverse().map((cell) => {
                let text = cell.textContent.trim();
                // Remove any HTML tags and clean up text
                text = text.replace(/<[^>]*>/g, '');
                return `"\u200F${text.replace(/"/g, '""')}"`;
            });
            csvContent += values.join(',') + '\n';
        });
        
        return csvContent;
    },

    // Export HTML to PDF function
    exportHTMLToPDF: function (htmlContent, fileName) {
        try {
            // Create a new window for printing
            const printWindow = window.open('', '_blank');
            
            // Write the HTML content directly
            printWindow.document.write(htmlContent);
            printWindow.document.close();
            
            // Wait for content to load then print
            printWindow.onload = function() {
                setTimeout(() => {
                    printWindow.print();
                    printWindow.close();
                }, 500);
            };
            
        } catch (e) {
            alert("فشل تصدير PDF. يرجى المحاولة مرة أخرى.");
        }
    },

    // Create clean table HTML for printing
    createCleanTableHTML: function (tableElement, pageTitle) {
        const table = tableElement.cloneNode(true);
        
        // Remove any buttons or interactive elements
        const buttons = table.querySelectorAll('button, .btn');
        buttons.forEach(btn => btn.remove());
        
        // Clean up any empty cells or rows
        const rows = table.querySelectorAll('tr');
        rows.forEach((row) => {
            const cells = row.querySelectorAll('td, th');
            cells.forEach((cell) => {
                // Remove any empty content or just whitespace
                if (cell.textContent.trim() === '') {
                    cell.textContent = '-';
                }
            });
        });
        
        const html = `
            <!DOCTYPE html>
            <html dir="rtl" lang="ar">
            <head>
                <meta charset="utf-8">
                <title>${pageTitle}</title>
                <style>
                    body {
                        font-family: 'Segoe UI', 'Tahoma', 'Arial', sans-serif;
                        direction: rtl;
                        text-align: right;
                        margin: 20px;
                        background: white;
                    }
                    .card {
                        border: 1px solid #ddd;
                        border-radius: 8px;
                        margin-bottom: 20px;
                        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
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
                        font-size: 12px;
                    }
                    th, td {
                        border: 1px solid #ddd;
                        padding: 8px;
                        text-align: center;
                        vertical-align: middle;
                    }
                    th {
                        background-color: #343a40;
                        color: white;
                        font-weight: bold;
                    }
                    .table-responsive {
                        overflow-x: auto;
                    }
                    .badge {
                        padding: 4px 8px;
                        border-radius: 4px;
                        font-size: 11px;
                    }
                    .bg-success { background-color: #198754 !important; color: white; }
                    .bg-danger { background-color: #dc3545 !important; color: white; }
                    .bg-warning { background-color: #ffc107 !important; color: black; }
                    .bg-info { background-color: #0dcaf0 !important; color: black; }
                    .bg-secondary { background-color: #6c757d !important; color: white; }
                    @media print {
                        body { margin: 0; }
                        .card { border: none; box-shadow: none; }
                        table { font-size: 11px; }
                        th, td { padding: 6px; }
                    }
                </style>
            </head>
            <body>
                <h1 style="text-align: center; margin-bottom: 30px; color: #198754;">${pageTitle}</h1>
                <div class="card">
                    <div class="card-body">
                        ${table.outerHTML}
                    </div>
                </div>
            </body>
            </html>
        `;
        
        return html;
    },

    // Confirmation dialog function
    confirmDialog: function (message) {
        return window.confirm(message);
    },

    // Print HTML content function
    printHTML: function (htmlContent, fileName) {
        try {
            // Create a new window for printing
            const printWindow = window.open('', '_blank');
            
            // Create the print document
            printWindow.document.write(`
                <!DOCTYPE html>
                <html dir="rtl" lang="ar">
                <head>
                    <meta charset="utf-8">
                    <title>${fileName || 'استمارة الاستئذان'}</title>
                    <style>
                        @page {
                            size: A4 portrait;
                            margin: 12mm;
                        }
                        body {
                            font-family: 'Segoe UI', 'Tahoma', 'Arial', sans-serif;
                            direction: rtl;
                            text-align: right;
                            margin: 0;
                            background: white;
                        }
                        .print-container {
                            width: 190mm;
                            margin: 0 auto;
                        }
                        @media print {
                            body { margin: 0; }
                        }
                    </style>
                </head>
                <body>
                    ${htmlContent}
                </body>
                </html>
            `);
            
            printWindow.document.close();
            
            // Wait for content to load then print
            printWindow.onload = function() {
                setTimeout(() => {
                    printWindow.print();
                    printWindow.close();
                }, 500);
            };
            
        } catch (e) {
            alert("فشل طباعة الاستمارة. يرجى المحاولة مرة أخرى.");
        }
    },

    // Show element function
    showElement: function (elementId) {
        const element = document.getElementById(elementId);
        if (element) {
            element.style.display = 'inline-block';
        }
    },

    // Hide element function
    hideElement: function (elementId) {
        const element = document.getElementById(elementId);
        if (element) {
            element.style.display = 'none';
        }
    }
};

// Make functions available globally for backward compatibility
window.exportToExcel = window.blazorInterop.exportToExcel;
window.exportToPDF = window.blazorInterop.exportToPDF;
window.exportHTMLToPDF = window.blazorInterop.exportHTMLToPDF;

// Download file function
window.downloadFile = function (fileName, data, mimeType) {
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

// Print element function
window.printElement = function (elementId) {
        const element = document.getElementById(elementId);
        if (!element) {
            console.error('Element not found:', elementId);
            alert('العنصر المطلوب طباعته غير موجود');
            return;
        }

        // Create a new window for printing
        const printWindow = window.open('', '_blank');
        
        // Get the element's HTML content
        const elementHTML = element.outerHTML;
        
        // Get page title from the element or use default
        const pageTitle = element.closest('.container-fluid')?.querySelector('h2')?.textContent || 'جدول البيانات';
        
        // Create the print document
        printWindow.document.write(`
            <!DOCTYPE html>
            <html dir="rtl" lang="ar">
            <head>
                <meta charset="utf-8">
                <title>${pageTitle}</title>
                <style>
                    body {
                        font-family: 'Segoe UI', 'Tahoma', 'Arial', sans-serif;
                        direction: rtl;
                        text-align: right;
                        margin: 20px;
                        background: white;
                    }
                    .card {
                        border: 1px solid #ddd;
                        border-radius: 8px;
                        margin-bottom: 20px;
                        box-shadow: 0 2px 4px rgba(0,0,0,0.1);
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
                        font-size: 12px;
                    }
                    th, td {
                        border: 1px solid #ddd;
                        padding: 8px;
                        text-align: center;
                        vertical-align: middle;
                    }
                    th {
                        background-color: #343a40;
                        color: white;
                        font-weight: bold;
                    }
                    .table-responsive {
                        overflow-x: auto;
                    }
                    .badge {
                        padding: 4px 8px;
                        border-radius: 4px;
                        font-size: 11px;
                    }
                    .bg-success { background-color: #198754 !important; color: white; }
                    .bg-danger { background-color: #dc3545 !important; color: white; }
                    .bg-warning { background-color: #ffc107 !important; color: black; }
                    .bg-info { background-color: #0dcaf0 !important; color: black; }
                    .bg-secondary { background-color: #6c757d !important; color: white; }
                    @media print {
                        body { margin: 0; }
                        .card { border: none; box-shadow: none; }
                        table { font-size: 11px; }
                        th, td { padding: 6px; }
                    }
                </style>
            </head>
            <body>
                <h1 style="text-align: center; margin-bottom: 30px; color: #198754;">${pageTitle}</h1>
                <div class="card">
                    <div class="card-body">
                        ${elementHTML}
                    </div>
                </div>
            </body>
            </html>
        `);
        
        printWindow.document.close();
        
        // Wait for content to load then print
        printWindow.onload = function() {
            setTimeout(() => {
                printWindow.print();
                printWindow.close();
            }, 500);
        };
};

// Make functions available globally for backward compatibility
window.exportToExcel = function(elementId, fileName) {
    return window.blazorInterop.exportToExcel(elementId, fileName);
};
window.exportToPDF = function(htmlContent, fileName) {
    return window.blazorInterop.exportHTMLToPDF(htmlContent, fileName);
};
window.exportHTMLToPDF = function(htmlContent, fileName) {
    return window.blazorInterop.exportHTMLToPDF(htmlContent, fileName);
};
window.confirmDialog = function(message) {
    return window.blazorInterop.confirmDialog(message);
};
window.printElement = function(elementId) {
    return window.blazorInterop.printElement(elementId);
};
window.printToPDF = function(elementId, fileName) {
    return window.blazorInterop.exportToPDF(elementId, fileName);
};
window.printHTML = function(htmlContent, fileName) {
    return window.blazorInterop.printHTML(htmlContent, fileName);
};
window.downloadFile = function(fileName, data, mimeType) {
    return window.blazorInterop.downloadFile(fileName, data, mimeType);
};
window.showElement = function(elementId) {
    return window.blazorInterop.showElement(elementId);
};
window.hideElement = function(elementId) {
    return window.blazorInterop.hideElement(elementId);
};

// Ensure all functions are available when the page loads
document.addEventListener('DOMContentLoaded', function() {
    // Functions loaded successfully
});
