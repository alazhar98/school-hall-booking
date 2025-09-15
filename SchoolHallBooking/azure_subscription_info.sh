#!/bin/bash

# Simple Azure Subscription Information Script
# Quick and comprehensive subscription details

echo "🔍 Azure Subscription Information"
echo "================================="
echo ""

# Check Azure CLI
if ! command -v az &> /dev/null; then
    echo "❌ Azure CLI not found. Install with: brew install azure-cli"
    exit 1
fi

# Check login status
if ! az account show &> /dev/null; then
    echo "❌ Not logged in. Run: az login"
    exit 1
fi

echo "✅ Azure CLI ready"
echo ""

# 1. List all subscriptions in table format
echo "📊 ALL SUBSCRIPTIONS (Table View)"
echo "=================================="
az account list --output table --query "[].{Name:name, SubscriptionId:id, State:state, TenantId:tenantId, OfferType:subscriptionPolicies.offerType, QuotaId:subscriptionPolicies.quotaId, SpendingLimit:subscriptionPolicies.spendingLimit}"
echo ""

# 2. Current active subscription details
echo "🎯 CURRENT ACTIVE SUBSCRIPTION"
echo "==============================="
az account show --output table --query "{Name:name, SubscriptionId:id, State:state, OfferType:subscriptionPolicies.offerType, QuotaId:subscriptionPolicies.quotaId, SpendingLimit:subscriptionPolicies.spendingLimit, IsDefault:isDefault}"
echo ""

# 3. Detailed subscription analysis
echo "🔍 DETAILED ANALYSIS"
echo "===================="
CURRENT_SUB=$(az account show --output json)
SUBSCRIPTION_NAME=$(echo "$CURRENT_SUB" | jq -r '.name // "Unknown"')
OFFER_TYPE=$(echo "$CURRENT_SUB" | jq -r '.subscriptionPolicies.offerType // "Unknown"')
STATE=$(echo "$CURRENT_SUB" | jq -r '.state // "Unknown"')
QUOTA_ID=$(echo "$CURRENT_SUB" | jq -r '.subscriptionPolicies.quotaId // "Unknown"')
SPENDING_LIMIT=$(echo "$CURRENT_SUB" | jq -r '.subscriptionPolicies.spendingLimit // "None"')

echo "📋 Subscription Name: $SUBSCRIPTION_NAME"
echo "🏷️  Offer Type: $OFFER_TYPE"
echo "📊 State: $STATE"
echo "🆔 Quota ID: $QUOTA_ID"
echo "💰 Spending Limit: $SPENDING_LIMIT"
echo ""

# 4. Reserved pricing eligibility
echo "💡 RESERVED PRICING ELIGIBILITY"
echo "==============================="
case "$OFFER_TYPE" in
    "Free"|"FreeTrial")
        echo "❌ NOT eligible for reserved pricing (Free/Free Trial)"
        echo "   💡 Upgrade to Pay-As-You-Go for reserved pricing"
        ;;
    "PayAsYouGo")
        echo "✅ ELIGIBLE for reserved pricing (Pay-As-You-Go)"
        echo "   💡 Can purchase 1-year or 3-year reserved instances"
        ;;
    "Student")
        echo "⚠️  Limited eligibility (Student subscription)"
        echo "   💡 Check Microsoft Student program benefits"
        ;;
    "Enterprise"|"EnterpriseAgreement")
        echo "✅ ELIGIBLE for reserved pricing (Enterprise)"
        echo "   💡 Contact EA administrator for options"
        ;;
    "MSDN"|"VisualStudio")
        echo "⚠️  Limited eligibility (MSDN/Visual Studio)"
        echo "   💡 Some reserved pricing available for dev workloads"
        ;;
    *)
        echo "❓ Unknown offer type: $OFFER_TYPE"
        echo "   💡 Check Azure portal for eligibility"
        ;;
esac
echo ""

# 5. Export options
echo "💾 EXPORT OPTIONS"
echo "================="
echo "1. Export to JSON:"
echo "   az account list --output json > subscriptions.json"
echo ""
echo "2. Export current subscription:"
echo "   az account show --output json > current_subscription.json"
echo ""

# 6. Additional useful commands
echo "🛠️  USEFUL COMMANDS"
echo "==================="
echo "• Switch subscription: az account set --subscription 'Name'"
echo "• List locations: az account list-locations --output table"
echo "• Check billing: az billing account list"
echo "• View costs: az consumption usage list"
echo ""

echo "✅ Analysis complete!"
