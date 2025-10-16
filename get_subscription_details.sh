#!/bin/bash

# Azure Subscription Details Script
# This script retrieves comprehensive subscription information from Azure CLI

echo "🔍 Azure Subscription Details Script"
echo "====================================="
echo ""

# Check if Azure CLI is installed
if ! command -v az &> /dev/null; then
    echo "❌ Azure CLI is not installed. Please install it first:"
    echo "   brew install azure-cli"
    exit 1
fi

# Check if user is logged in
if ! az account show &> /dev/null; then
    echo "❌ Not logged in to Azure. Please run: az login"
    exit 1
fi

echo "✅ Azure CLI is installed and you are logged in"
echo ""

# Function to display subscription details in table format
show_table_view() {
    echo "📊 SUBSCRIPTION DETAILS (Table View)"
    echo "====================================="
    echo ""
    
    # Basic subscription info
    echo "📋 Basic Information:"
    az account list --output table --query "[].{Name:name, SubscriptionId:id, State:state, TenantId:tenantId}"
    echo ""
    
    # Subscription details with offer type and spending limit
    echo "💰 Subscription Details:"
    az account list --output table --query "[].{Name:name, SubscriptionId:id, State:state, OfferType:subscriptionPolicies.offerType, QuotaId:subscriptionPolicies.quotaId, SpendingLimit:subscriptionPolicies.spendingLimit}"
    echo ""
    
    # Show current active subscription
    echo "🎯 Currently Active Subscription:"
    az account show --output table --query "{Name:name, SubscriptionId:id, State:state, OfferType:subscriptionPolicies.offerType, QuotaId:subscriptionPolicies.quotaId, SpendingLimit:subscriptionPolicies.spendingLimit}"
    echo ""
}

# Function to export detailed JSON
export_json() {
    local output_file="azure_subscriptions_$(date +%Y%m%d_%H%M%S).json"
    
    echo "💾 Exporting detailed subscription data to JSON..."
    echo "📁 File: $output_file"
    echo ""
    
    # Get comprehensive subscription details
    az account list --output json > "$output_file"
    
    if [ $? -eq 0 ]; then
        echo "✅ JSON export completed successfully!"
        echo "📊 File size: $(du -h "$output_file" | cut -f1)"
        echo ""
        
        # Show a preview of the JSON structure
        echo "🔍 JSON Structure Preview:"
        echo "========================="
        jq '.[0] | keys' "$output_file" 2>/dev/null || echo "Install 'jq' for better JSON formatting: brew install jq"
        echo ""
    else
        echo "❌ Failed to export JSON data"
        return 1
    fi
}

# Function to analyze subscription eligibility
analyze_eligibility() {
    echo "🔍 SUBSCRIPTION ELIGIBILITY ANALYSIS"
    echo "====================================="
    echo ""
    
    # Get current subscription details
    local current_sub=$(az account show --output json)
    local offer_type=$(echo "$current_sub" | jq -r '.subscriptionPolicies.offerType // "Unknown"')
    local state=$(echo "$current_sub" | jq -r '.state // "Unknown"')
    local subscription_name=$(echo "$current_sub" | jq -r '.name // "Unknown"')
    
    echo "📋 Current Subscription: $subscription_name"
    echo "🏷️  Offer Type: $offer_type"
    echo "📊 State: $state"
    echo ""
    
    # Analyze eligibility for reserved pricing
    echo "💡 Reserved Pricing Eligibility Analysis:"
    echo "========================================="
    
    case "$offer_type" in
        "Free"|"FreeTrial")
            echo "❌ Free/Free Trial subscriptions are NOT eligible for reserved pricing"
            echo "   💡 Upgrade to Pay-As-You-Go for reserved pricing benefits"
            ;;
        "PayAsYouGo")
            echo "✅ Pay-As-You-Go subscriptions ARE eligible for reserved pricing"
            echo "   💡 You can purchase 1-year or 3-year reserved instances"
            ;;
        "Student")
            echo "⚠️  Student subscriptions may have limited reserved pricing eligibility"
            echo "   💡 Check with Microsoft for specific student program benefits"
            ;;
        "MSDN"|"VisualStudio")
            echo "⚠️  MSDN/Visual Studio subscriptions have limited reserved pricing"
            echo "   💡 Some reserved pricing may be available for development workloads"
            ;;
        "Enterprise"|"EnterpriseAgreement")
            echo "✅ Enterprise subscriptions ARE eligible for reserved pricing"
            echo "   💡 Contact your EA administrator for reserved pricing options"
            ;;
        *)
            echo "❓ Unknown offer type: $offer_type"
            echo "   💡 Check Azure portal or contact support for eligibility"
            ;;
    esac
    echo ""
    
    # Check spending limit
    local spending_limit=$(echo "$current_sub" | jq -r '.subscriptionPolicies.spendingLimit // "None"')
    if [ "$spending_limit" != "None" ]; then
        echo "⚠️  Spending Limit: $spending_limit"
        echo "   💡 Spending limits may affect reserved pricing eligibility"
    else
        echo "✅ No spending limit detected"
    fi
    echo ""
}

# Function to show subscription usage and quotas
show_usage_quotas() {
    echo "📈 SUBSCRIPTION USAGE & QUOTAS"
    echo "=============================="
    echo ""
    
    echo "🔍 Checking subscription usage..."
    
    # Get subscription ID
    local sub_id=$(az account show --query id -o tsv)
    
    # Get usage details (this may require additional permissions)
    echo "📊 Resource Usage:"
    az consumption usage list --billing-period-name $(date +%Y%m) --output table 2>/dev/null || echo "   ⚠️  Usage data not available (may require billing permissions)"
    echo ""
    
    # Get quota information
    echo "📋 Resource Quotas:"
    az vm list-usage --location "East US" --output table 2>/dev/null || echo "   ⚠️  Quota data not available (may require compute permissions)"
    echo ""
}

# Main execution
main() {
    echo "🚀 Starting Azure subscription analysis..."
    echo ""
    
    # Show table view
    show_table_view
    
    # Analyze eligibility
    analyze_eligibility
    
    # Show usage and quotas
    show_usage_quotas
    
    # Export JSON
    echo "💾 EXPORT OPTIONS"
    echo "================="
    echo ""
    read -p "Do you want to export detailed data to JSON? (y/n): " -n 1 -r
    echo ""
    if [[ $REPLY =~ ^[Yy]$ ]]; then
        export_json
    fi
    
    echo "✅ Analysis complete!"
    echo ""
    echo "📚 Additional Commands:"
    echo "======================="
    echo "• View all subscriptions: az account list --output table"
    echo "• Switch subscription: az account set --subscription 'Subscription Name'"
    echo "• Get current subscription: az account show"
    echo "• List all locations: az account list-locations --output table"
    echo ""
}

# Run the main function
main
