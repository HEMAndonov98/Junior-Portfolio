import { ThemeProvider } from "@/components/theme-provider"
import type { Metadata } from "next";
import { GeistSans } from "geist/font/sans";
import { GeistMono } from "geist/font/mono"
import "./globals.css";
import Nav from "@/components/Nav";

export const metadata: Metadata = {
  title: "Hristo Andonov Portfolio",
  description: "My own personal portfolio website to showcase projects that I've worked on or am currently working on built with Next.js, React, Tailwind CSS",
};

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body
        className={`${GeistSans.variable} ${GeistMono.variable} antialiased`}
      >
        <Nav />
        <ThemeProvider
            attribute="class"
            defaultTheme="dark"
            enableSystem
            disableTransitionOnChange
          >
        {children}
        </ThemeProvider>
      </body>
    </html>
  );
}
