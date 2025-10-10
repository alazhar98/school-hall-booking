# Azure Subscription Details PowerShell Script
# Comprehensive subscription information and analysis

Write-Host "🔍 Azure Subscription Details" -ForegroundColor Cyan
Write-Host "=============================" -ForegroundColor Cyan
Write-Host ""

# Check if Azure CLI is installed
try {
    $azVersion = az version --output json | ConvertFrom-Json
    Write-Host "✅ Azure CLI Version: $($azVersion.'azure-cli')" -ForegroundColor Green
} catch {
    Write-Host "❌ Azure CLI not found. Please install it first." -ForegroundColor Red
    Write-Host "   Download from: https://docs.microsoft.com/en-us/cli/azure/install-azure-cli" -ForegroundColor Yellow
    exit 1
}

# Check if user is logged in
try {
    $currentAccount = az account show --output json | ConvertFrom-Json
    Write-Host "✅ Logged in to Azure" -ForegroundColor Green
} catch {
    Write-Host "❌ Not logged in to Azure. Please run: az login" -ForegroundColor Red
    exit 1
}

Write-Host ""

# Function to display subscription details
function Show-SubscriptionDetails {
    Write-Host "📊 ALL SUBSCRIPTIONS (Table View)" -ForegroundColor Yellow
    Write-Host "==================================" -ForegroundColor Yellow
    Write-Host ""
    
    # Get all subscriptions
    $subscriptions = az account list --output json | ConvertFrom-Json
    
    # Display in table format
    $subscriptions | Select-Object @{
        Name = 'Name'
        Expression = { $_.name }
    }, @{
        Name = 'SubscriptionId'
        Expression = { $_.id }
    }, @{
        Name = 'State'
        Expression = { $_.state }
    }, @{
        Name = 'OfferType'
        Expression = { $_.subscriptionPolicies.offerType }
    }, @{
        Name = 'QuotaId'
        Expression = { $_.subscriptionPolicies.quotaId }
    }, @{
        Name = 'SpendingLimit'
        Expression = { $_.subscriptionPolicies.spendingLimit }
    } | Format-Table -AutoSize
    
    Write-Host ""
}

# Function to analyze current subscription
function Analyze-CurrentSubscription {
    Write-Host "🎯 CURRENT ACTIVE SUBSCRIPTION" -ForegroundColor Yellow
    Write-Host "===============================" -ForegroundColor Yellow
    Write-Host ""
    
    $currentSub = az account show --output json | ConvertFrom-Json
    
    Write-Host "📋 Subscription Name: $($currentSub.name)" -ForegroundColor White
    Write-Host "🏷️  Offer Type: $($currentSub.subscriptionPolicies.offerType)" -ForegroundColor White
    Write-Host "📊 State: $($currentSub.state)" -ForegroundColor White
    Write-Host "🆔 Quota ID: $($currentSub.subscriptionPolicies.quotaId)" -ForegroundColor White
    Write-Host "💰 Spending Limit: $($currentSub.subscriptionPolicies.spendingLimit)" -ForegroundColor White
    Write-Host ""
    
    # Analyze reserved pricing eligibility
    Write-Host "💡 RESERVED PRICING ELIGIBILITY" -ForegroundColor Yellow
    Write-Host "===============================" -ForegroundColor Yellow
    
    $offerType = $currentSub.subscriptionPolicies.offerType
    
    switch ($offerType) {
        { $_ -in @("Free", "FreeTrial") } {
            Write-Host "❌ NOT eligible for reserved pricing (Free/Free Trial)" -ForegroundColor Red
            Write-Host "   💡 Upgrade to Pay-As-You-Go for reserved pricing" -ForegroundColor Yellow
        }
        "PayAsYouGo" {
            Write-Host "✅ ELIGIBLE for reserved pricing (Pay-As-You-Go)" -ForegroundColor Green
            Write-Host "   💡 Can purchase 1-year or 3-year reserved instances" -ForegroundColor Yellow
        }
        "Student" {
            Write-Host "⚠️  Limited eligibility (Student subscription)" -ForegroundColor Yellow
            Write-Host "   💡 Check Microsoft Student program benefits" -ForegroundColor Yellow
        }
        { $_ -in @("Enterprise", "EnterpriseAgreement") } {
            Write-Host "✅ ELIGIBLE for reserved pricing (Enterprise)" -ForegroundColor Green
            Write-Host "   💡 Contact EA administrator for options" -ForegroundColor Yellow
        }
        { $_ -in @("MSDN", "VisualStudio") } {
            Write-Host "⚠️  Limited eligibility (MSDN/Visual Studio)" -ForegroundColor Yellow
            Write-Host "   💡 Some reserved pricing available for dev workloads" -ForegroundColor Yellow
        }
        default {
            Write-Host "❓ Unknown offer type: $offerType" -ForegroundColor Red
            Write-Host "   💡 Check Azure portal for eligibility" -ForegroundColor Yellow
        }
    }
    
    Write-Host ""
}

# Function to export data
function Export-SubscriptionData {
    Write-Host "💾 EXPORT OPTIONS" -ForegroundColor Yellow
    Write-Host "=================" -ForegroundColor Yellow
    Write-Host ""
    
    $timestamp = Get-Date -Format "yyyyMMdd_HHmmss"
    
    # Export all subscriptions
    Write-Host "📁 Exporting all subscriptions to JSON..." -ForegroundColor White
    az account list --output json | Out-File -FilePath "azure_subscriptions_$timestamp.json" -Encoding UTF8
    
    # Export current subscription
    Write-Host "📁 Exporting current subscription to JSON..." -ForegroundColor White
    az account show --output json | Out-File -FilePath "current_subscription_$timestamp.json" -Encoding UTF8
    
    Write-Host "✅ Export completed!" -ForegroundColor Green
    Write-Host "   Files: azure_subscriptions_$timestamp.json" -ForegroundColor White
    Write-Host "          current_subscription_$timestamp.json" -ForegroundColor White
    Write-Host ""
}

# Function to show additional information
function Show-AdditionalInfo {
    Write-Host "🛠️  USEFUL COMMANDS" -ForegroundColor Yellow
    Write-Host "===================" -ForegroundColor Yellow
    Write-Host ""
    Write-Host "• Switch subscription: az account set --subscription 'Name'" -ForegroundColor White
    Write-Host "• List locations: az account list-locations --output table" -ForegroundColor White
    Write-Host "• Check billing: az billing account list" -ForegroundColor White
    Write-Host "• View costs: az consumption usage list" -ForegroundColor White
    Write-Host "• List resource groups: az group list --output table" -ForegroundColor White
    Write-Host ""
    
    Write-Host "📚 Additional PowerShell Commands:" -ForegroundColor Yellow
    Write-Host "• Get all subscriptions: Get-AzSubscription" -ForegroundColor White
    Write-Host "• Set subscription: Set-AzContext -SubscriptionId 'id'" -ForegroundColor White
    Write-Host "• Get current context: Get-AzContext" -ForegroundColor White
    Write-Host ""
}

# Main execution
function Main {
    try {
        # Show subscription details
        Show-SubscriptionDetails
        
        # Analyze current subscription
        Analyze-CurrentSubscription
        
        # Ask for export
        $exportChoice = Read-Host "Do you want to export data to JSON files? (y/n)"
        if ($exportChoice -eq 'y' -or $exportChoice -eq 'Y') {
            Export-SubscriptionData
        }
        
        # Show additional info
        Show-AdditionalInfo
        
        Write-Host "✅ Analysis complete!" -ForegroundColor Green
        
    } catch {
        Write-Host "❌ Error occurred: $($_.Exception.Message)" -ForegroundColor Red
        exit 1
    }
}

# Run the main function
Main
