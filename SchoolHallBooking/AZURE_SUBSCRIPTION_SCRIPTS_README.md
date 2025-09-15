# Azure Subscription Details Scripts

This collection of scripts provides comprehensive Azure subscription information and analysis, including eligibility for reserved pricing.

## 📁 Scripts Overview

### 1. `azure_subscription_info.sh` (Recommended)
**Comprehensive subscription analysis with detailed output**

**Features:**
- ✅ Lists all subscriptions in table format
- ✅ Shows current active subscription details
- ✅ Analyzes reserved pricing eligibility
- ✅ Provides export options
- ✅ Includes useful commands reference

**Usage:**
```bash
./azure_subscription_info.sh
```

### 2. `get_subscription_details.sh`
**Advanced script with full analysis and JSON export**

**Features:**
- ✅ Comprehensive subscription details
- ✅ Usage and quota analysis
- ✅ Interactive JSON export
- ✅ Detailed eligibility analysis
- ✅ Additional Azure resource information

**Usage:**
```bash
./get_subscription_details.sh
```

### 3. `quick_azure_info.sh`
**Fast one-liner style information**

**Features:**
- ✅ Quick subscription overview
- ✅ Fast reserved pricing check
- ✅ Essential commands only
- ✅ Minimal output, maximum speed

**Usage:**
```bash
./quick_azure_info.sh
```

### 4. `Get-AzureSubscriptionDetails.ps1`
**PowerShell version for Windows users**

**Features:**
- ✅ Full PowerShell integration
- ✅ Color-coded output
- ✅ Interactive export options
- ✅ Windows-optimized commands

**Usage:**
```powershell
.\Get-AzureSubscriptionDetails.ps1
```

## 🚀 Quick Start

### Prerequisites
1. **Azure CLI installed:**
   ```bash
   # macOS
   brew install azure-cli
   
   # Windows
   winget install Microsoft.AzureCLI
   
   # Linux
   curl -sL https://aka.ms/InstallAzureCLIDeb | sudo bash
   ```

2. **Login to Azure:**
   ```bash
   az login
   ```

3. **Make scripts executable (macOS/Linux):**
   ```bash
   chmod +x *.sh
   ```

### Run the Scripts
```bash
# Quick overview
./quick_azure_info.sh

# Comprehensive analysis
./azure_subscription_info.sh

# Full detailed analysis
./get_subscription_details.sh
```

## 📊 What You'll See

### Subscription Information
- **Name:** Subscription display name
- **Subscription ID:** Unique identifier
- **State:** Enabled/Disabled status
- **Offer Type:** Free Trial, Pay-As-You-Go, Student, etc.
- **Quota ID:** Subscription quota identifier
- **Spending Limit:** Current spending restrictions

### Reserved Pricing Eligibility
- ✅ **Pay-As-You-Go:** Full eligibility for 1-year and 3-year reserved instances
- ✅ **Enterprise/EA:** Full eligibility (contact EA administrator)
- ❌ **Free/Free Trial:** Not eligible (upgrade required)
- ⚠️ **Student:** Limited eligibility (check program benefits)
- ⚠️ **MSDN/Visual Studio:** Limited eligibility for dev workloads

## 💾 Export Options

### JSON Export
```bash
# All subscriptions
az account list --output json > subscriptions.json

# Current subscription only
az account show --output json > current_subscription.json
```

### Table Export
```bash
# All subscriptions table
az account list --output table > subscriptions.txt

# Current subscription table
az account show --output table > current_subscription.txt
```

## 🛠️ Useful Commands

### Subscription Management
```bash
# List all subscriptions
az account list --output table

# Switch subscription
az account set --subscription "Subscription Name"

# Show current subscription
az account show

# List all locations
az account list-locations --output table
```

### Billing and Costs
```bash
# Check billing accounts
az billing account list

# View usage
az consumption usage list

# Get cost analysis
az costmanagement query --type Usage --dataset-aggregation totalCost=sum --dataset-grouping name=ResourceGroupName type=Dimension --timeframe MonthToDate
```

### Resource Management
```bash
# List resource groups
az group list --output table

# List all resources
az resource list --output table

# Check quotas
az vm list-usage --location "East US" --output table
```

## 🔍 Troubleshooting

### Common Issues

1. **"Not logged in" error:**
   ```bash
   az login
   ```

2. **"Azure CLI not found" error:**
   ```bash
   # Install Azure CLI
   brew install azure-cli  # macOS
   ```

3. **Permission errors:**
   - Ensure you have appropriate permissions
   - Contact your Azure administrator if needed

4. **JSON parsing errors:**
   ```bash
   # Install jq for better JSON handling
   brew install jq  # macOS
   ```

### Script Permissions
```bash
# Make scripts executable
chmod +x *.sh

# Run with bash if needed
bash azure_subscription_info.sh
```

## 📋 Output Examples

### Table View
```
Name                  SubscriptionId                        State    OfferType
--------------------  ------------------------------------  -------  -----------
Azure subscription 1  c1087a0b-e7a7-4985-ac64-461fbdcac6ce  Enabled  PayAsYouGo
```

### Reserved Pricing Analysis
```
💡 RESERVED PRICING ELIGIBILITY
===============================
✅ ELIGIBLE for reserved pricing (Pay-As-You-Go)
   💡 Can purchase 1-year or 3-year reserved instances
```

## 🎯 Use Cases

1. **Cost Optimization:** Check if you're eligible for reserved pricing
2. **Subscription Management:** Quickly view all your subscriptions
3. **Audit and Compliance:** Export subscription details for reporting
4. **Troubleshooting:** Identify subscription issues and limitations
5. **Planning:** Understand subscription capabilities and restrictions

## 📚 Additional Resources

- [Azure CLI Documentation](https://docs.microsoft.com/en-us/cli/azure/)
- [Azure Reserved Instances](https://docs.microsoft.com/en-us/azure/cost-management-billing/reservations/)
- [Azure Subscription Management](https://docs.microsoft.com/en-us/azure/cost-management-billing/)
- [Azure Pricing Calculator](https://azure.microsoft.com/en-us/pricing/calculator/)

## 🤝 Contributing

Feel free to enhance these scripts with additional features:
- Add more subscription details
- Include cost analysis
- Add resource usage information
- Create additional export formats

## 📄 License

These scripts are provided as-is for educational and administrative purposes.
