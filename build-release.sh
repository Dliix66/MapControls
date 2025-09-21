#!/bin/bash

# Build and Release Script for CS2 Plugin
# This script builds the project in Release mode and packages it for deployment

set -e  # Exit on any error

# Auto-detect plugin name and version from source code
PLUGIN_FILE=$(find . -name "*.cs" -exec grep -l "class.*: BasePlugin$" {} \; | head -1)
if [ -z "$PLUGIN_FILE" ]; then
    # Fallback: look for files containing both BasePlugin and ModuleVersion
    PLUGIN_FILE=$(find . -name "*.cs" -exec grep -l "BasePlugin" {} \; | xargs grep -l "ModuleVersion" | head -1)
fi

if [ -z "$PLUGIN_FILE" ]; then
    echo "❌ Could not find plugin file with BasePlugin class"
    exit 1
fi

echo "🔍 Found plugin file: $PLUGIN_FILE"

# Extract plugin name from class declaration
PLUGIN_NAME=$(grep -o "class [A-Za-z0-9_]*.*: BasePlugin" "$PLUGIN_FILE" | sed 's/class \([A-Za-z0-9_]*\).*/\1/')
if [ -z "$PLUGIN_NAME" ]; then
    echo "❌ Could not extract plugin name from $PLUGIN_FILE"
    exit 1
fi

# Extract version from ModuleVersion property
PLUGIN_VERSION=$(grep -o 'ModuleVersion => "[^"]*"' "$PLUGIN_FILE" | sed 's/ModuleVersion => "\([^"]*\)"/\1/')
if [ -z "$PLUGIN_VERSION" ]; then
    echo "❌ Could not extract plugin version from $PLUGIN_FILE"
    exit 1
fi

echo "🎯 Detected: $PLUGIN_NAME v$PLUGIN_VERSION"

# Configuration
PROJECT_FILE="Template.csproj"
OUTPUT_DIR="./addons/counterstrikesharp/plugins/${PLUGIN_NAME}"
ARCHIVE_NAME="${PLUGIN_NAME}_${PLUGIN_VERSION}.zip"

echo "🔨 Building ${PLUGIN_NAME} v${PLUGIN_VERSION} in Release mode..."

# Clean previous builds
echo "🧹 Cleaning previous builds..."
dotnet clean "${PROJECT_FILE}" --configuration Release

# Build the project in Release mode
echo "🏗️  Building project..."
dotnet build "${PROJECT_FILE}" --configuration Release --no-restore

# Create the output directory structure
echo "📁 Creating output directory structure..."
mkdir -p "${OUTPUT_DIR}"

# Copy the built files to the plugin directory
echo "📋 Copying files to plugin directory..."
cp -r "./bin/Release/net8.0/"* "${OUTPUT_DIR}/"

# Create the zip archive
echo "📦 Creating zip archive: ${ARCHIVE_NAME}"
if [ -f "${ARCHIVE_NAME}" ]; then
    rm "${ARCHIVE_NAME}"
fi

# Create zip with the addons directory structure
zip -r "${ARCHIVE_NAME}" "./addons/"

echo "✅ Build and release completed successfully!"
echo "📦 Archive created: ${ARCHIVE_NAME}"
echo "📁 Plugin files copied to: ${OUTPUT_DIR}"

# Display archive contents
echo ""
echo "📋 Archive contents:"
unzip -l "${ARCHIVE_NAME}"
