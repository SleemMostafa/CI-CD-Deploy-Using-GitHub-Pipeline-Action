# 🚀 CI/CD with GitHub Actions: Deploy .NET Application to Azure

This is a **test project** demonstrating how to implement a **CI/CD pipeline** to build, test, and deploy a .NET application to **Azure App Service** using **GitHub Actions**.

## 📌 Project Overview

This repository contains:

- A sample ASP.NET Core (.NET 6/7/8) application
- A GitHub Actions workflow file using `yaml` to automate the CI/CD process
- Configuration for deploying to Azure App Service
- Steps for building and testing the project before deployment

## 🎯 Objectives

- Automate the build, test, and deployment steps using GitHub Actions
- Connect GitHub to Azure using publish profiles or service principals
- Showcase a reliable CI/CD workflow using YAML
- Provide a starting point for deploying any .NET web application to Azure

## 🧰 Tech Stack

- [.NET 6/7/8/9](https://dotnet.microsoft.com/)
- [Azure App Service](https://azure.microsoft.com/en-us/services/app-service/)
- [GitHub Actions](https://docs.github.com/en/actions)
- CI/CD with YAML workflows

## 🛠 GitHub Actions Workflow

Here is an example workflow used in this project:

```yaml
name: Build and Deploy to Azure

on:
  push:
    branches:
      - main

jobs:
  build-and-deploy:
    runs-on: Windows

    steps:
      - name: Checkout Code
        uses: actions/checkout@v3

      - name: Setup .NET
        uses: actions/setup-dotnet@v3
        with:
          dotnet-version: '8.0.x'

      - name: Restore Dependencies
        run: dotnet restore

      - name: Build
        run: dotnet build --configuration Release --no-restore

      - name: Test
        run: dotnet test --no-build --verbosity normal

      - name: Publish
        run: dotnet publish -c Release -o ./publish

      - name: Deploy to Azure Web App
        uses: azure/webapps-deploy@v2
        with:
          app-name: ${{ secrets.AZURE_WEBAPP_NAME }}
          publish-profile: ${{ secrets.AZURE_WEBAPP_PUBLISH_PROFILE }}
          package: ./publish
