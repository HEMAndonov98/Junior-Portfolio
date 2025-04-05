# 🌟 Hristo - Portfolio

![Portfolio Banner](Readme%20Assets/portfolio-portrait.png)

## 📋 Table of Contents

-   [Overview](#-overview)
-   [Live Demo](#-live-demo)
-   [Features](#-features)
-   [Tech Stack](#-tech-stack)
-   [Project Structure](#-project-structure)
-   [Getting Started](#-getting-started)
-   [Deployment](#-deployment)
-   [Performance](#-performance)
-   [Future Improvements](#-future-improvements)
-   [Credits](#-credits)
-   [License](#-license)

## 📝 Overview

This is my personal portfolio website which I created with the help of JavaScript Mastery mainly uisng Nextjs and TailwindCSS. The project aims to showcase my skills and what makes me unique for anyone who would be looking to start a project together

![Portfolio Screenshot](/Readme%20Assets/portfolio-banner.png)

## 🔗 Live Demo

Visit the live site: [Hristo Andonov Portfolio](https://hemandonov98.github.io/Junior-Portfolio/)

## ✨ Features

-   **Responsive Design** - Seamlessly works across all devices
-   **Interactive UI** - Engaging user interface with smooth animations
-   **Project Showcase** - Elegantly displays your featured projects
-   **Contact Form** - Easy way for visitors to reach out
-   **Performance Optimized** - Fast loading times and smooth experience

## 🛠️ Tech Stack

Frontend:

-   ![React](https://img.shields.io/badge/-React-61DAFB?style=flat-square&logo=react&logoColor=black)
-   ![Next.js](https://img.shields.io/badge/-Next.js-000000?style=flat-square&logo=next.js&logoColor=white)
-   ![TailwindCSS](https://img.shields.io/badge/-TailwindCSS-38B2AC?style=flat-square&logo=tailwind-css&logoColor=white)
-   ![JavaScript](https://img.shields.io/badge/-JavaScript-F7DF1E?style=flat-square&logo=javascript&logoColor=black)
-   ![TypeScript](https://img.shields.io/badge/-TypeScript-3178C6?style=flat-square&logo=typescript&logoColor=white)

Backend/Services:

-   ![Node.js](https://img.shields.io/badge/-Node.js-339933?style=flat-square&logo=node.js&logoColor=white)

Deployment:

-   [![GitHub](https://img.shields.io/badge/GitHub-%23121011.svg?logo=github&logoColor=white)](#)

## 📂 Project Structure

```
personal-portfolio/
|—— Readme Assets
|—— app/
|—— components/ #Reusable components
|  |__ ui/
|—— data/       #Component data
|—— lib/        #Acenternity ui utility configuration
|__ public/     #project assets
```

## 🚀 Getting Started

### Prerequisites

-   Node.js (v14.0 or higher)
-   npm or yarn

### Installation

1. Clone the repository

```bash
git clone https://github.com/HEMAndonov98/Junior-Portfolio.git
```

2. Change to the project directory

```bash
cd personal-portfolio
```

3. Install dependencies

```bash
npm install
# or
yarn install
```

4. Start the development server

```bash
npm run dev
# or
yarn dev
```

5. Open your browser and visit `http://localhost:3000`

## 📤 Deployment

Step-by-step guide on how to deploy your portfolio on GitHub Pages:

1. Create a .github/workflows directories

```bash
mkdir -p .github/workflows
```

2. Create a deploy-portfolio.yml file

```bash
touch deploy-portfolio.yml
```

3. Paste this code in the yml file

```yml
name: Deploy Next.js Portfolio to GitHub Pages

on:
    push:
        branches: [main]
        paths:
            - "personal-portfolio/**"
    # Allow manual triggering
    workflow_dispatch:

jobs:
    build-and-deploy:
        runs-on: ubuntu-latest
        permissions:
            contents: write

        steps:
            - name: Checkout repository
              uses: actions/checkout@v3

            - name: Setup Node.js
              uses: actions/setup-node@v3
              with:
                  node-version: "18"
                  cache: "npm"
                  cache-dependency-path: personal-portfolio/package-lock.json

            - name: Install dependencies
              run: npm ci
              working-directory: personal-portfolio

            - name: Create Sentry Environment File
              run: |
                  echo "SENTRY_AUTH_TOKEN=${{ secrets.SENTRY_AUTH_TOKEN }}" > .env.sentry-build-plugin
              working-directory: personal-portfolio

            - name: Build with Next.js
              run: |
                  npm run build
                  touch out/.nojekyll
              env:
                  SENTRY_AUTH_TOKEN: ${{ secrets.SENTRY_AUTH_TOKEN }}
              working-directory: personal-portfolio

            - name: Export static files
              run: npm run export || true
              env:
                  SENTRY_AUTH_TOKEN: ${{ secrets.SENTRY_AUTH_TOKEN }}
              working-directory: personal-portfolio

            - name: Copy public directory to output
              run: |
                  # Ensure public assets are in the build output
                  if [ -d "personal-portfolio/public" ] && [ -d "personal-portfolio/out" ]; then
                    cp -r personal-portfolio/public/* personal-portfolio/out/
                  fi

            - name: Deploy to GitHub Pages
              uses: JamesIves/github-pages-deploy-action@v4
              with:
                  folder: personal-portfolio/out
                  branch: gh-pages
                  token: ${{ secrets.GITHUB_TOKEN }}
                  clean: true
```

4. Build the project

```bash
npm run build
# or
yarn build
```

5. In your repository settings make sure you're on the gh-pages branch

## 📊 Performance

Share performance metrics of your portfolio:

Lighhose Score: 65-77/100

-   LCP: 0.9s
-   FCP: 0.3s
-   TBT: 520ms #Needs more work done
-   CLS: 0
-   Speed Index: 1.1s

## 🔮 Future Improvements

List future enhancements you plan to add:

-   [ ] website optimization
-   [ ] Dark/Light mode toggle
-   [ ] Multilingual support
-   [ ] Additional project showcases

## 🙏 Credits

-   Design inspiration from [jsmastery](https://resource.jsmastery.pro/minimal-portfolio)
-   Based on [JavaScript Mastery](https://www.jsmastery.pro/) tutorial with personal modifications
-   Icons from [FontAwesome](https://fontawesome.com/) and [React Icons](https://react-icons.github.io/react-icons/)
