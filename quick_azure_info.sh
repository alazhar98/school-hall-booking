#!/bin/bash

# Quick Azure Subscription Info - One-liner style
# Simple and fast subscription details

echo "🔍 Quick Azure Subscription Info"
echo "================================"

# Check if logged in
if ! az account show &> /dev/null; then
    echo "❌ Not logged in. Run: az login"
    exit 1
fi

echo ""
echo "📊 Current Subscription:"
az account show --output table --query "{Name:name, SubscriptionId:id, State:state, OfferType:subscriptionPolicies.offerType, SpendingLimit:subscriptionPolicies.spendingLimit}"

echo ""
echo "📋 All Subscriptions:"
az account list --output table --query "[].{Name:name, SubscriptionId:id, State:state, OfferType:subscriptionPolicies.offerType}"

echo ""
echo "💡 Reserved Pricing Eligibility:"
OFFER_TYPE=$(az account show --query "subscriptionPolicies.offerType" -o tsv)
case "$OFFER_TYPE" in
    "PayAsYouGo") echo "✅ ELIGIBLE for reserved pricing" ;;
    "Free"|"FreeTrial") echo "❌ NOT eligible (Free subscription)" ;;
    "Student") echo "⚠️  Limited eligibility (Student)" ;;
    "Enterprise"|"EnterpriseAgreement") echo "✅ ELIGIBLE (Enterprise)" ;;
    *) echo "❓ Check Azure portal for eligibility" ;;
esac

echo ""
echo "🛠️  Quick Commands:"
echo "• Switch: az account set --subscription 'Name'"
echo "• Export: az account list --output json > subs.json"
echo "• Locations: az account list-locations --output table"
