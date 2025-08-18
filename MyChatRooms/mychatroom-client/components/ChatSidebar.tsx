"use client";
import React, { useState, useEffect } from "react";
import { Sidebar, SidebarBody, SidebarLink } from "./ui/sidebar";
import {
    IconArrowLeft,
    IconMessageFilled,
    IconSettings,
    IconUserBolt,
} from "@tabler/icons-react";
import Link from "next/link";
import { motion } from "framer-motion";
import Image from "next/image";
import { cn } from "@/lib/utils";
import Chat from "./ChatMain";
import { permanentRedirect } from "next/navigation";

export function SidebarDemo() {

    const [user, setUser] = useState<{ username: string } | null>(null);
    const handleLogout = async () => {
        const response = await fetch('http://localhost:5116/api/auth/logout', {
            method: 'POST',
            credentials: 'include',
            headers: { 'Content-Type': 'application/json' }
        });

        if (!response.ok) {
            const data = await response.json();
            console.log('Logout failed', data);
        } else {
            permanentRedirect('/');
        }
    }


    useEffect(() => {
        // Check localStorage
        const savedUser = localStorage.getItem('user');

        // Fetch data from api
        if (savedUser) {
            setUser(JSON.parse(savedUser));
        } else {
            const getProtectedData = async () => {

                try {
                    const response = await fetch('http://localhost:5116/api/auth/protected-resource', {
                        method: 'GET',
                        credentials: 'include',
                        headers: { 'Content-Type': 'application/json' }
                    });

                    if (!response.ok) {
                        throw new Error('Failed to fetch user data!');
                    }
                    const data = await response.json();
                    setUser(data);
                    localStorage.setItem('user', JSON.stringify(data));
                }
                catch (error) {
                    console.log(error);
                    setUser(null);
                }
            }

            getProtectedData();
        }
    }, []);

    const links = [
        {
            label: "Chat",
            href: "/chat",
            icon: (
                <IconMessageFilled className="text-neutral-700 dark:text-neutral-200 h-5 w-5 flex-shrink-0" />
            ),
        },
        {
            label: "Profile",
            href: "#",
            icon: (
                <IconUserBolt className="text-neutral-700 dark:text-neutral-200 h-5 w-5 flex-shrink-0" />
            ),
        },
        {
            label: "Settings",
            href: "#",
            icon: (
                <IconSettings className="text-neutral-700 dark:text-neutral-200 h-5 w-5 flex-shrink-0" />
            ),
        },
        {
            label: "Logout",
            href: "/",
            icon: (
                <IconArrowLeft onClick={handleLogout} className="text-neutral-700 dark:text-neutral-200 h-5 w-5 flex-shrink-0" />
            ),
        },
    ];
    const [open, setOpen] = useState(false);
    return (
        <div
            className={cn(
                "rounded-md flex flex-col md:flex-row bg-gray-100 dark:bg-neutral-800 w-full flex-1 border border-neutral-200 dark:border-neutral-700 overflow-hidden",
                "h-screen" // for your use case, use `h-screen` instead of `h-[60vh]`
            )}
        >
            <Sidebar open={open} setOpen={setOpen}>
                <SidebarBody className="justify-between gap-10">
                    <div className="flex flex-col flex-1 overflow-y-auto overflow-x-hidden">
                        {open ? <Logo user={user} /> : <LogoIcon />}
                        <div className="mt-8 flex flex-col gap-2">
                            {links.map((link, idx) => (
                                <SidebarLink key={idx} link={link} />
                            ))}
                        </div>
                    </div>
                    <div>
                        {user ? (
                            <SidebarLink
                                link={{
                                    label: user.username, // Display the username
                                    href: "#",
                                    icon: (
                                        <Image
                                            src={"https://assets.aceternity.com/manu.png"} // Use API image or default
                                            className="h-7 w-7 flex-shrink-0 rounded-full"
                                            width={50}
                                            height={50}
                                            alt="Avatar"
                                        />
                                    ),
                                }}
                            />
                        ) : (
                            <SidebarLink
                                link={{
                                    label: "Loading...",
                                    href: "#",
                                    icon: (
                                        <Image
                                            src="https://assets.aceternity.com/manu.png" // Default avatar while loading
                                            className="h-7 w-7 flex-shrink-0 rounded-full"
                                            width={50}
                                            height={50}
                                            alt="Avatar"
                                        />
                                    ),
                                }}
                            />
                        )}
                    </div>
                </SidebarBody>
            </Sidebar>
            <Chat />
        </div>
    );
}
export const Logo = ({ user }: { user: { username: string } | null }) => {
    return (
        <Link
            href="#"
            className="font-normal flex space-x-2 items-center text-sm text-black py-1 relative z-20"
        >
            <div className="h-5 w-6 bg-black dark:bg-white rounded-br-lg rounded-tr-sm rounded-tl-lg rounded-bl-sm flex-shrink-0" />
            <motion.span
                initial={{ opacity: 0 }}
                animate={{ opacity: 1 }}
                className="font-medium text-black dark:text-white whitespace-pre"
            >
                {user ? user.username : 'Loading...'}
            </motion.span>
        </Link>
    );
};
export const LogoIcon = () => {
    return (
        <Link
            href="#"
            className="font-normal flex space-x-2 items-center text-sm text-black py-1 relative z-20"
        >
            <div className="h-5 w-6 bg-black dark:bg-white rounded-br-lg rounded-tr-sm rounded-tl-lg rounded-bl-sm flex-shrink-0" />
        </Link>
    );
};